using Airplace2025.BLL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmNangHang: Form
    {
        public frmNangHang(DataTable ticketData)
        {
            InitializeComponent();
            _ticketData = ticketData;
        }

        private DataTable _ticketData; // Dữ liệu vé của khách (được truyền từ frmTraCuu)
        private DataTable _dtHangVe;   // Dữ liệu tỉ lệ giá các hạng vé
        private decimal _giaCoBanHienTai = 0;
        private string _maHangVeCu = "";

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtThoiGianDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool CheckFillInText(string[] strings)
        {
            foreach (string control in strings)
            {
                if (control == string.Empty)
                    return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string maVe = cbChonChuyen.SelectedValue.ToString();
                string maHangMoi = cbHangMoi.SelectedValue.ToString();

                DialogResult dr = MessageBox.Show($"Xác nhận nâng hạng với phí {lbTongThu.Text}?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    TicketDAO.Instance.NangHangVe(maVe, maHangMoi);
                    MessageBox.Show("Nâng hạng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đóng form và báo về form cha
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNangHang_Load(object sender, EventArgs e)
        {
            LoadComboboxChuyenBay();
            LoadComboboxHangVe();
        }

        private void LoadComboboxChuyenBay()
        {
            // Hiển thị danh sách chuyến bay của khách vào ComboBox
            // DisplayMember: Hiển thị tên chuyến bay + Chặng
            // ValueMember: Mã Vé (Lưu ý: Dùng Mã Vé để định danh dòng cần sửa)

            // Tạo một cột hiển thị đẹp hơn
            if (!_ticketData.Columns.Contains("DisplayFlight"))
            {
                _ticketData.Columns.Add("DisplayFlight", typeof(string),
                    "MaChuyenBay + ' (' + TenSanBayDi + ' - ' + TenSanBayDen + ')'");
            }

            cbChonChuyen.DataSource = _ticketData;
            cbChonChuyen.DisplayMember = "DisplayFlight";
            cbChonChuyen.ValueMember = "MaVe"; // Quan trọng: Giá trị là Mã Vé
        }

        private void LoadComboboxHangVe()
        {
            _dtHangVe = TicketDAO.Instance.GetTiLeHangVe();
            cbHangMoi.DataSource = _dtHangVe;
            cbHangMoi.DisplayMember = "TenHangVe";
            cbHangMoi.ValueMember = "MaHangVe";
        }

        private void cbChonChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonChuyen.SelectedValue == null) return;

            string maVe = cbChonChuyen.SelectedValue.ToString();

            // Tìm dòng dữ liệu tương ứng trong DataTable
            DataRow[] rows = _ticketData.Select($"MaVe = '{maVe}'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];

                // Lấy thông tin cần thiết để tính toán
                // Lưu ý: Cần đảm bảo _ticketData từ sp_TraCuuDatVe có cột GiaCoBan (nếu chưa có phải thêm vào SP)
                // Giả sử ta lấy lại GiaCoBan từ DB hoặc tính ngược từ giá vé thực tế / tỉ lệ cũ

                // Ở đây tôi giả định bạn đã update sp_TraCuuDatVe để trả về thêm cột: TenHangVe, GiaCoBan (từ bảng ChuyenBay)
                // Nếu chưa, hãy sửa SP thêm cột cb.GiaCoBan
                if (row.Table.Columns.Contains("GiaCoBan"))
                    _giaCoBanHienTai = Convert.ToDecimal(row["GiaCoBan"]);
                else
                    _giaCoBanHienTai = 1000000; // Giá mặc định nếu thiếu (cần sửa SP)

                string tenHangCu = row["TenHangVe"].ToString(); // Ví dụ: "Thương gia"

                // Tìm Mã Hạng Vé Cũ dựa trên tên (hoặc lấy từ SP nếu có cột MaHangVe)
                DataRow[] rHv = _dtHangVe.Select($"TenHangVe = '{tenHangCu}'");
                if (rHv.Length > 0)
                {
                    _maHangVeCu = rHv[0]["MaHangVe"].ToString();
                    txtHangHienTai.Text = tenHangCu;

                    decimal tiLeCu = Convert.ToDecimal(rHv[0]["TiLeGiaHangVe"]);
                    txtGiaHienTai.Text = (_giaCoBanHienTai * tiLeCu).ToString("N0") + " đ";
                }

                CalculatePrice(); // Tính lại tiền
            }
        }

        private void cbHangMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            if (cbHangMoi.SelectedValue == null || string.IsNullOrEmpty(_maHangVeCu)) return;

            string maHangMoi = cbHangMoi.SelectedValue.ToString();

            // Lấy tỉ lệ
            decimal tiLeCu = 0, tiLeMoi = 0;

            DataRow[] rOld = _dtHangVe.Select($"MaHangVe = '{_maHangVeCu}'");
            if (rOld.Length > 0) tiLeCu = Convert.ToDecimal(rOld[0]["TiLeGiaHangVe"]);

            DataRow[] rNew = _dtHangVe.Select($"MaHangVe = '{maHangMoi}'");
            if (rNew.Length > 0) tiLeMoi = Convert.ToDecimal(rNew[0]["TiLeGiaHangVe"]);

            // Tính toán
            decimal giaCu = _giaCoBanHienTai * tiLeCu;
            decimal giaMoi = _giaCoBanHienTai * tiLeMoi;
            decimal chenhLech = giaMoi - giaCu;
            decimal phi = 100000;

            // Hiển thị
            txtGiaMoi.Text = giaMoi.ToString("N0") + " đ";

            if (chenhLech <= 0)
            {
                lbTongThu.Text = "Không hợp lệ";
                lbTongThu.ForeColor = System.Drawing.Color.Red;
                btnXacNhan.Enabled = false; // Không cho hạ hạng vé
            }
            else
            {
                lbTongThu.Text = (chenhLech + phi).ToString("N0") + " đ";
                lbTongThu.ForeColor = System.Drawing.Color.Green;
                btnXacNhan.Enabled = true;
            }
        }


    }
}
