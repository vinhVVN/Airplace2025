using Airplace2025.BLL.DTO;
using Airplace2025.BLL.DAO;
using Airplace2025.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmChonGhe : Form
    {
        // Input Data
        private List<KhachHangDTO> _customers; // All customers
        private List<KhachHangDTO> _passengersNeedingSeats; // Filtered list (Adults + Children)
        private SelectedFareInfo _departureFlight;
        private SelectedFareInfo _returnFlight;
        
        // State
        private bool _isSelectingReturn = false;
        private List<string> _bookedSeatsDeparture;
        private List<string> _bookedSeatsReturn;
        
        // Seat Configuration from Database
        private Dictionary<string, int> _seatConfigDeparture;
        private Dictionary<string, int> _seatConfigReturn;
        
        // Cabin class codes for the user's selected fare
        private string _depCabinCode;
        private string _retCabinCode;
        
        // Seat zone mapping: which rows belong to which cabin
        private Dictionary<int, string> _rowToCabinMapDep;
        private Dictionary<int, string> _rowToCabinMapRet;
        
        // Mapping: Passenger Index (in _passengersNeedingSeats) -> Seat Code
        // Key Format: "{Index}_{IsReturn}" (e.g., "0_False" for first passenger departure)
        private Dictionary<string, string> _selectedSeatsMap = new Dictionary<string, string>();
        
        private int _currentPassengerIndex = 0;
        
        // Container cho sơ đồ ghế - để căn giữa khi resize
        private Panel _seatMapContainer;
        private int _containerWidth = 420;

        // UI Constants
        private const int SEAT_SIZE = 40;
        private const int SEAT_MARGIN = 5;
        private Color COLOR_AVAILABLE = Color.White;
        private Color COLOR_OCCUPIED = Color.FromArgb(224, 224, 224); // Gray - Đã đặt
        private Color COLOR_SELECTED = Color.FromArgb(40, 167, 69); // Green - Đang chọn
        private Color COLOR_FIRST = Color.FromArgb(156, 39, 176); // Purple - Hạng nhất
        private Color COLOR_BUSINESS = Color.FromArgb(255, 193, 7); // Gold - Thương gia
        private Color COLOR_PREMIUM = Color.FromArgb(33, 150, 243); // Blue - Phổ thông đặc biệt
        private Color COLOR_ECONOMY = Color.FromArgb(144, 202, 249); // Light Blue - Phổ thông
        private Color COLOR_RESTRICTED = Color.FromArgb(180, 180, 180); // Không được chọn (khác hạng)
        
        public frmChonGhe(List<KhachHangDTO> customers, SelectedFareInfo depFlight, SelectedFareInfo retFlight = null)
        {
            InitializeComponent();
            _customers = customers;
            _departureFlight = depFlight;
            _returnFlight = retFlight;
        }

        private void frmChonGhe_Load(object sender, EventArgs e)
        {
            FilterPassengers();
            LoadSeatConfiguration();
            LoadBookedSeats();
            InitializeUI();
            RenderSeatMap();
            UpdatePassengerList();
        }

        /// <summary>
        /// Tải cấu hình ghế từ database và xác định mã hạng vé của người dùng
        /// </summary>
        private void LoadSeatConfiguration()
        {
            // Lấy cấu hình ghế chuyến đi
            if (_departureFlight?.Flight != null)
            {
                _seatConfigDeparture = ClassDAO.Instance.GetSeatConfiguration(_departureFlight.Flight.MaChuyenBay);
                _depCabinCode = ClassDAO.Instance.GetMaHangVeFromTenHangVe(_departureFlight.CabinClass);
                _rowToCabinMapDep = BuildRowToCabinMap(_seatConfigDeparture);
            }
            else
            {
                _seatConfigDeparture = new Dictionary<string, int>();
                _rowToCabinMapDep = new Dictionary<int, string>();
            }

            // Lấy cấu hình ghế chuyến về
            if (_returnFlight?.Flight != null)
            {
                _seatConfigReturn = ClassDAO.Instance.GetSeatConfiguration(_returnFlight.Flight.MaChuyenBay);
                _retCabinCode = ClassDAO.Instance.GetMaHangVeFromTenHangVe(_returnFlight.CabinClass);
                _rowToCabinMapRet = BuildRowToCabinMap(_seatConfigReturn);
            }
            else
            {
                _seatConfigReturn = new Dictionary<string, int>();
                _rowToCabinMapRet = new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// Xây dựng mapping từ số hàng -> mã hạng vé
        /// Ghế được phân bổ: FIR -> BUS -> PRE -> ECO (từ đầu máy bay)
        /// </summary>
        private Dictionary<int, string> BuildRowToCabinMap(Dictionary<string, int> seatConfig)
        {
            var rowMap = new Dictionary<int, string>();
            int currentRow = 1;

            // Thứ tự ưu tiên: FIR (Hạng nhất) -> BUS (Thương gia) -> PRE (Phổ thông ĐB) -> ECO (Phổ thông)
            string[] cabinOrder = { "FIR", "BUS", "PRE", "ECO" };
            int[] seatsPerRow = { 4, 4, 6, 6 }; // FIR: 2-2, BUS: 2-2, PRE: 3-3, ECO: 3-3

            for (int i = 0; i < cabinOrder.Length; i++)
            {
                string cabinCode = cabinOrder[i];
                if (seatConfig.ContainsKey(cabinCode) && seatConfig[cabinCode] > 0)
                {
                    int totalSeats = seatConfig[cabinCode];
                    int seatsInRow = seatsPerRow[i];
                    int rowsNeeded = (int)Math.Ceiling((double)totalSeats / seatsInRow);

                    for (int r = 0; r < rowsNeeded; r++)
                    {
                        rowMap[currentRow] = cabinCode;
                        currentRow++;
                    }
                }
            }

            return rowMap;
        }

        private void FilterPassengers()
        {
            _passengersNeedingSeats = new List<KhachHangDTO>();
            if (_departureFlight?.Flight == null) return;

            DateTime flightDate = _departureFlight.Flight.NgayGioBay;

            foreach (var cust in _customers)
            {
                // Infants (< 2 years) do not need separate seats
                if (!IsInfant(cust, flightDate))
                {
                    _passengersNeedingSeats.Add(cust);
                }
            }
        }

        private bool IsInfant(KhachHangDTO cust, DateTime flightDate)
        {
            if (!cust.NgaySinh.HasValue) return false;
            int age = flightDate.Year - cust.NgaySinh.Value.Year;
            if (flightDate < cust.NgaySinh.Value.AddYears(age)) age--;
            return age < 2;
        }

        private void LoadBookedSeats()
        {
            if (_departureFlight?.Flight != null)
                _bookedSeatsDeparture = DatVeDAO.Instance.GetBookedSeats(_departureFlight.Flight.MaChuyenBay);
            else
                _bookedSeatsDeparture = new List<string>();

            if (_returnFlight?.Flight != null)
                _bookedSeatsReturn = DatVeDAO.Instance.GetBookedSeats(_returnFlight.Flight.MaChuyenBay);
            else
                _bookedSeatsReturn = new List<string>();
        }

        private void InitializeUI()
        {
            // Setup Flight Info Header
            UpdateFlightHeader();
            
            // Setup Passenger ListBox
            lstPassengers.DisplayMember = "HoTen";
            lstPassengers.DrawMode = DrawMode.OwnerDrawFixed;
            lstPassengers.DrawItem += LstPassengers_DrawItem;
            lstPassengers.SelectedIndexChanged += LstPassengers_SelectedIndexChanged;
            
            // Switch Tab Buttons visibility
            btnChuyenDi.Visible = true;
            btnChuyenVe.Visible = (_returnFlight != null);
            
            // Xử lý căn giữa khi resize
            pnlSeatMap.Resize += (s, e) => CenterSeatMapContainer();
            
            SetActiveTab(false); // Start with Departure
        }

        private void UpdateFlightHeader()
        {
            var currentFlight = _isSelectingReturn ? _returnFlight?.Flight : _departureFlight?.Flight;
            var currentFare = _isSelectingReturn ? _returnFlight : _departureFlight;
            if (currentFlight == null) return;

            string type = _isSelectingReturn ? "CHUYẾN VỀ" : "CHUYẾN ĐI";
            string cabinClass = currentFare?.CabinClass ?? "Phổ thông";
            
            lblFlightTitle.Text = $"{type}: {currentFlight.MaSanBayDi} ➔ {currentFlight.MaSanBayDen}";
            lblFlightInfo.Text = $"{currentFlight.TenHangBay} • {currentFlight.TenMayBay} • {currentFlight.NgayGioBay:dd/MM/yyyy HH:mm} • Hạng: {cabinClass}";
        }

        private void SetActiveTab(bool isReturn)
        {
            _isSelectingReturn = isReturn;
            
            // Update Button Styles
            btnChuyenDi.BackColor = !isReturn ? Color.FromArgb(0, 120, 215) : Color.LightGray;
            btnChuyenDi.ForeColor = !isReturn ? Color.White : Color.Black;
            
            btnChuyenVe.BackColor = isReturn ? Color.FromArgb(0, 120, 215) : Color.LightGray;
            btnChuyenVe.ForeColor = isReturn ? Color.White : Color.Black;

            UpdateFlightHeader();
            RenderSeatMap();
            UpdatePassengerList();
            
            // Select first passenger automatically if not selected
            if (lstPassengers.Items.Count > 0)
                lstPassengers.SelectedIndex = 0;
        }

        private void RenderSeatMap()
        {
            pnlSeatMap.Controls.Clear();
            pnlSeatMap.AutoScroll = true;

            // Lấy cấu hình cho chuyến bay hiện tại
            var seatConfig = _isSelectingReturn ? _seatConfigReturn : _seatConfigDeparture;
            var rowToCabinMap = _isSelectingReturn ? _rowToCabinMapRet : _rowToCabinMapDep;
            var userCabinCode = _isSelectingReturn ? _retCabinCode : _depCabinCode;
            List<string> occupiedList = _isSelectingReturn ? _bookedSeatsReturn : _bookedSeatsDeparture;

            if (rowToCabinMap.Count == 0)
            {
                Label lblNoSeats = new Label
                {
                    Text = "Không có thông tin ghế cho chuyến bay này",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Red,
                    AutoSize = true,
                    Location = new Point(50, 50)
                };
                pnlSeatMap.Controls.Add(lblNoSeats);
                return;
            }

            int totalRows = rowToCabinMap.Keys.Max();

            // Định nghĩa vị trí cột cố định cho từng ghế
            // A, B, C | aisle | D, E, F
            Dictionary<string, int> letterToX = new Dictionary<string, int>
            {
                {"A", 50}, {"B", 100}, {"C", 150}, {"D", 230}, {"E", 280}, {"F", 330}
            };

            // Panel chứa toàn bộ sơ đồ ghế - căn giữa
            Panel mainContainer = new Panel
            {
                AutoSize = true,
                Padding = new Padding(20)
            };

            int yOffset = 20;

            // Vẽ tiêu đề cột - sử dụng vị trí cố định
            string[] colHeaders = { "A", "B", "C", "D", "E", "F" };
            foreach (string col in colHeaders)
            {
                Label lbl = new Label
                {
                    Text = col,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(letterToX[col], yOffset),
                    Size = new Size(SEAT_SIZE, 25)
                };
                mainContainer.Controls.Add(lbl);
            }
            yOffset += 35;

            string currentCabinSection = "";

            // Vẽ từng hàng ghế
            for (int row = 1; row <= totalRows; row++)
            {
                if (!rowToCabinMap.ContainsKey(row)) continue;

                string cabinCode = rowToCabinMap[row];

                // Thêm tiêu đề khu vực nếu đổi sang hạng mới
                if (cabinCode != currentCabinSection)
                {
                    currentCabinSection = cabinCode;
                    string cabinName = GetCabinDisplayName(cabinCode);
                    Color sectionColor = GetCabinColor(cabinCode);

                    // Separator & Label
                    Panel sectionHeader = new Panel
                    {
                        Location = new Point(10, yOffset),
                        Size = new Size(_containerWidth - 20, 30),
                        BackColor = sectionColor
                    };
                    Label sectionLabel = new Label
                    {
                        Text = $"═══ {cabinName.ToUpper()} ═══",
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        ForeColor = (cabinCode == "ECO" || cabinCode == "BUS" || cabinCode == "PRE") ? Color.Black : Color.White,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    sectionHeader.Controls.Add(sectionLabel);
                    mainContainer.Controls.Add(sectionHeader);
                    yOffset += 35;
                }

                // Số hàng
                Label rowLabel = new Label
                {
                    Text = row.ToString(),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(5, yOffset),
                    Size = new Size(40, SEAT_SIZE)
                };
                mainContainer.Controls.Add(rowLabel);

                // Xác định cấu hình ghế cho hạng này
                bool isWideConfig = (cabinCode == "FIR" || cabinCode == "BUS"); // 2-2 config
                string[] seatLetters = isWideConfig 
                    ? new[] { "A", "C", "D", "F" }  // 2-2: Bỏ B, E (ghế rộng hơn)
                    : new[] { "A", "B", "C", "D", "E", "F" }; // 3-3: Đủ ghế

                foreach (string letter in seatLetters)
                {
                    int seatX = letterToX[letter];
                    string seatCode = $"{row}{letter}";
                    bool isBooked = occupiedList.Contains(seatCode);
                    bool isSelected = IsSeatSelected(seatCode);
                    bool isUserCabin = (cabinCode == userCabinCode);

                    Button btnSeat = new Button
                    {
                        Text = "",
                        Tag = seatCode,
                        Size = new Size(SEAT_SIZE, SEAT_SIZE),
                        Location = new Point(seatX, yOffset),
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold)
                    };
                    btnSeat.FlatAppearance.BorderSize = 1;

                    // Xác định trạng thái và màu sắc
                    if (isBooked)
                    {
                        btnSeat.BackColor = COLOR_OCCUPIED;
                        btnSeat.Enabled = false;
                        btnSeat.Text = "X";
                        btnSeat.FlatAppearance.BorderColor = Color.Gray;
                    }
                    else if (isSelected)
                    {
                        btnSeat.BackColor = COLOR_SELECTED;
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Text = "✓";
                        btnSeat.FlatAppearance.BorderColor = Color.DarkGreen;
                    }
                    else if (!isUserCabin)
                    {
                        // Ghế thuộc hạng vé khác -> không được chọn
                        btnSeat.BackColor = COLOR_RESTRICTED;
                        btnSeat.Enabled = false;
                        btnSeat.FlatAppearance.BorderColor = Color.LightGray;
                    }
                    else
                    {
                        // Ghế trống trong hạng vé của người dùng
                        btnSeat.BackColor = GetCabinColor(cabinCode);
                        btnSeat.FlatAppearance.BorderColor = Color.DarkGray;
                        btnSeat.Click += BtnSeat_Click;
                    }

                    // Tooltip
                    ToolTip tt = new ToolTip();
                    string tooltipText = $"Ghế {seatCode} - {GetCabinDisplayName(cabinCode)}";
                    if (!isUserCabin && !isBooked)
                        tooltipText += "\n(Không thể chọn - Khác hạng vé)";
                    else if (isBooked)
                        tooltipText += "\n(Đã được đặt)";
                    tt.SetToolTip(btnSeat, tooltipText);

                    mainContainer.Controls.Add(btnSeat);
                }

                yOffset += SEAT_SIZE + SEAT_MARGIN;
            }

            // Legend ở cuối
            yOffset += 20;
            AddLegend(mainContainer, yOffset, userCabinCode);

            // Căn giữa mainContainer trong pnlSeatMap
            mainContainer.Size = new Size(_containerWidth, yOffset + 60);
            
            // Lưu tham chiếu để xử lý resize
            _seatMapContainer = mainContainer;
            
            // Tính toán vị trí để căn giữa
            CenterSeatMapContainer();
            
            pnlSeatMap.Controls.Add(mainContainer);
        }
        
        /// <summary>
        /// Căn giữa container sơ đồ ghế trong panel
        /// </summary>
        private void CenterSeatMapContainer()
        {
            if (_seatMapContainer == null) return;
            int centerX = Math.Max(0, (pnlSeatMap.ClientSize.Width - _containerWidth) / 2);
            _seatMapContainer.Location = new Point(centerX, _seatMapContainer.Location.Y);
        }

        /// <summary>
        /// Thêm chú thích màu sắc ghế
        /// </summary>
        private void AddLegend(Panel container, int yOffset, string userCabinCode)
        {
            int xOffset = 10;

            // Ghế đang chọn
            AddLegendItem(container, ref xOffset, yOffset, COLOR_SELECTED, "Đang chọn");
            // Ghế đã đặt
            AddLegendItem(container, ref xOffset, yOffset, COLOR_OCCUPIED, "Đã đặt");
            // Ghế không được chọn
            AddLegendItem(container, ref xOffset, yOffset, COLOR_RESTRICTED, "Khác hạng vé (không thể chọn)");
        }

        private void AddLegendItem(Panel container, ref int xOffset, int yOffset, Color color, string text)
        {
            Panel box = new Panel
            {
                Size = new Size(20, 20),
                Location = new Point(xOffset, yOffset),
                BackColor = color,
                BorderStyle = BorderStyle.FixedSingle
            };
            container.Controls.Add(box);

            Label lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(xOffset + 25, yOffset + 2)
            };
            container.Controls.Add(lbl);

            xOffset += 25 + lbl.PreferredWidth + 15;
        }

        /// <summary>
        /// Lấy tên hiển thị của hạng vé
        /// </summary>
        private string GetCabinDisplayName(string cabinCode)
        {
            switch (cabinCode)
            {
                case "FIR": return "Hạng nhất";
                case "BUS": return "Thương gia";
                case "PRE": return "Phổ thông đặc biệt";
                case "ECO": return "Phổ thông";
                default: return cabinCode;
            }
        }

        /// <summary>
        /// Lấy màu đại diện cho hạng vé
        /// </summary>
        private Color GetCabinColor(string cabinCode)
        {
            switch (cabinCode)
            {
                case "FIR": return COLOR_FIRST;
                case "BUS": return COLOR_BUSINESS;
                case "PRE": return COLOR_PREMIUM;
                case "ECO": return COLOR_ECONOMY;
                default: return COLOR_AVAILABLE;
            }
        }

        private bool IsSeatSelected(string seatCode)
        {
            string suffix = _isSelectingReturn ? "_Ret" : "_Dep";
            // Check if this seat code is assigned to any passenger in the current leg
            return _selectedSeatsMap.Values.Any(v => v == seatCode + suffix);
        }
        
        private string GetKey(int passengerIndex, bool isReturn)
        {
            return $"{passengerIndex}_" + (isReturn ? "Ret" : "Dep");
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string seatCode = btn.Tag.ToString();
            
            if (_currentPassengerIndex < 0 || _currentPassengerIndex >= _passengersNeedingSeats.Count)
            {
                MessageBox.Show("Vui lòng chọn hành khách trước.");
                return;
            }

            // Toggle Logic
            string key = GetKey(_currentPassengerIndex, _isSelectingReturn);
            string value = seatCode + (_isSelectingReturn ? "_Ret" : "_Dep");

            // If clicking the seat currently selected by this user -> Deselect
            if (_selectedSeatsMap.ContainsKey(key) && _selectedSeatsMap[key] == value)
            {
                _selectedSeatsMap.Remove(key);
            }
            else
            {
                // If this seat is selected by ANOTHER user -> Deselect that user first
                var existingOwner = _selectedSeatsMap.FirstOrDefault(x => x.Value == value).Key;
                if (existingOwner != null)
                {
                    MessageBox.Show($"Ghế {seatCode} đã được chọn cho hành khách khác.");
                    return;
                }

                // Assign
                _selectedSeatsMap[key] = value;
            }

            // Redraw
            RenderSeatMap();
            lstPassengers.Refresh(); 
            
            // Auto-advance
            if (_selectedSeatsMap.ContainsKey(key))
            {
                int nextIdx = _currentPassengerIndex + 1;
                if (nextIdx < _passengersNeedingSeats.Count)
                {
                    string nextKey = GetKey(nextIdx, _isSelectingReturn);
                    if (!_selectedSeatsMap.ContainsKey(nextKey))
                    {
                        lstPassengers.SelectedIndex = nextIdx;
                    }
                }
            }
        }

        private void UpdatePassengerList()
        {
            lstPassengers.Items.Clear();
            // Only show passengers who need seats
            foreach (var cust in _passengersNeedingSeats)
            {
                lstPassengers.Items.Add(cust);
            }
        }

        private void LstPassengers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            
            // Only drawing passengers needing seats
            var cust = _passengersNeedingSeats[e.Index];
            string key = GetKey(e.Index, _isSelectingReturn);
            bool hasSeat = _selectedSeatsMap.ContainsKey(key);
            string seatInfo = hasSeat ? $" - Ghế: {_selectedSeatsMap[key].Split('_')[0]}" : "";
            string text = $"{cust.HoTen}{seatInfo}";

            Brush brush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                brush = Brushes.White;
            
            e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            
            if (hasSeat)
            {
                e.Graphics.DrawString("✓", e.Font, Brushes.Green, e.Bounds.Right - 20, e.Bounds.Top);
            }

            e.DrawFocusRectangle();
        }

        private void LstPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPassengerIndex = lstPassengers.SelectedIndex;
        }

        private void btnChuyenDi_Click(object sender, EventArgs e)
        {
            SetActiveTab(false);
        }

        private void btnChuyenVe_Click(object sender, EventArgs e)
        {
            SetActiveTab(true);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validation: Check if all passengers needing seats have selected a seat
            for (int i = 0; i < _passengersNeedingSeats.Count; i++)
            {
                string key = GetKey(i, false);
                if (!_selectedSeatsMap.ContainsKey(key))
                {
                    MessageBox.Show($"Chuyến đi: Chưa chọn ghế cho hành khách {_passengersNeedingSeats[i].HoTen}");
                    SetActiveTab(false);
                    return;
                }
            }

            if (_returnFlight != null)
            {
                for (int i = 0; i < _passengersNeedingSeats.Count; i++)
                {
                    string key = GetKey(i, true);
                    if (!_selectedSeatsMap.ContainsKey(key))
                    {
                        MessageBox.Show($"Chuyến về: Chưa chọn ghế cho hành khách {_passengersNeedingSeats[i].HoTen}");
                        SetActiveTab(true);
                        return;
                    }
                }
            }

            // Update DTOs with selected seats
            for (int i = 0; i < _passengersNeedingSeats.Count; i++)
            {
                var cust = _passengersNeedingSeats[i];
                
                string keyDep = GetKey(i, false);
                if (_selectedSeatsMap.ContainsKey(keyDep))
                    cust.MaGheDi = _selectedSeatsMap[keyDep].Split('_')[0];

                if (_returnFlight != null)
                {
                    string keyRet = GetKey(i, true);
                    if (_selectedSeatsMap.ContainsKey(keyRet))
                        cust.MaGheVe = _selectedSeatsMap[keyRet].Split('_')[0];
                }
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
