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
    public partial class frmNhatKyHoatDong: Form
    {
        public frmNhatKyHoatDong()
        {
            InitializeComponent();
        }

        private void frmNhatKyHoatDong_Load(object sender, EventArgs e)
        {
            // Mặc định load dữ liệu 7 ngày gần nhất
            dtpTuNgay.Value = DateTime.Now.AddDays(-7);
            dtpDenNgay.Value = DateTime.Now;

            LoadLogData();
            FormatGrid();
        }


        private void LoadLogData()
        {
            string keyword = txtTimKiem.Text.Trim();
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;

            DataTable dt = LogDAO.Instance.LayNhatKyHoatDong(keyword, tuNgay, denNgay);
            dgvLog.DataSource = dt;

            // Cập nhật label đếm số lượng bản ghi (nếu có)
            // lbCount.Text = $"Tìm thấy {dt.Rows.Count} hoạt động.";
        }

        private void FormatGrid()
        {
            if (dgvLog.Columns.Count == 0) return;

            dgvLog.Columns["MaNhatKy"].HeaderText = "ID";
            dgvLog.Columns["MaNhatKy"].Width = 50;

            dgvLog.Columns["ThoiGian"].HeaderText = "Thời gian";
            dgvLog.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvLog.Columns["ThoiGian"].Width = 150;

            dgvLog.Columns["TenDangNhap"].HeaderText = "Người thực hiện";
            dgvLog.Columns["TenDangNhap"].Width = 120;

            dgvLog.Columns["HanhDong"].HeaderText = "Hành động";
            dgvLog.Columns["HanhDong"].Width = 150;

            dgvLog.Columns["ChiTiet"].HeaderText = "Chi tiết";
            dgvLog.Columns["ChiTiet"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Cột này tự giãn
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadLogData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadLogData();
            }
        }
    }
}
