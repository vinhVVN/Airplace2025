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
using System.Xml.Linq;

namespace Airplace2025
{
    public partial class frmAddAirplane: Form
    {
        public frmAddAirplane()
        {
            InitializeComponent();
            LoadAllAirline();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAllAirline()
        {
            cbHangBay.DataSource = AirlineDAO.Instance.GetAirlineList();
            cbHangBay.ValueMember = "MaHangBay";
            cbHangBay.DisplayMember = "TenHangBay";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int soghe;
            if (!int.TryParse(txtSoGhe.Text, out soghe) || soghe < 0)
            {
                MessageBox.Show("Số ghế không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            bool isFill = CheckFillInText(new string[] { this.txtMaMayBay.Text, this.txtTenMayBay.Text});
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    AirplaneDAO.Instance.InsertAirplane(txtMaMayBay.Text, txtTenMayBay.Text, soghe,
                        cbHangBay.SelectedValue.ToString());

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            this.Close();
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

    }
}
