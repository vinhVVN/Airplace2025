using Airplace2025.BLL.DAO;
using Airplace2025.BLL.DTO;
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
    public partial class frmDoiChuyenBay: Form
    {
        public frmDoiChuyenBay(DataRow veHienTai)
        {
            InitializeComponent();
            _veHienTai = veHienTai;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAllAirline()
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maChuyenBayMoi))
            {
                MessageBox.Show("Vui lòng chọn chuyến bay mới.");
                return;
            }

            try
            {
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn đổi sang chuyến bay này? Hành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // GỌI SP ĐỂ THỰC HIỆN VÀ LẤY KẾT QUẢ CHÍNH XÁC
                    DataTable dtKetQua = FlightDAO.Instance.DoiChuyenBay(_veHienTai["MaVe"].ToString(), _maChuyenBayMoi, _selectedMaHangVeMoi);

                    if (dtKetQua.Rows.Count > 0)
                    {
                        // 1. Thông báo đổi chuyến thành công
                        MessageBox.Show("Đổi chuyến bay thành công! Vui lòng chọn lại ghế ngồi cho chuyến bay mới.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 2. CHUẨN BỊ DỮ LIỆU ĐỂ MỞ FORM CHỌN GHẾ

                        // A. Tạo thông tin khách hàng giả lập từ vé hiện tại
                        // (Vì form ChonGhe thiết kế cho list khách, nhưng ở đây ta chỉ đổi 1 vé)
                        var khachHang = new KhachHangDTO
                        {
                            MaKhachHang = _veHienTai["MaKhachHang"].ToString(), // Cần đảm bảo _veHienTai có cột này
                            HoTen = _veHienTai["HoTen"].ToString(),
                            // Các thông tin khác nếu cần
                        };
                        var listKhach = new List<KhachHangDTO> { khachHang };

                        // B. Tạo thông tin Chuyến bay mới
                        // Lấy thông tin chi tiết chuyến mới từ DB để truyền sang
                        DataTable dtFlightInfo = FlightDAO.Instance.GetFlightById(_maChuyenBayMoi);
                        // (Bạn cần viết hàm GetFlightById trong FlightDAO nếu chưa có)

                        if (dtFlightInfo.Rows.Count > 0)
                        {
                            DataRow flightRow = dtFlightInfo.Rows[0];
                            ChuyenBayDTO chuyenBayDto = new ChuyenBayDTO
                            {
                                MaChuyenBay = _maChuyenBayMoi,
                                MaSanBayDi = flightRow["MaSanBayDi"].ToString(),
                                MaSanBayDen = flightRow["MaSanBayDen"].ToString(),
                                NgayGioBay = Convert.ToDateTime(flightRow["NgayGioBay"]),
                                ThoiGianBay = Convert.ToInt32(flightRow["ThoiGianBay"]),
                                TenMayBay = flightRow["TenMayBay"].ToString(),
                                TenHangBay = flightRow["TenHangBay"].ToString(),
                                GiaCoBan = Convert.ToDecimal(flightRow["GiaCoBan"])
                            };

                            // 3. Khởi tạo SelectedFareInfo bằng CONSTRUCTOR (Không dùng Object Initializer)
                            // Thứ tự tham số: (ChuyenBayDTO flight, string cabinClass, decimal price)
                            var newFlightInfo = new SelectedFareInfo(
                                chuyenBayDto,           // Tham số 1: Đối tượng chuyến bay
                                _selectedMaHangVeMoi,   // Tham số 2: Hạng vé (VD: "ECO")
                                _selectedGiaMoi         // Tham số 3: Giá tiền
                            );

                            // 3. MỞ FORM CHỌN GHẾ
                            // Tham số thứ 3 là null vì đổi vé thường chỉ đổi 1 chiều tại 1 thời điểm
                            frmChonGhe frmSeat = new frmChonGhe(listKhach, newFlightInfo, null);

                            if (frmSeat.ShowDialog() == DialogResult.OK)
                            {
                                // 4. CẬP NHẬT MÃ GHẾ MỚI VÀO DB
                                string maGheMoi = listKhach[0].MaGheDi; // Lấy ghế vừa chọn

                                // Gọi hàm cập nhật ghế
                                TicketDAO.Instance.CapNhatGhe(
                                    _veHienTai["MaDatVe"].ToString(), // Mã Chi Tiết Đặt Vé
                                    maGheMoi
                                );

                                MessageBox.Show($"Đã cập nhật ghế ngồi mới: {maGheMoi}", "Hoàn tất");
                                LogDAO.Instance.GhiNhatKy("Đổi vé", $"Đổi vé {_veHienTai["MaVe"]} sang chuyến bay {_maChuyenBayMoi}");


                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private DataRow _veHienTai; // Dữ liệu của vé đang cần đổi
        private string _maChuyenBayMoi = "";
        private decimal _giaVeMoi = 0;
        private string _selectedMaHangVeMoi = "";
        private decimal _selectedGiaMoi = 0;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDi = cbSanBayDi.SelectedValue.ToString();
            string maDen = cbSanBayDen.SelectedValue.ToString();
            DateTime ngay = dtpNgayDi.Value.Date;

            DataTable dt = FlightDAO.Instance.SearchFlightsMatrix(maDi, maDen, ngay);

            // Gọi hàm load dữ liệu lên Grid thủ công để format đẹp
            LoadMatrixToGrid(dt);
        }

        private void LoadMatrixToGrid(DataTable dt)
        {
            dgvChuyenBayMoi.Rows.Clear();
            dgvChuyenBayMoi.Columns.Clear();

            // 1. Tạo các cột
            dgvChuyenBayMoi.Columns.Add("MaChuyenBay", "Chuyến bay");
            dgvChuyenBayMoi.Columns.Add("GioBay", "Giờ bay");

            // Cột Hạng vé (ButtonColumn hoặc TextBoxColumn tùy ý, ở đây dùng TextBox để hiện giá)
            var colEco = dgvChuyenBayMoi.Columns.Add("ECO", "Phổ thông");
            var colBus = dgvChuyenBayMoi.Columns.Add("BUS", "Thương gia");
            var colFir = dgvChuyenBayMoi.Columns.Add("FIR", "Hạng nhất");
            var colPre = dgvChuyenBayMoi.Columns.Add("PRE", "Phổ thông đặc biệt");

            // Định dạng cột
            dgvChuyenBayMoi.Columns["ECO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChuyenBayMoi.Columns["BUS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChuyenBayMoi.Columns["FIR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChuyenBayMoi.Columns["PRE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2. Đổ dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                int idx = dgvChuyenBayMoi.Rows.Add();
                DataGridViewRow gridRow = dgvChuyenBayMoi.Rows[idx];

                // Thông tin chung
                gridRow.Cells["MaChuyenBay"].Value = row["MaChuyenBay"] + "\n" + row["TenMayBay"];

                DateTime timeDi = Convert.ToDateTime(row["NgayGioBay"]);
                int duration = Convert.ToInt32(row["ThoiGianBay"]);
                DateTime timeDen = timeDi.AddMinutes(duration);
                gridRow.Cells["GioBay"].Value = $"{timeDi:HH:mm} - {timeDen:HH:mm}";

                // --- XỬ LÝ CỘT ECO ---
                int slEco = Convert.ToInt32(row["SL_ECO"]);
                decimal giaEco = Convert.ToDecimal(row["Gia_ECO"]);

                if (slEco > 0)
                {
                    gridRow.Cells["ECO"].Value = giaEco.ToString("N0");
                    gridRow.Cells["ECO"].Tag = giaEco; // Lưu giá thực vào Tag để tính toán
                }
                else
                {
                    gridRow.Cells["ECO"].Value = "Hết vé";
                    gridRow.Cells["ECO"].Style.ForeColor = Color.Red;
                    gridRow.Cells["ECO"].Style.BackColor = Color.LightGray;
                }

                // --- XỬ LÝ CỘT BUS ---
                int slBus = Convert.ToInt32(row["SL_BUS"]);
                decimal giaBus = Convert.ToDecimal(row["Gia_BUS"]);

                if (slBus > 0)
                {
                    gridRow.Cells["BUS"].Value = giaBus.ToString("N0");
                    gridRow.Cells["BUS"].Tag = giaBus;
                }
                else
                {
                    gridRow.Cells["BUS"].Value = "Hết vé";
                    gridRow.Cells["BUS"].Style.ForeColor = Color.Red;
                    gridRow.Cells["BUS"].Style.BackColor = Color.LightGray;
                }

                // --- XỬ LÝ CỘT PRE ---
                int slPre = Convert.ToInt32(row["SL_PRE"]);
                decimal giaPre = Convert.ToDecimal(row["Gia_PRE"]);

                if (slPre > 0)
                {
                    gridRow.Cells["PRE"].Value = giaPre.ToString("N0");
                    gridRow.Cells["PRE"].Tag = giaPre;
                }
                else
                {
                    gridRow.Cells["PRE"].Value = "Hết vé";
                    gridRow.Cells["PRE"].Style.ForeColor = Color.Red;
                    gridRow.Cells["PRE"].Style.BackColor = Color.LightGray;
                }

                // --- XỬ LÝ CỘT FIR ---
                int slFir = Convert.ToInt32(row["SL_FIR"]);
                decimal giaFir = Convert.ToDecimal(row["Gia_FIR"]);

                if (slPre > 0)
                {
                    gridRow.Cells["FIR"].Value = giaFir.ToString("N0");
                    gridRow.Cells["FIR"].Tag = giaFir;
                }
                else
                {
                    gridRow.Cells["FIR"].Value = "Hết vé";
                    gridRow.Cells["FIR"].Style.ForeColor = Color.Red;
                    gridRow.Cells["FIR"].Style.BackColor = Color.LightGray;
                }

                // 1. Đặt màu chữ mặc định cho toàn bộ lưới là ĐEN (hoặc màu tối)
                dgvChuyenBayMoi.DefaultCellStyle.ForeColor = Color.Black;

                // 2. Đặt màu chữ khi được chọn (Selected) cũng là ĐEN (để tránh bị đổi sang trắng khó đọc trên nền trắng)
                dgvChuyenBayMoi.DefaultCellStyle.SelectionForeColor = Color.Black;

                // 3. Đặt màu nền khi được chọn (SelectionBackColor) nhạt thôi để dễ nhìn
                dgvChuyenBayMoi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250); // Màu Lavender nhạt

                foreach (DataGridViewRow r in dgvChuyenBayMoi.Rows)
                {
                    if (r.Cells["ECO"].Value.ToString() == "Hết vé")
                    {
                        r.Cells["ECO"].Style.ForeColor = Color.Red;
                        r.Cells["ECO"].Style.SelectionForeColor = Color.Red; // Kể cả khi chọn dòng này, chữ vẫn đỏ
                    }

                    if (r.Cells["PRE"].Value.ToString() == "Hết vé")
                    {
                        r.Cells["PRE"].Style.ForeColor = Color.Red;
                        r.Cells["PRE"].Style.SelectionForeColor = Color.Red; // Kể cả khi chọn dòng này, chữ vẫn đỏ
                    }

                    if (r.Cells["FIR"].Value.ToString() == "Hết vé")
                    {
                        r.Cells["FIR"].Style.ForeColor = Color.Red;
                        r.Cells["FIR"].Style.SelectionForeColor = Color.Red; // Kể cả khi chọn dòng này, chữ vẫn đỏ
                    }

                    if (r.Cells["BUS"].Value.ToString() == "Hết vé")
                    {
                        r.Cells["BUS"].Style.ForeColor = Color.Red;
                        r.Cells["BUS"].Style.SelectionForeColor = Color.Red;
                    }
                }

                dgvChuyenBayMoi.ClearSelection();

                // Chỉnh chiều cao hàng cho dễ nhìn
                gridRow.Height = 50;
            }
        }

        private void dgvChuyenBayMoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Reset màu nền tất cả về trắng
            foreach (DataGridViewRow r in dgvChuyenBayMoi.Rows)
            {
                // Duyệt qua các cột hạng vé cần reset
                string[] cols = { "ECO", "BUS", "PRE", "FIR" };
                foreach (string cName in cols)
                {
                    if (dgvChuyenBayMoi.Columns.Contains(cName))
                    {
                        var cellCheck = r.Cells[cName];
                        if (cellCheck.Value.ToString() == "Hết vé")
                        {
                            cellCheck.Style.BackColor = Color.LightGray;
                            cellCheck.Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            cellCheck.Style.BackColor = Color.White;
                            cellCheck.Style.ForeColor = Color.Black; // Trả về màu đen bình thường
                        }
                    }
                }
            }

            // Lấy ô được click
            var cell = dgvChuyenBayMoi.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string columnName = dgvChuyenBayMoi.Columns[e.ColumnIndex].Name;

            // Chỉ xử lý nếu click vào cột hạng vé (ECO hoặc BUS)
            if (columnName == "ECO" || columnName == "BUS" || columnName == "PRE" || columnName == "FIR")
            {
                // Kiểm tra hết vé
                if (cell.Value.ToString() == "Hết vé")
                {
                    MessageBox.Show("Hạng vé này đã hết chỗ, vui lòng chọn hạng khác.");
                    return;
                }

                // --- HIỆU ỨNG CHỌN (Tô màu đỏ như hình) ---
                cell.Style.BackColor = Color.Firebrick;
                cell.Style.ForeColor = Color.White;

                // QUAN TRỌNG: Đặt SelectionBackColor trùng màu để khi nó đang focus vẫn thấy màu đỏ
                cell.Style.SelectionBackColor = Color.Firebrick;
                cell.Style.SelectionForeColor = Color.White;

                // --- LẤY DỮ LIỆU ---
                _maChuyenBayMoi = dgvChuyenBayMoi.Rows[e.RowIndex].Cells["MaChuyenBay"].Value.ToString().Split('\n')[0]; // Lấy mã chuyến
                _selectedMaHangVeMoi = columnName; // "ECO" hoặc "BUS"
                _selectedGiaMoi = Convert.ToDecimal(cell.Tag); // Lấy giá từ Tag

                // --- GỌI HÀM TÍNH TIỀN ---
                // Lưu ý: Sửa lại hàm TinhToanChiPhi để nhận tham số trực tiếp thay vì tự tính tỉ lệ
                // Vì giờ ta đã có giá cuối cùng rồi
                TinhToanChiPhi(_selectedGiaMoi);
            }
        }

        private void LoadSanBay()
        {
            cbSanBayDi.DataSource = AirportDAO.Instance.GetAirportList();
            cbSanBayDi.DisplayMember = "TenSanBay";
            cbSanBayDi.ValueMember = "MaSanBay";

            cbSanBayDen.DataSource = AirportDAO.Instance.GetAirportList();
            cbSanBayDen.DisplayMember = "TenSanBay";
            cbSanBayDen.ValueMember = "MaSanBay";

        }

        private void frmDoiChuyenBay_Load(object sender, EventArgs e)
        {
            // Chỉ cho phép chọn từng ô (Cell), không chọn cả dòng (FullRowSelect)
            dgvChuyenBayMoi.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Tắt chế độ MultiSelect để chỉ được chọn 1 ô duy nhất
            dgvChuyenBayMoi.MultiSelect = false;

            // Hiển thị thông tin vé cũ
            lbVeCu.Text = _veHienTai["MaVe"].ToString();
            lbChuyenBayCu.Text = _veHienTai["MaChuyenBay"].ToString();
            lbSanBay.Text = _veHienTai["MaSanBayDi"].ToString() + " - " + _veHienTai["MaSanBayDen"].ToString();
            lbGiaCu.Text = _veHienTai["GiaCoBan"].ToString();

            LoadSanBay();

            // Set mặc định tìm kiếm theo sân bay cũ của vé
            cbSanBayDi.SelectedValue = _veHienTai["MaSanBayDi"];
            cbSanBayDen.SelectedValue = _veHienTai["MaSanBayDen"];
        }

        private void TinhToanChiPhi(decimal giaCoBanMoi)
        {
            try
            {
                // 1. Lấy giá vé cũ
                decimal giaVeCu = 0;
                if (_veHienTai.Table.Columns.Contains("GiaVeThucTe"))
                {
                    giaVeCu = Convert.ToDecimal(_veHienTai["GiaVeThucTe"]);
                }
                else
                {
                    // Fallback nếu thiếu dữ liệu (để tránh crash)
                    giaVeCu = 0;
                }

                // 2. Tính chênh lệch giá vé (Giá mới - Giá cũ)
                decimal chenhLech = giaCoBanMoi - giaVeCu;
                if (chenhLech < 0)
                {
                    chenhLech = 0; // Không hoàn tiền thừa
                }

                // 3. Tính phí cố định (Nội địa 374k / Quốc tế 800k)
                decimal phiCoDinh = TinhPhiDoiCoDinh();

                // 4. Tổng tiền phải đóng
                decimal tongTien = chenhLech + phiCoDinh;

                // 5. Hiển thị lên giao diện

                // Hiển thị phí kèm chú thích loại phí
                string loaiPhi = (phiCoDinh == 800000) ? "(Quốc tế)" : "(Nội địa)";

                lbTongThu.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán: " + ex.Message);
            }
        }

        private decimal TinhPhiDoiCoDinh()
        {
            // Lấy mã sân bay đi/đến MỚI từ ComboBox
            string maDi = cbSanBayDi.SelectedValue.ToString();
            string maDen = cbSanBayDen.SelectedValue.ToString();

            // Gọi DAO để check quốc gia
            string quocGiaDi = AirportDAO.Instance.GetCountryByAirportCode(maDi);
            string quocGiaDen = AirportDAO.Instance.GetCountryByAirportCode(maDen);

            // Nếu cả đi và đến đều là VN -> Nội địa -> 374k
            if (quocGiaDi == "Việt Nam" && quocGiaDen == "Việt Nam")
            {
                return 374000;
            }

            // Ngược lại -> Quốc tế -> 800k
            return 800000;
        }



    }
}
