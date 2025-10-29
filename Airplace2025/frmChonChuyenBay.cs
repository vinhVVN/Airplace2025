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
    public partial class frmChonChuyenBay : Form
    {
        private string sanBayDi;
        private string sanBayDen;

        public frmChonChuyenBay()
        {
            InitializeComponent();
        }

        public frmChonChuyenBay(string sanBayDi, string sanBayDen)
        {
            InitializeComponent();
            this.sanBayDi = sanBayDi;
            this.sanBayDen = sanBayDen;
        }

        private void frmChonChuyenBay_Load(object sender, EventArgs e)
        {
            // Hiển thị mã sân bay từ frmDatVe
            if (!string.IsNullOrEmpty(sanBayDi))
            {
                lblFrom.Text = sanBayDi;
            }
            
            if (!string.IsNullOrEmpty(sanBayDen))
            {
                lblTo.Text = sanBayDen;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
           bool isExpanded = btnChange.Checked;
           lblDown.Visible = !isExpanded;
           lblUp.Visible = isExpanded;
           pnlChange.Visible = isExpanded;
        }

        private void btnTotalCustomers_Click(object sender, EventArgs e)
        {
            frmSoLuongKhachHang soLuongKhachHangForm = new frmSoLuongKhachHang();
            soLuongKhachHangForm.Show();
        }
    }
}
