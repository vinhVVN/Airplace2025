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
    public partial class frmMuaHanhLy: Form
    {
        public frmMuaHanhLy(string maDatVe)
        {
            InitializeComponent();
            _maDatVe = maDatVe;

            // Setup Combobox gói hành lý
            cbGoiHanhLy.Items.Add(new { Kg = 15, Gia = 150000 });
            cbGoiHanhLy.Items.Add(new { Kg = 20, Gia = 200000 });
            cbGoiHanhLy.Items.Add(new { Kg = 25, Gia = 300000 });
            cbGoiHanhLy.Items.Add(new { Kg = 30, Gia = 450000 });

            cbGoiHanhLy.DisplayMember = "Kg";
            cbGoiHanhLy.SelectedIndex = 0;
        }

        private string _maDatVe;

        private void cbGoiHanhLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic item = cbGoiHanhLy.SelectedItem;
            txtGiaTien.Text = string.Format("{0:N0} VNĐ", item.Gia);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            dynamic item = cbGoiHanhLy.SelectedItem;
            int soKg = item.Kg;
            decimal gia = Convert.ToDecimal(item.Gia);

            if (MessageBox.Show($"Xác nhận mua {soKg}kg hành lý với giá {txtGiaTien.Text}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    TicketDAO.Instance.MuaThemHanhLy(_maDatVe, soKg, gia);
                    MessageBox.Show("Mua hành lý thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
