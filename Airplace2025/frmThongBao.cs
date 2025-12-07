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
    public partial class frmThongBao: Form
    {
        public frmThongBao()
        {
            InitializeComponent();
        }

        public string Subject { get; private set; }
        public string Body { get; private set; }

        private void frmThemTrungGian_Load(object sender, EventArgs e)
        {
            
            


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề và nội dung.");
                return;
            }

            Subject = txtTieuDe.Text;
            Body = txtNoiDung.Text; // Có thể format thêm HTML ở đây nếu muốn

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
