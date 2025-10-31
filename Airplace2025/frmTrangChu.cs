using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.BLL;
using Airplace2025.BLL.DTO;

namespace Airplace2025
{
    public partial class frmMain : Form
    {
        // Biến để lưu thông tin người dùng đã đăng nhập (từ frmDangNhap)
        private NguoiDungDTO currentUser;

        public frmMain(NguoiDungDTO user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Thiết lập sự kiện cho nút Đóng
            btnClose.Click += (s, ev) => Application.Exit();

            // Tải màn hình mặc định khi form Main load
            // Mặc định: Chuyến bay > Danh sách chuyến bay
            btnDanhSachChuyenBay.PerformClick();
        }

        // Phương thức chung để hiển thị một UserControl trong pnlMainContent
        private void LoadUserControl(UserControl userControl)
        {
            try
            {
                // 1. Xóa tất cả các control cũ trong panel
                pnlMainContent.Controls.Clear();

                // 2. Thiết lập thuộc tính cho UserControl mới
                userControl.Dock = DockStyle.Fill;
                userControl.BringToFront();

                // 3. Thêm UserControl vào Panel
                pnlMainContent.Controls.Add(userControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải màn hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý khi nhấn vào Tab "Chuyến bay" trên thanh Menu chính
        private void btnChuyenBay_Click(object sender, EventArgs e)
        {
            // Logic: Hiện SubMenu Chuyến Bay và thực hiện click vào nút mặc định (Danh sách)
            pnlSubMenu.Visible = true;
            btnDanhSachChuyenBay.PerformClick();
        }

        // Hàm xử lý khi nhấn vào nút "Danh sách chuyến bay"
        private void btnDanhSachChuyenBay_Click(object sender, EventArgs e)
        {
            // Đánh dấu nút đang được chọn
            Guna2Button currentButton = sender as Guna2Button;
            UpdateSubMenuSelection(currentButton);

            // TODO: Khởi tạo và tải UserControl Danh sách chuyến bay (ví dụ: new ucDanhSachChuyenBay())
            // LoadUserControl(new ucDanhSachChuyenBay()); 
            MessageBox.Show("Màn hình Danh sách chuyến bay đang được tải...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm xử lý khi nhấn vào nút "Tạo chuyến bay mới"
        private void btnTaoChuyenBayMoi_Click(object sender, EventArgs e)
        {
            Guna2Button currentButton = sender as Guna2Button;
            UpdateSubMenuSelection(currentButton);

            // TODO: Khởi tạo và tải UserControl Tạo chuyến bay mới (ví dụ: new ucTaoChuyenBay())
            // LoadUserControl(new ucTaoChuyenBay());
            MessageBox.Show("Màn hình Tạo chuyến bay mới đang được tải...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Phương thức tùy chỉnh để cập nhật trạng thái Checked của SubMenu Buttons
        private void UpdateSubMenuSelection(Guna2Button clickedButton)
        {
            foreach (Control control in pnlSubMenu.Controls)
            {
                if (control is Guna2Button button)
                {
                    // Đặt tất cả nút SubMenu về trạng thái FillColor mặc định trừ nút được click
                    if (button != clickedButton)
                    {
                        button.Checked = false;
                        button.FillColor = Color.White; // Hoặc màu nền SubMenu (240, 240, 240)
                    }
                    else
                    {
                        button.Checked = true;
                        button.FillColor = Color.DodgerBlue; // Màu nhấn
                    }
                }
            }
        }

        // TODO: Thêm các hàm xử lý cho các nút menu chính khác (Vé máy bay, Báo cáo,...)
        /*
        private void btnVeMayBay_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = false; // Ẩn SubMenu nếu không cần
            LoadUserControl(new ucVeMayBay()); 
        }
        */
    }
}
