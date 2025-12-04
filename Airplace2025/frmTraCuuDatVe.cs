using Airplace2025.BLL.DAO;
using Airplace2025.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmTraCuuDatVe: Form
    {
        public frmTraCuuDatVe()
        {
            InitializeComponent();
        }

        private void frmTraCuuDatVe_Load(object sender, EventArgs e)
        {
            TicketPnl.Visible = false;
            pnlCustomer.Visible = false;
            pnlTicketInfo.Visible = false;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private DataTable _currentTicketData;

        private void btnFind_Click(object sender, EventArgs e)
        {

            string maVe = txtMaVe.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(maVe) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã vé và Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Gọi DAO tìm kiếm
                _currentTicketData = TicketDAO.Instance.TraCuuDatVe(maVe, hoTen);

                if (_currentTicketData != null && _currentTicketData.Rows.Count > 0)
                {
                    // 2. Hiển thị thông tin khách hàng (Lấy dòng đầu tiên)
                    DataRow firstRow = _currentTicketData.Rows[0];

                    lbMaVe.Text = firstRow["MaDatVe"].ToString();

                    // Xử lý tên: Nguyễn Văn Tèo -> VĂN TÈO NGUYỄN
                    string rawName = firstRow["HoTen"].ToString();
                    lbCustomerName.Text = FormatPassengerName(rawName);

                    lbGender.Text = firstRow["GioiTinh"].ToString();

                    // 3. Hiển thị danh sách chuyến bay (FlightSight)
                    LoadFlightDetails(_currentTicketData);

                    // 4. Hiện các Panel
                    pnlTicketInfo.Visible = true;
                    pnlCustomer.Visible = true;
                    TicketPnl.Visible = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin vé.\nVui lòng kiểm tra lại Mã vé và Họ tên chính xác.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnlTicketInfo.Visible = false;
                    pnlCustomer.Visible = false;
                    TicketPnl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string FormatPassengerName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "";

            string[] parts = fullName.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1) return parts[0].ToUpper(); // Chỉ có 1 từ

            string ho = parts[0]; // Nguyễn
            string ten = parts[parts.Length - 1]; // Tèo

            string tenDem = "";
            if (parts.Length > 2)
            {
                // Lấy các từ ở giữa làm tên đệm
                tenDem = string.Join(" ", parts.Skip(1).Take(parts.Length - 2));
            }

            // Ghép lại: Đệm + Tên + Họ
            string result = $"{tenDem} {ten} {ho}".Trim();
            return RemoveDiacritics(result).ToUpper();
        }

        private void LoadFlightDetails(DataTable dt)
        {
            TicketPnl.Controls.Clear(); // Xóa cũ

            foreach (DataRow row in dt.Rows)
            {
                // Khởi tạo UserControl
                FlightSight flightControl = new FlightSight();

                // Lấy dữ liệu từ Row
                string tenMayBay = row["TenMayBay"].ToString();
                string maSbDi = row["MaSanBayDi"].ToString();
                string maSbDen = row["MaSanBayDen"].ToString();
                string tenSbDi = row["TenSanBayDi"].ToString();
                string tenSbDen = row["TenSanBayDen"].ToString();
                string ghe = row["MaGhe"].ToString();

                DateTime ngayGioDi = Convert.ToDateTime(row["NgayGioBay"]);
                int thoiGianBay = Convert.ToInt32(row["ThoiGianBay"]);
                DateTime ngayGioDen = ngayGioDi.AddMinutes(thoiGianBay);

                string gioDi = ngayGioDi.ToString("HH:mm");
                string ngayDi = ngayGioDi.ToString("dd/MM/yyyy");
                string gioDen = ngayGioDen.ToString("HH:mm");
                string ngayDen = ngayGioDen.ToString("dd/MM/yyyy");

                string thoiLuong = FormatDuration(thoiGianBay);

                // Xử lý ảnh Logo
                Image logo = null;
                if (row["Logo"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["Logo"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        logo = Image.FromStream(ms);
                    }
                }

                // Đổ dữ liệu vào Control
                flightControl.SetData(
                    tenMayBay,
                    maSbDi,
                    maSbDen,
                    tenSbDi,
                    tenSbDen,
                    gioDi,
                    gioDen,
                    ngayDi,
                    ngayDen,
                    thoiLuong,
                    logo,
                    ghe
                );

                // Thêm vào FlowLayoutPanel
                TicketPnl.Controls.Add(flightControl);
            }
        }

        private string FormatDuration(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            return minutes > 0 ? $"{hours}h {minutes}m" : $"{hours}h";
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            // Xử lý riêng chữ đ / Đ
            return sb.ToString()
                     .Replace("đ", "d")
                     .Replace("Đ", "D");
        }

        private void lbUpClass_Click(object sender, EventArgs e)
        {
            if (_currentTicketData == null || _currentTicketData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có thông tin vé.");
                return;
            }

            // Mở form Nâng Hạng và truyền dữ liệu vé hiện tại sang
            frmNangHang frm = new frmNangHang(_currentTicketData);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Nếu nâng hạng thành công -> Load lại dữ liệu mới nhất từ CSDL
                // Để cập nhật lại hạng vé mới trên giao diện
                btnFind_Click(sender, e);
            }
        }
    }
}
