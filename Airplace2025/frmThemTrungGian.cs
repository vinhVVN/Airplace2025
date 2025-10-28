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
    public partial class frmThemTrungGian: Form
    {
        public frmThemTrungGian()
        {
            InitializeComponent();
        }

        private void frmThemTrungGian_Load(object sender, EventArgs e)
        {
            cbSanBay.DataSource = AirportDAO.Instance.GetAirportList();
            cbSanBay.ValueMember = "MaSanBay";
            cbSanBay.DisplayMember = "TenSanBay";
            


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataRow SanBayTrungGianRow { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int thoigiandung;
            int thoigianchuyen;
            if (!int.TryParse(txtThoiGianDung.Text, out thoigiandung) || thoigiandung < 0)
            {
                MessageBox.Show("Thời gian dừng không hợp lệ","Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (!int.TryParse(txtThoiGianChuyen.Text, out thoigianchuyen) || thoigianchuyen < 0)
            {
                MessageBox.Show("Thời gian chuyển không hợp lệ","Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (cbSanBay.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn sân bay","Lỗi", MessageBoxButtons.OK);
                return;
            }

            string ghiChu = txtGhiChu.Text;
            string maSanBay = cbSanBay.SelectedValue.ToString();
            string tenSanBay = cbSanBay.Text; 

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("MaSanBay", typeof(string));
            dtTemp.Columns.Add("TenSanBay", typeof(string));
            dtTemp.Columns.Add("ThoiGianDung", typeof(int));
            dtTemp.Columns.Add("ThoiGianChuyen", typeof(int));
            dtTemp.Columns.Add("GhiChu", typeof(string));

            DataRow dr = dtTemp.NewRow();
            dr["MaSanBay"] = maSanBay;
            dr["TenSanBay"] = tenSanBay;
            dr["ThoiGianDung"] = thoigiandung;
            dr["ThoiGianChuyen"] = thoigianchuyen;
            dr["GhiChu"] = ghiChu;

            this.SanBayTrungGianRow = dr;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
