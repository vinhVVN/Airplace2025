using Airplace2025.BLL;
using Airplace2025.BLL.DAO;
using Airplace2025.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmThanhToan : Form
    {
        private decimal _totalAmount;
        private string _customerName;
        private List<string> _ticketIds;
        private CultureInfo _culture = new CultureInfo("vi-VN");

        public frmThanhToan(decimal totalAmount, string customerName, List<string> ticketIds)
        {
            InitializeComponent();
            _totalAmount = totalAmount;
            _customerName = customerName;
            _ticketIds = ticketIds;

            LoadData();
            SetupEvents();
        }

        // Constructor default for designer
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            lblCustomerName.Text = _customerName;
            lblTotalAmount.Text = _totalAmount.ToString("N0", _culture) + " VND";

            // Load QR Code immediately for Transfer tab
            // Format: https://vietqr.co/api/generate/VCB/1040489798/VIETQR.CO/{amount}/{message}
            // Use a simplified message like "VEMAYBAY" + timestamp
            string message = $"VEMAYBAY {DateTime.Now:HHmm}";
            string qrUrl = $"https://vietqr.co/api/generate/VCB/1040489798/VIETQR.CO/{_totalAmount}/{message}";
            
            try 
            {
                picQRCode.Load(qrUrl);
            }
            catch
            {
                // Ignore error if no internet, maybe show placeholder
            }
        }

        private void SetupEvents()
        {
            txtCashReceived.TextChanged += TxtCashReceived_TextChanged;
            btnComplete.Click += BtnComplete_Click;
            
            // Format text box input to numbers only
            txtCashReceived.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };
        }

        private void TxtCashReceived_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCashReceived.Text.Replace(",", "").Replace(".", ""), out decimal cashReceived))
            {
                // Format input nicely
                // (Optional: handling cursor position is tricky with simple replacement, keeping it simple here)
                
                decimal change = cashReceived - _totalAmount;
                if (change >= 0)
                {
                    lblChange.Text = change.ToString("N0", _culture) + " VND";
                    lblChange.ForeColor = Color.Green;
                }
                else
                {
                    lblChange.Text = "Chưa đủ tiền (" + change.ToString("N0", _culture) + ")";
                    lblChange.ForeColor = Color.Red;
                }
            }
            else
            {
                lblChange.Text = "0 VND";
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            string paymentMethod = "";
            
            // Validation based on selected tab
            if (tabPaymentMethods.SelectedTab == tabCash)
            {
                if (!decimal.TryParse(txtCashReceived.Text, out decimal cashReceived) || cashReceived < _totalAmount)
                {
                    MessageBox.Show("Số tiền khách đưa chưa đủ!", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                paymentMethod = "Tiền mặt";
            }
            else if (tabPaymentMethods.SelectedTab == tabTransfer)
            {
                if (!chkTransferConfirmed.Checked)
                {
                    MessageBox.Show("Vui lòng xác nhận đã nhận đủ tiền chuyển khoản!", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                paymentMethod = "Chuyển khoản";
            }

            // Process Payment
            try
            {
                string maHoaDon;
                string success = HoaDonBLL.Instance.ThanhToan(_totalAmount, paymentMethod, _ticketIds, out maHoaDon);
                
                if (success != "")
                {
                    MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHoaDon}", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogDAO.Instance.GhiNhatKy("Đặt vé", $"Đặt vé thành công. Mã hoá đơn: {maHoaDon}. Tổng tiền: {_totalAmount}");
                    DataTable ve = TicketDAO.Instance.TraCuuDatVe(success, _customerName);
                    frmTraCuuDatVe frm = new frmTraCuuDatVe();
                    frm.HienThiFormVe(ve);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
