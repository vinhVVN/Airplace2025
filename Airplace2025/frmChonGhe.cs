using Airplace2025.BLL.DTO;
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
        private List<KhachHangDTO> _customers;
        private SelectedFareInfo _departureFlight;
        private SelectedFareInfo _returnFlight;
        
        // State
        private bool _isSelectingReturn = false;
        private List<string> _bookedSeatsDeparture;
        private List<string> _bookedSeatsReturn;
        
        // Mapping: Passenger ID -> Seat Code
        // We use a specialized Dictionary Key: "{PassengerIndex}_{IsReturn}"
        private Dictionary<string, string> _selectedSeatsMap = new Dictionary<string, string>();
        
        private int _currentPassengerIndex = 0;

        // UI Constants
        private const int SEAT_SIZE = 40;
        private const int SEAT_MARGIN = 5;
        private Color COLOR_AVAILABLE = Color.White;
        private Color COLOR_OCCUPIED = Color.FromArgb(224, 224, 224); // Gray
        private Color COLOR_SELECTED = Color.FromArgb(40, 167, 69); // Green
        private Color COLOR_BUSINESS = Color.FromArgb(255, 193, 7); // Gold
        
        public frmChonGhe(List<KhachHangDTO> customers, SelectedFareInfo depFlight, SelectedFareInfo retFlight = null)
        {
            InitializeComponent();
            _customers = customers;
            _departureFlight = depFlight;
            _returnFlight = retFlight;
        }

        private void frmChonGhe_Load(object sender, EventArgs e)
        {
            LoadBookedSeats();
            InitializeUI();
            RenderSeatMap();
            UpdatePassengerList();
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
            
            SetActiveTab(false); // Start with Departure
        }

        private void UpdateFlightHeader()
        {
            var currentFlight = _isSelectingReturn ? _returnFlight?.Flight : _departureFlight?.Flight;
            if (currentFlight == null) return;

            string type = _isSelectingReturn ? "CHUYẾN VỀ" : "CHUYẾN ĐI";
            lblFlightTitle.Text = $"{type}: {currentFlight.MaSanBayDi} ➔ {currentFlight.MaSanBayDen}";
            lblFlightInfo.Text = $"{currentFlight.TenHangBay} • {currentFlight.TenMayBay} • {currentFlight.NgayGioBay:dd/MM/yyyy HH:mm}";
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

            // Determine Config based on Aircraft or Random logic simulation
            // A320/A321: 3-3 (ABC-DEF). Rows 1-30.
            // Business usually rows 1-3 (2-2 AC-DF).
            
            int rows = 30;
            bool hasBusiness = true;
            
            // Mock logic for seat generation
            TableLayoutPanel table = new TableLayoutPanel();
            table.AutoSize = true;
            table.Padding = new Padding(20);
            table.ColumnCount = 7; // A B C - aisle - D E F
            
            // Add Column Styles (Seats fixed width, Aisle flexible)
            for (int i = 0; i < 7; i++)
            {
                if (i == 3) // Aisle
                    table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
                else
                    table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            }

            // Add Headers
            string[] cols = { "A", "B", "C", "", "D", "E", "F" };
            for (int c = 0; c < 7; c++)
            {
                if (string.IsNullOrEmpty(cols[c]))
                {
                    table.Controls.Add(new Label(), c, 0);
                }
                else
                {
                    Label lbl = new Label
                    {
                        Text = cols[c],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Dock = DockStyle.Fill
                    };
                    table.Controls.Add(lbl, c, 0);
                }
            }

            // Add Seats
            List<string> occupiedList = _isSelectingReturn ? _bookedSeatsReturn : _bookedSeatsDeparture;
            string currentCabin = _isSelectingReturn ? _returnFlight.CabinClass : _departureFlight.CabinClass;
            bool isUserBusiness = currentCabin.Contains("Thương gia") || currentCabin.Contains("Business");

            for (int r = 1; r <= rows; r++)
            {
                // Row Label? Ideally we add a row number column on both sides, but keep it simple
                
                bool isBusinessRow = r <= 3;
                // If business row, simulation 2-2 config (AC-DF)
                
                for (int c = 0; c < 7; c++)
                {
                    if (c == 3) continue; // Aisle

                    // Map column index to letter
                    string colLetter = cols[c];
                    string seatCode = $"{r}{colLetter}";

                    // Skip B and E in business rows (simulating wider seats)
                    if (isBusinessRow && (colLetter == "B" || colLetter == "E"))
                        continue;

                    Button btnSeat = new Button();
                    btnSeat.Text = ""; // Only show if selected? Or Seat Code tooltip
                    btnSeat.Tag = seatCode;
                    btnSeat.Size = new Size(SEAT_SIZE, SEAT_SIZE);
                    btnSeat.Margin = new Padding(SEAT_MARGIN);
                    btnSeat.FlatStyle = FlatStyle.Flat;
                    btnSeat.FlatAppearance.BorderSize = 1;
                    
                    // Determine Status
                    bool isBooked = occupiedList.Contains(seatCode);
                    bool isSelected = IsSeatSelected(seatCode);
                    
                    if (isBooked)
                    {
                        btnSeat.BackColor = COLOR_OCCUPIED;
                        btnSeat.Enabled = false;
                        btnSeat.Text = "X";
                    }
                    else if (isSelected)
                    {
                        btnSeat.BackColor = COLOR_SELECTED;
                        btnSeat.ForeColor = Color.White;
                        btnSeat.Text = "✓";
                    }
                    else
                    {
                        // Check class restriction
                        // If User is Eco, cannot pick Business
                        // If User is Bus, can pick Business (and usually Eco too)
                        
                        if (isBusinessRow)
                        {
                            btnSeat.BackColor = COLOR_BUSINESS;
                            if (!isUserBusiness) btnSeat.Enabled = false; // Eco cant pick Bus
                        }
                        else
                        {
                            btnSeat.BackColor = COLOR_AVAILABLE;
                            // If business user wants eco seat? Allowed.
                        }
                    }

                    btnSeat.Click += BtnSeat_Click;
                    
                    // Tooltip
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(btnSeat, $"Ghế {seatCode}" + (isBusinessRow ? " (Thương gia)" : ""));

                    table.Controls.Add(btnSeat, c, r);
                }
            }
            
            pnlSeatMap.Controls.Add(table);
        }

        private bool IsSeatSelected(string seatCode)
        {
            // Check if this seat is in the values of the dictionary for the current Flight Direction
            string suffix = _isSelectingReturn ? "_Ret" : "_Dep";
            return _selectedSeatsMap.Values.Any(v => v == seatCode + suffix);
        }
        
        private string GetSeatForCurrentPassenger()
        {
            if (_currentPassengerIndex < 0 || _currentPassengerIndex >= _customers.Count) return null;
            
            string key = GetKey(_currentPassengerIndex, _isSelectingReturn);
            if (_selectedSeatsMap.ContainsKey(key))
            {
                // Value format: "12A_Dep"
                string val = _selectedSeatsMap[key];
                return val.Split('_')[0];
            }
            return null;
        }

        private string GetKey(int passengerIndex, bool isReturn)
        {
            return $"{passengerIndex}_" + (isReturn ? "Ret" : "Dep");
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string seatCode = btn.Tag.ToString();
            
            if (_currentPassengerIndex < 0 || _currentPassengerIndex >= _customers.Count)
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
                    // Steal seat? Or warn? Let's steal it for better UX (assume user knows what they do)
                    // Or simpler: block it.
                    MessageBox.Show($"Ghế {seatCode} đã được chọn cho hành khách khác.");
                    return;
                }

                // Assign
                _selectedSeatsMap[key] = value;
            }

            // Redraw
            RenderSeatMap();
            lstPassengers.Refresh(); // Update checkmarks
            
            // Auto-advance to next passenger if available and hasn't selected yet
            if (_selectedSeatsMap.ContainsKey(key)) // If we just selected (not deselected)
            {
                int nextIdx = _currentPassengerIndex + 1;
                if (nextIdx < _customers.Count)
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
            foreach (var cust in _customers)
            {
                lstPassengers.Items.Add(cust);
            }
        }

        private void LstPassengers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            
            var cust = _customers[e.Index];
            string key = GetKey(e.Index, _isSelectingReturn);
            bool hasSeat = _selectedSeatsMap.ContainsKey(key);
            string seatInfo = hasSeat ? $" - Ghế: {_selectedSeatsMap[key].Split('_')[0]}" : "";
            string text = $"{cust.HoTen}{seatInfo}";

            Brush brush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                brush = Brushes.White;
            
            e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            
            // Draw Checkmark if selected
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
            // Validation
            // Check Departure Seats
            for (int i = 0; i < _customers.Count; i++)
            {
                string key = GetKey(i, false);
                if (!_selectedSeatsMap.ContainsKey(key))
                {
                    MessageBox.Show($"Chuyến đi: Chưa chọn ghế cho hành khách {_customers[i].HoTen}");
                    SetActiveTab(false);
                    return;
                }
            }

            // Check Return Seats (if applicable)
            if (_returnFlight != null)
            {
                for (int i = 0; i < _customers.Count; i++)
                {
                    string key = GetKey(i, true);
                    if (!_selectedSeatsMap.ContainsKey(key))
                    {
                        MessageBox.Show($"Chuyến về: Chưa chọn ghế cho hành khách {_customers[i].HoTen}");
                        SetActiveTab(true);
                        return;
                    }
                }
            }

            // Save data to Customer Objects (InMemory hack since DTO fields might be missing or we use Tag)
            // Better: Return the dictionary or attach to DTO.
            // Since we can't easily modify DTO structure in this context without seeing it, 
            // let's attach to Tag or use a static helper, or just rely on the map being public.
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        // Helper method to retrieve results
        public Dictionary<string, string> GetSelectedSeats()
        {
            return _selectedSeatsMap;
        }
        
        // Helper to inject into DTO (if we assume properties exist or we add them dynamically? No, can't add dynamically)
        // We will rely on frmShoppingCart asking this form for the data.
    }
}
