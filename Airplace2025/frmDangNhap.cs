using Airplace2025.BLL.DTO;
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
		public frmDangNhap()
		{
			InitializeComponent();
			// Gắn sự kiện Click cho các controls
			btnDangNhap.Click += btnDangNhap_Click;
			btnClose.Click += btnClose_Click;
			lblQuenMatKhau.Click += lblQuenMatKhau_Click;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			// Đóng toàn bộ ứng dụng khi nhấn nút X
			Application.Exit();
		}

		private void lblQuenMatKhau_Click(object sender, EventArgs e)
		{
			// Xử lý sự kiện Quên mật khẩu
			MessageBox.Show("Vui lòng liên hệ quản trị viên để đặt lại mật khẩu.",
							"Quên mật khẩu",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			string email = txtEmail.Text.Trim();
			string matKhau = txtMatKhau.Text;

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
			{
				MessageBox.Show("Vui lòng nhập Email và Mật khẩu.",
								"Lỗi đăng nhập",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning);
				return;
			}

			try
			{
				// 1. Gọi tầng BLL để xác thực
				// Giả định TaiKhoanBLL.Instance.Authenticate(email, matKhau) trả về NguoiDungDTO nếu thành công
				NguoiDungDTO user = TaiKhoanBLL.Instance.Authenticate(email, matKhau);

				if (user != null)
				{
					// Đăng nhập thành công
					MessageBox.Show($"Chào mừng {user.HoTen} ({user.MaNguoiDung})!",
									"Đăng nhập thành công",
									MessageBoxButtons.OK,
									MessageBoxIcon.Information);

					// 2. Mở form chính (hoặc form đặt vé) và ẩn form đăng nhập
					// Sử dụng Tag để lưu thông tin người dùng đã đăng nhập, hoặc dùng một Global Static context
					this.Tag = user;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					// Đăng nhập thất bại (Email hoặc Mật khẩu không đúng)
					MessageBox.Show("Email hoặc Mật khẩu không chính xác. Vui lòng thử lại.",
									"Lỗi đăng nhập",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				// Xử lý lỗi kết nối CSDL hoặc lỗi khác
				MessageBox.Show($"Đã xảy ra lỗi trong quá trình đăng nhập: {ex.Message}",
								"Lỗi hệ thống",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}

		// Tùy chọn: Xử lý sự kiện nhấn Enter
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Enter)
			{
				btnDangNhap.PerformClick();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
