using Airplace2025.BLL.DAO;
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
    public partial class frmLapLichChuyenBay: Form
    {
        public frmLapLichChuyenBay()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void LapLichChuyenBay_Load(object sender, EventArgs e)
        {
            dtpNgayGioBay.Value = DateTime.Now;
            AirportLoadAll();
            AddNote();
            AirlineLoad();
            FlightLoadAll();
            SetupFlightPointsGrid();
        }

        private void AirlineLoad()
        {
            cbHangBay.DataSource = AirlineDAO.Instance.GetAirlineList();
            cbHangBay.ValueMember = "MaHangBay";
            cbHangBay.DisplayMember = "TenHangBay";
        }

        private void FlightLoadAll()
        {
            dgvChuyenBay.DataSource = FlightDAO.Instance.SearchFlightByInfo(txtTimKiemChuyenBay.Text);
        }

        private void AirportLoadAll()
        {
            cbSanBayDi.DataSource = AirportDAO.Instance.GetAirportList();
            cbSanBayDi.DisplayMember = "TenSanBay";
            cbSanBayDi.ValueMember = "MaSanBay";
            cbSanBayDen.DataSource = AirportDAO.Instance.GetAirportList();
            cbSanBayDen.DisplayMember = "TenSanBay";
            cbSanBayDen.ValueMember = "MaSanBay";
        }

        private void SetupFlightPointsGrid()
        {
            dgvFareClass.Columns.Clear();
            dgvFareClass.Rows.Clear();

            dgvFareClass.RowHeadersVisible = false;
            dgvFareClass.AutoGenerateColumns = false;
            dgvFareClass.AllowUserToAddRows = false;
            dgvFareClass.AllowUserToDeleteRows = false;
            dgvFareClass.AllowUserToOrderColumns = false;
            dgvFareClass.ReadOnly = false;

            dgvFareClass.RowTemplate.Height = 50;
            dgvFareClass.BackgroundColor = Color.White;
            dgvFareClass.DefaultCellStyle.BackColor = Color.White;
            dgvFareClass.DefaultCellStyle.ForeColor = Color.Black;
            dgvFareClass.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;

            DataTable dt = ClassDAO.Instance.GetClassList();
            dgvFareClass.Columns.Add("Category", "Hạng Vé");
            foreach (DataRow row in dt.Rows)
            {
                dgvFareClass.Columns.Add(row["MaHangVe"].ToString(), row["TenHangVe"].ToString());
                dgvFareClass.Columns[row["MaHangVe"].ToString()].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            List<object> tiLeGiaVeRow = new List<object>();
            List<object> soGheRow = new List<object>();

            tiLeGiaVeRow.Add("Tỉ Lệ Giá Vé");
            soGheRow.Add("Số Ghế");

            foreach (DataRow row in dt.Rows)
            {
                tiLeGiaVeRow.Add(row["TiLeGiaHangVe"]);
                soGheRow.Add(0);
            }
            dgvFareClass.Rows.Add(tiLeGiaVeRow.ToArray());
            dgvFareClass.Rows.Add(soGheRow.ToArray());

            dgvFareClass.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvFareClass.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFareClass.ColumnHeadersDefaultCellStyle.BackColor = Color.White; 
            dgvFareClass.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; 
            DataGridViewCellStyle rowHeaderStyle = new DataGridViewCellStyle();
            rowHeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rowHeaderStyle.ForeColor = Color.Black; 
            dgvFareClass.Columns["Category"].DefaultCellStyle = rowHeaderStyle;
            for (int i = 1; i < dgvFareClass.Columns.Count; i++)
            {
                dgvFareClass.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgvFareClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFareClass.Columns["Category"].FillWeight = 150;
            dgvFareClass.Columns["Category"].ReadOnly = true;
            DataGridViewRow qantasRow = dgvFareClass.Rows[0];
            foreach (DataGridViewCell cell in qantasRow.Cells)
            {
                cell.ReadOnly = true;
            }
        }

        public void ThemTrungGian(string MaSanBay, string TenSanBay, 
                            int ThoiGianDung, int ThoiGianChuyen, string GhiChu)
        {
            foreach (DataGridViewRow row in dgvTrungGian.Rows)
            {
                if (row.Cells["MaSanBay"].Value != null && (row.Cells["MaSanBay"].Value.ToString() == MaSanBay
                     || row.Cells["MaSanBay"].Value.ToString() == cbSanBayDi.Text
                     || row.Cells["MaSanBay"].Value.ToString() == cbSanBayDen.Text))
                {
                    MessageBox.Show("Sân bay đã tồn tại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            int stt = dgvTrungGian.Rows.Count + 1;
            dgvTrungGian.Rows.Add(MaSanBay, stt, TenSanBay, ThoiGianDung, ThoiGianChuyen, GhiChu);


        }

        private void txtTimKiemChuyenBay_TextChanged(object sender, EventArgs e)
        {
            FlightLoadAll();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmThemTrungGian formChon = new frmThemTrungGian())
            {
                DialogResult result = formChon.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    DataRow rowNhanVe = formChon.SanBayTrungGianRow;

                    if (rowNhanVe != null)
                    {
                        string maSanBay = rowNhanVe["MaSanBay"].ToString();
                        string tenSanBay = rowNhanVe["TenSanBay"].ToString();
                        int thoiGianDung = Convert.ToInt32(rowNhanVe["ThoiGianDung"]);
                        int thoiGianChuyen = Convert.ToInt32(rowNhanVe["ThoiGianChuyen"]);
                        string ghiChu = rowNhanVe["GhiChu"].ToString();
                        ThemTrungGian(maSanBay, tenSanBay, thoiGianDung, thoiGianChuyen, ghiChu);
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvTrungGian.CurrentRow != null)
            {
                DataGridViewRow row = dgvTrungGian.CurrentRow;
                DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa sân bay trung gian này?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    dgvTrungGian.Rows.Remove(row);

                    for (int i = 0; i< dgvTrungGian.Rows.Count; i++)
                    {
                        dgvTrungGian.Rows[i].Cells["ThuTu"].Value = i + 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cbHangBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cbHangBay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            gbHangBay.Height = 251;
            imgLogo.Visible = true;
            txtMoTaHangBay.Visible = true;
            DataTable dtHangBay = AirlineDAO.Instance.GetAirlineList();
            txtMoTaHangBay.Text = dtHangBay.Rows[cbHangBay.SelectedIndex]["MoTa"].ToString();

            DataTable dtMayBay = AirplaneDAO.Instance.GetAirplaneByAirline(cbHangBay.SelectedValue.ToString());
            cbAirplane.DataSource = dtMayBay;
            cbAirplane.DisplayMember = "TenMayBay";
            cbAirplane.ValueMember = "MaMayBay";
            
        }

        private void cbAirplane_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbAirplane_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtMayBay = AirplaneDAO.Instance.GetAirplaneByAirline(cbHangBay.SelectedValue.ToString());
            txtSeat.Text = dtMayBay.Rows[cbAirplane.SelectedIndex]["SoGhe"].ToString();
        }

        private void AddNote()
        {
            DataTable dt = ParameterDAO.Instance.GetParameter();
            txtQuyTac.Text = "Quy tắc:" + Environment.NewLine
                + $"Số sân bay trung gian tối đa: {dt.Rows[0]["SoSanBayTrungGianToiDa"]}" + Environment.NewLine
                + $"Thời gian bay tối thiểu: {dt.Rows[0]["ThoiGianBayToiThieu"]} phút" + Environment.NewLine
                + $"Thời gian dừng tối thiểu: {dt.Rows[0]["ThoiGianDungToiThieu"]} phút" + Environment.NewLine
                + $"Thời gian dừng tối đa: {dt.Rows[0]["ThoiGianDungToiDa"]}  phút";
        }


        private bool KiemtraDk()
        {

            DataTable dtThamSo = ParameterDAO.Instance.GetParameter();
            DataRow thamso = dtThamSo.Rows[0];
            int thoigianbaytoithieu = Convert.ToInt32(thamso["ThoiGianBayToiThieu"]);
            int thoigiandungtoithieu = Convert.ToInt32(thamso["ThoiGianDungToiThieu"]);
            int thoigiandungtoida = Convert.ToInt32(thamso["ThoiGianDungToiDa"]);
            int soTGToiDa = Convert.ToInt32(thamso["SoSanBayTrungGianToiDa"]);

            int thoigianbay;
            decimal chiphicoban;
            DateTime ngaygiobay = dtpNgayGioBay.Value;
            if (!int.TryParse(txtThoiGianBay.Text, out thoigianbay) || thoigianbay < 0)
            {
                MessageBox.Show("Thời gian bay không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (!decimal.TryParse(txtGiaCoBan.Text, out chiphicoban) || chiphicoban < 0)
            {
                MessageBox.Show("Giá cơ bản không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                return false;
            }

            if (cbSanBayDi.SelectedIndex == -1 || cbSanBayDen.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn sân bay", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (cbSanBayDi.Text == cbSanBayDen.Text)
            {
                MessageBox.Show("Sân bay đi và sân bay đến không được trùng nhau", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (ngaygiobay < DateTime.Now)
            {
                MessageBox.Show("Ngày giờ bay phải lớn hơn hoặc là thời điểm hiện tại", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (thoigianbay < thoigianbaytoithieu)
            {
                MessageBox.Show("Thời gian bay không thoả như quy định", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (cbAirplane.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn hãng bay hoặc máy bay", "Lỗi", MessageBoxButtons.OK);
                return false;
            }
            if (dgvTrungGian.Rows.Count > soTGToiDa)
            {
                MessageBox.Show("Số sân bay trung gian không thoả quy định", "Lỗi", MessageBoxButtons.OK);
                return false;
            }

            int tongThoiGianChuyen = 0;
            foreach (DataGridViewRow row in dgvTrungGian.Rows)
            {
                int thoigiandung = Convert.ToInt32(row.Cells["ThoiGianDung"].Value.ToString());
                if (thoigiandung < thoigiandungtoithieu || thoigiandung > thoigiandungtoida)
                {
                    MessageBox.Show("Thời gian dừng tại sân bay trung gian không thoả quy định", "Lỗi", MessageBoxButtons.OK);
                    return false;
                }
                int thoigianchuyen = Convert.ToInt32(row.Cells["ThoiGianChuyen"].Value.ToString());
                tongThoiGianChuyen += thoigianchuyen;
            }
            if (tongThoiGianChuyen >= thoigianbay)
            {
                MessageBox.Show("Tổng thời gian các chặn lớn hơn thời gian bay", "Lỗi", MessageBoxButtons.OK);
                return false;
            }

            int sogheMayBay = Convert.ToInt32(txtSeat.Text);
            int tongsogheHangVe = 0;
            DataGridViewRow soGheRow = dgvFareClass.Rows[1];
            for (int i = 1; i< soGheRow.Cells.Count; i++)
            {
                int soGhe;
                if (soGheRow.Cells[i].Value == null || !int.TryParse(soGheRow.Cells[i].Value.ToString(),out soGhe)
                    || soGhe < 0)
                {
                    MessageBox.Show($"Số ghế cho hạng vé {dgvFareClass.Columns[i].HeaderText} không hợp lệ", "Lỗi", MessageBoxButtons.OK);
                    return false;
                }
                tongsogheHangVe += soGhe;
            }
            if (tongsogheHangVe != sogheMayBay)
            {
                MessageBox.Show("Tổng số ghế các hạng vé phải bằng số ghế máy bay", "Lỗi", MessageBoxButtons.OK);
                return false;
            }



            return true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (KiemtraDk())
            {
                try
                {
                    DataTable dtChuyenBayMoi = FlightDAO.Instance.InsertFlight(
                        cbSanBayDi.SelectedValue.ToString(),
                        cbSanBayDen.SelectedValue.ToString(),
                        dtpNgayGioBay.Value,
                        Convert.ToInt32(txtThoiGianBay.Text),
                        Convert.ToDecimal(txtGiaCoBan.Text),
                        cbAirplane.SelectedValue.ToString(),
                        cbTinhTrang.Text
                    );

                    string MaChuyenBayMoi = dtChuyenBayMoi.Rows[0]["MaChuyenBay"].ToString();
                    
                    foreach (DataGridViewRow row in dgvTrungGian.Rows)
                    {
                        string MaSanBay = row.Cells["MaSanBay"].Value.ToString();
                        int ThuTu = Convert.ToInt32(row.Cells["ThuTu"].Value.ToString());
                        int ThoiGianDung = Convert.ToInt32(row.Cells["ThoiGianDung"].Value.ToString());
                        string GhiChu = row.Cells["GhiChu"].Value.ToString();
                        int ThoiGianChuyen = Convert.ToInt32(row.Cells["ThoiGianChuyen"].Value.ToString());
                        StopDAO.Instance.InsertStop(MaChuyenBayMoi, MaSanBay, ThuTu, ThoiGianDung,
                                                                GhiChu, ThoiGianChuyen);

                    }

                    DataGridViewRow seatRow = dgvFareClass.Rows[1];
                    for (int i = 1; i < seatRow.Cells.Count; i++)
                    {
                        string MaHangVe = dgvFareClass.Columns[i].Name;
                        int SoGhe = Convert.ToInt32(seatRow.Cells[i].Value);
                        if (SoGhe > 0)
                        {
                            ClassDAO.Instance.InsertClassInfo(MaChuyenBayMoi, MaHangVe, SoGhe, SoGhe);
                        }
                    }

                    MessageBox.Show("Thêm chuyến bay thành công","Thông báo", MessageBoxButtons.OK);
                    ReNew();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReNew();
        }

        private void ReNew()
        {
            cbSanBayDi.SelectedIndex = 0;
            cbSanBayDen.SelectedIndex = 0;
            cbTinhTrang.SelectedIndex = 0;
            dtpNgayGioBay.Value = DateTime.Now;
            txtGiaCoBan.Text = "";
            txtThoiGianBay.Text = "";
            dgvTrungGian.Rows.Clear();
            txtTimKiemChuyenBay.Text = "";

            DataGridViewRow seatRow = dgvFareClass.Rows[1];
            for (int i=1; i < seatRow.Cells.Count; i++)
            {
                dgvFareClass.Rows[1].Cells[i].Value = 0;
            }

        }

        private bool isEditFlight = false;

        private void btnEditFlight_Click(object sender, EventArgs e)
        {
            if (isEditFlight == false)
            {
                DialogResult confirm = MessageBox.Show("Bạn có chắc muốn sửa chuyến bay này?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {

                    dtpNgayGioBay.Value = Convert.ToDateTime(dgvChuyenBay.CurrentRow.Cells["NgayGioBay"].Value);
                    cbTinhTrang.Text = dgvChuyenBay.CurrentRow.Cells["TrangThai"].Value.ToString();

                    cbSanBayDi.Enabled = false;
                    cbSanBayDen.Enabled = false;
                    txtGiaCoBan.Enabled = false;
                    txtThoiGianBay.Enabled = false;
                    dgvChuyenBay.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDel.Enabled = false;
                    cbHangBay.Enabled = false;
                    cbAirplane.Enabled = false;
                    txtTimKiemChuyenBay.Enabled = false;

                    DataGridViewRow seatRow = dgvFareClass.Rows[1];
                    for (int i = 1; i < seatRow.Cells.Count; i++)
                    {
                        dgvFareClass.Rows[1].Cells[i].ReadOnly = true;
                    }

                    btnAddAirport.Enabled = false;
                    btnAddAirplane.Enabled = false;
                    btnEditClass.Enabled = false;
                    btnAddAirline.Enabled = false;
                    btnTim.Enabled = false;
                    btnNew.Enabled = false;

                    isEditFlight = true;
                }
            }

            else
            {
                try
                {
                    string MaChuyenBay = dgvChuyenBay.CurrentRow.Cells["MaChuyenBay"].Value.ToString();
                    FlightDAO.Instance.UpdateFlightSchedule(MaChuyenBay, dtpNgayGioBay.Value, cbTinhTrang.Text);
                    ReNew();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                cbSanBayDi.Enabled = true;
                cbSanBayDen.Enabled = true;
                txtGiaCoBan.Enabled = true;
                txtThoiGianBay.Enabled = true;
                cbTinhTrang.Enabled = true;
                btnAdd.Enabled = true;
                btnDel.Enabled = true;
                cbHangBay.Enabled = true;
                cbAirplane.Enabled = true;
                txtTimKiemChuyenBay.Enabled = true;

                DataGridViewRow seatRow = dgvFareClass.Rows[1];
                for (int i = 1; i < seatRow.Cells.Count; i++)
                {
                    dgvFareClass.Rows[1].Cells[i].ReadOnly = false;
                }

                btnAddAirport.Enabled = true;
                btnAddAirplane.Enabled = true;
                btnEditClass.Enabled = true;
                btnAddAirline.Enabled = true;
                btnTim.Enabled = true;
                btnNew.Enabled = true;
                dgvChuyenBay.Enabled = true;

                isEditFlight = false;
            }

        }
    }
}
