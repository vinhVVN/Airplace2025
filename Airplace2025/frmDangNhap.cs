using Airplace2025.BLL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmDangNhap : Form
    {
        private bool isPasswordHidden = true;

        // Ký tự ẩn đã chọn. Thay '*' bằng ký tự bạn đang dùng (ví dụ: '•')
        private const char HIDE_CHAR = '*';
        public frmDangNhap()
        {
            InitializeComponent();
            // Thiết lập trạng thái ban đầu
            isPasswordHidden = true;

            // Đảm bảo tắt ký tự hệ thống
            txtPassword.UseSystemPasswordChar = false;

            // Dùng ký tự ẩn tùy chỉnh của bạn
            txtPassword.PasswordChar = HIDE_CHAR;
        }
 
       
        private void frmDangNhap_Load(object sender, EventArgs e)
        {



        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DangNhap_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click_2(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái hiện tại
            isPasswordHidden = !isPasswordHidden;

            if (isPasswordHidden)
            {
                // === TRẠNG THÁI ẨN (Password Hidden) ===

                // 1. Tắt ký tự hệ thống (để dùng ký tự * của riêng ta)
                txtPassword.UseSystemPasswordChar = false;

                // 2. Đặt ký tự ẩn tùy chỉnh
                txtPassword.PasswordChar = HIDE_CHAR;

                // 3. Thay đổi biểu tượng con mắt thành trạng thái ĐÓNG
                guna2ImageButton1.Image = Properties.Resources.noun_closed_eye_5269901;
            }
            else
            {
                // === TRẠNG THÁI HIỆN (Password Visible) ===

                // 1. Tắt ký tự hệ thống
                txtPassword.UseSystemPasswordChar = false;

                // 2. Tắt ký tự ẩn tùy chỉnh (sẽ hiện văn bản)
                txtPassword.PasswordChar = '\0';

                // 3. Thay đổi biểu tượng con mắt thành trạng thái MỞ
                guna2ImageButton1.Image = Properties.Resources.eye_removebg_preview;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUserName.Text;
            string matKhau = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                DataTable dtTaiKhoan = AccountDAO.Instance.Login(tenDangNhap, matKhau);

                if (dtTaiKhoan.Rows.Count > 0)
                {
                    DataRow userInfo = dtTaiKhoan.Rows[0];
                    string hoTen = userInfo["HoTen"].ToString();
                    string vaiTro = userInfo["TenVaiTro"].ToString();

                    MessageBox.Show($"Chào mừng {hoTen} ({vaiTro})!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // (Bạn có thể lưu thông tin vào một lớp tĩnh tại đây, ví dụ:)
                    // Session.CurrentUser = new User(userInfo);

                    // Mở form chính và ẩn form này
                    frmTrangChu fTrangChu = new frmTrangChu();
                    fTrangChu.Show();
                    this.Hide();
                }
                else
                {
                    // ĐĂNG NHẬP THẤT BẠI
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
