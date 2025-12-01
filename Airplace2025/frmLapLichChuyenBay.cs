using Airplace2025.BLL.DAO;
using Airplace2025.BLL.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            FlightLoadAll();
            SetupFlightPointsGrid();
        }

        private void FlightLoadAll()
        {
            dgvChuyenBay.DataSource = FlightDAO.Instance.SearchFlightByInfo(txtTimKiemChuyenBay.Text);
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
            List<object> tiLeGiaVeRow = new List<object> { "Tỉ Lệ Giá Vé" };
            List<object> soGheRow = new List<object> { "Số Ghế Tổng" };
            List<object> soGheConLaiRow = new List<object> { "Số Ghế Còn Lại" };


            foreach (DataRow row in dt.Rows)
            {
                tiLeGiaVeRow.Add(row["TiLeGiaHangVe"]);
                soGheRow.Add(0);
                soGheConLaiRow.Add(0);
            }
            dgvFareClass.Rows.Add(tiLeGiaVeRow.ToArray());
            dgvFareClass.Rows.Add(soGheRow.ToArray());
            dgvFareClass.Rows.Add(soGheConLaiRow.ToArray());

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
            // Khóa dòng tiêu đề và dòng tỷ lệ giá
            dgvFareClass.Rows[0].ReadOnly = true;
            dgvFareClass.Rows[1].ReadOnly = true;
            dgvFareClass.Rows[2].ReadOnly = true;
        }

        public void ThemTrungGian(string MaSanBay, string TenSanBay, 
                            int ThoiGianDung, int ThoiGianChuyen, string GhiChu)
        {



        }

        private void txtTimKiemChuyenBay_TextChanged(object sender, EventArgs e)
        {
            FlightLoadAll();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {


        }

        private void cbHangBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cbHangBay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbAirplane_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void cbAirplane_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


            

        private void btnTim_Click(object sender, EventArgs e)
        {
            
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ReNew()
        {
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
            

        }

        private void LoadFlightDetailToUI(string maChuyenBay)
        {
            // LOAD TRUNG GIAN (dgvTrungGian)
            dgvTrungGian.Rows.Clear();
            DataTable dtStops = StopDAO.Instance.GetStopsByFlight(maChuyenBay);
            foreach (DataRow row in dtStops.Rows)
            {
                dgvTrungGian.Rows.Add(
                    row["MaSanBay"],
                    row["ThuTu"],
                    row["TenSanBay"],
                    row["ThoiGianDung"],
                    row["ThoiGianChuyen"],
                    row["GhiChu"]
                );
                // Nếu DAO đã join lấy được TenSanBay thì thay row["MaSanBay"] thứ 2 bằng row["TenSanBay"]
            }

            // 2. LOAD HẠNG VÉ (dgvFareClass)
            DataTable dtClasses = ClassDAO.Instance.GetClassDetailByFlight(maChuyenBay);

            // Reset lại về 0 trước khi fill
            for (int i = 1; i < dgvFareClass.Columns.Count; i++)
            {
                dgvFareClass.Rows[1].Cells[i].Value = 0; // Dòng Số Ghế Tổng
                dgvFareClass.Rows[2].Cells[i].Value = 0; // Dòng Số Ghế Còn Lại
            }

            // Fill dữ liệu mới
            foreach (DataRow row in dtClasses.Rows)
            {
                string maHangVe = row["MaHangVe"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                int soLuongConLai = Convert.ToInt32(row["SoLuongConLai"]);

                // Tìm cột tương ứng với MaHangVe
                if (dgvFareClass.Columns.Contains(maHangVe))
                {
                    // Dòng 1: Số ghế tổng
                    dgvFareClass.Rows[1].Cells[maHangVe].Value = soLuong;

                    // Dòng 2: Số ghế còn lại
                    dgvFareClass.Rows[2].Cells[maHangVe].Value = soLuongConLai;
                }
            }
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            ofd.Title = "Chọn file Excel lịch bay";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Danh sách ghi lại các lỗi để báo cho người dùng
                List<string> errorLog = new List<string>();
                int successCount = 0;

                try
                {
                    // Cấu hình License cho EPPlus 8 (như đã sửa ở bài trước)
                    // Hoặc cấu hình trong App.config rồi thì bỏ dòng này
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Huynh Mai Cao Nhan");

                    using (var package = new ExcelPackage(new FileInfo(ofd.FileName)))
                    {
                        // Lấy Sheet đầu tiên
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        // Đếm số dòng có dữ liệu (bỏ qua dòng header)
                        int rowCount = worksheet.Dimension.End.Row;

                        if (rowCount < 2)
                        {
                            MessageBox.Show("File Excel không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // --- VÒNG LẶP ĐỌC TỪNG DÒNG ---
                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                // 1. ĐỌC DỮ LIỆU CƠ BẢN TỪ EXCEL
                                string maMayBay = GetString(worksheet, row, 1);
                                string sbDi = GetString(worksheet, row, 2);
                                string sbDen = GetString(worksheet, row, 3);
                                DateTime ngayGioBay = GetDateTime(worksheet, row, 4);
                                int thoiGianBay = GetInt(worksheet, row, 5);
                                decimal giaCoBan = GetDecimal(worksheet, row, 6);
                                string trangThai = GetString(worksheet, row, 19);

                                // Validation cơ bản (nếu thiếu thông tin quan trọng thì bỏ qua dòng này)
                                if (string.IsNullOrEmpty(maMayBay) || string.IsNullOrEmpty(sbDi) || string.IsNullOrEmpty(sbDen))
                                {
                                    throw new Exception("Thiếu thông tin Mã máy bay, Sân bay đi hoặc đến.");
                                }

                                // 2. GỌI SP THÊM CHUYẾN BAY
                                // Hàm InsertFlight gọi sp_ThemChuyenBay và trả về DataTable chứa dòng vừa thêm
                                DataTable dtResult = FlightDAO.Instance.InsertFlight(
                                    sbDi, sbDen, ngayGioBay, thoiGianBay, giaCoBan, maMayBay, trangThai
                                );

                                if (dtResult.Rows.Count > 0)
                                {
                                    // Lấy Mã Chuyến Bay vừa sinh ra (ví dụ: VJ1001)
                                    string newFlightId = dtResult.Rows[0]["MaChuyenBay"].ToString();

                                    // 3. THÊM CHI TIẾT HẠNG VÉ (Cột G, H)
                                    int slEco = GetInt(worksheet, row, 7);
                                    int slBus = GetInt(worksheet, row, 8);
                                    int slFir = GetInt(worksheet, row, 9);
                                    int slPre = GetInt(worksheet, row, 10);

                                    if (slEco > 0) ClassDAO.Instance.InsertClassInfo(newFlightId, "ECO", slEco, slEco);
                                    if (slBus > 0) ClassDAO.Instance.InsertClassInfo(newFlightId, "BUS", slBus, slBus);
                                    if (slFir > 0) ClassDAO.Instance.InsertClassInfo(newFlightId, "FIR", slFir, slFir);
                                    if (slPre > 0) ClassDAO.Instance.InsertClassInfo(newFlightId, "PRE", slPre, slPre);

                                    // 4. THÊM TRUNG GIAN 
                                    string tg1MaSanBay = GetString(worksheet, row, 11);
                                    if (!string.IsNullOrEmpty(tg1MaSanBay))
                                    {
                                        int tg1Dung = GetInt(worksheet, row, 12);
                                        int tg1Chuyen = GetInt(worksheet, row, 13);
                                        string tg1GhiChu = GetString(worksheet, row, 14);

                                        // Gọi SP Thêm Trung Gian
                                        StopDAO.Instance.InsertStop(newFlightId, tg1MaSanBay, 1, tg1Dung, tg1GhiChu, tg1Chuyen);

                                        string tg2MaSanBay = GetString(worksheet, row, 15);
                                        if (!string.IsNullOrEmpty(tg2MaSanBay))
                                        {
                                            int tg2Dung = GetInt(worksheet, row, 16);
                                            int tg2Chuyen = GetInt(worksheet, row, 17);
                                            string tg2GhiChu = GetString(worksheet, row, 18);

                                            // Gọi SP Thêm Trung Gian
                                            StopDAO.Instance.InsertStop(newFlightId, tg2MaSanBay, 2, tg2Dung, tg2GhiChu, tg2Chuyen);
                                        }
                                    }

                                    

                                    successCount++;
                                }
                            }
                            catch (Exception exRow)
                            {
                                // Nếu lỗi dòng nào, ghi lại dòng đó nhưng KHÔNG DỪNG chương trình
                                errorLog.Add($"Dòng {row}: {exRow.Message}");
                            }
                        }
                    }

                    // --- BÁO CÁO KẾT QUẢ ---
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Đã thêm thành công: {successCount} chuyến bay.");

                    if (errorLog.Count > 0)
                    {
                        sb.AppendLine($"\nCó {errorLog.Count} dòng bị lỗi:");
                        foreach (string err in errorLog)
                        {
                            sb.AppendLine(err);
                        }
                        MessageBox.Show(sb.ToString(), "Kết quả Import (Có lỗi)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(sb.ToString(), "Thành công rực rỡ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Tải lại danh sách hiển thị
                    ReNew();
                    FlightLoadAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetString(ExcelWorksheet ws, int row, int col)
        {
            var val = ws.Cells[row, col].Value;
            return val == null ? "" : val.ToString().Trim();
        }

        private int GetInt(ExcelWorksheet ws, int row, int col)
        {
            var val = ws.Cells[row, col].Value;
            if (val == null) return 0;
            if (int.TryParse(val.ToString(), out int result)) return result;
            return 0;
        }

        private decimal GetDecimal(ExcelWorksheet ws, int row, int col)
        {
            var val = ws.Cells[row, col].Value;
            if (val == null) return 0;
            if (decimal.TryParse(val.ToString(), out decimal result)) return result;
            return 0;
        }

        private DateTime GetDateTime(ExcelWorksheet ws, int row, int col)
        {
            var val = ws.Cells[row, col].Value;
            // EPPlus tự xử lý ngày tháng rất tốt nếu cell Excel đúng định dạng Date
            if (val is DateTime date) return date;

            // Nếu là chuỗi text, thử parse
            if (DateTime.TryParse(val?.ToString(), out DateTime result)) return result;

            return DateTime.Now; // Trả về Default nếu lỗi (hoặc bạn có thể throw exception)
        }

        private void dgvChuyenBay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Click vào header thì bỏ qua

            // Lấy MaChuyenBay của dòng được chọn
            if (dgvChuyenBay.CurrentRow != null)
            {
                string maChuyenBay = dgvChuyenBay.CurrentRow.Cells["MaChuyenBay"].Value.ToString();

                // Gọi hàm hiển thị chi tiết
                LoadFlightDetailToUI(maChuyenBay);
            }

            if (e.ColumnIndex == dgvChuyenBay.Columns["colList"].Index)
            {
                string maChuyenBay = dgvChuyenBay.CurrentRow.Cells["MaChuyenBay"].Value.ToString();
                frmXemDanhSach frm = new frmXemDanhSach(maChuyenBay);
                frm.ShowDialog();
            }
        }
    }
}
