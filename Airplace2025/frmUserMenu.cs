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
    public partial class frmUserMenu: Form
    {
        public frmUserMenu()
        {
            InitializeComponent();
            lbName.Text = Session.HoTen;
        }

        // Tự động đóng khi form mất tiêu điểm(Click ra ngoài)
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Có thể gọi một sự kiện hoặc xử lý trực tiếp
            Session.Clear();

            // Tìm Form cha (Trang chủ) để đóng nó
            Application.OpenForms["frmTrangChu"]?.Close();

            // Mở lại form đăng nhập
            frmDangNhap frm = new frmDangNhap();
            frm.Show();

            this.Close(); // Đóng menu
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Thiết lập màu viền (Color.Silver hoặc Color.Black tuỳ bạn)
            Color mauVien = Color.Silver;

            // Độ dày viền
            int doDay = 1;

            // Vẽ viền bao quanh Form
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                                    mauVien, doDay, ButtonBorderStyle.Solid,
                                    mauVien, doDay, ButtonBorderStyle.Solid,
                                    mauVien, doDay, ButtonBorderStyle.Solid,
                                    mauVien, doDay, ButtonBorderStyle.Solid);
        }
    }
}
