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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
            SetActiveButton(btnChuyenBay); // Gọi hàm với nút "Chuyến bay"
            LoadFormIntoPanel(new frmDanhSachChuyenBay());
        }
        // Màu sắc tùy chỉnh (Bạn có thể thay đổi)
        private Color INACTIVE_COLOR = Color.Black; // Màu chữ khi không chọn
        private Color ACTIVE_COLOR = Color.DodgerBlue; // Màu chữ và màu gạch chân khi chọn

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            // --- 1. RESET (Đưa tất cả các nút về trạng thái Mặc định) ---
            // Tạo một List hoặc mảng chứa tất cả các nút menu của bạn
            Guna.UI2.WinForms.Guna2Button[] menuButtons =
                new Guna.UI2.WinForms.Guna2Button[] { btnChuyenBay, btnVeMayBay, btnBaoCao,btnMayBay, btnLapLichBay };

            foreach (var btn in menuButtons)
            {
                // Đặt màu chữ về màu mặc định
                btn.ForeColor = INACTIVE_COLOR;

                // Đặt màu gạch chân (BorderColor) về màu nền (ẩn gạch chân)
                btn.BorderColor = Color.Transparent;
            }

            // --- 2. THIẾT LẬP (Nổi bật nút được chọn) ---

            // Đặt màu chữ cho nút đang được chọn
            activeBtn.ForeColor = ACTIVE_COLOR;

            // Đặt màu gạch chân cho nút đang được chọn (hiện gạch chân)
            activeBtn.BorderColor = ACTIVE_COLOR;

            // Nếu bạn muốn đổi cả màu nền khi chọn, bạn có thể thêm:
            // activeBtn.FillColor = Color.LightGray; 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmDanhSachChuyenBay());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmDatVe());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            LoadFormIntoPanel(new frmThongKe());

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmTraCuuDatVe());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            LoadFormIntoPanel(new frmLapLichChuyenBay());
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;

        private void LoadFormIntoPanel(Form childform)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            childform.FormBorderStyle = FormBorderStyle.None;

            pnlCommon.Controls.Clear();
            pnlCommon.Controls.Add(childform);
            pnlCommon.Tag = childform;
            childform.Show();
        }

    }
}
