using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Airplace2025.DAL;
using Airplace2025.BLL.DTO;

namespace Airplace2025
{
    /// <summary>
    /// Form để chọn ghế trực quan dựa trên layout máy bay
    /// </summary>
    public partial class frmSeatSelection : Form
    {
        private const int SEAT_SIZE = 35;
        private const int SEAT_SPACING = 4;
        private const int AISLE_WIDTH = 15;
        private const int ROWS_PER_PAGE = 20;

        // Seat data: [row][col] = status (0=available, 1=selected, 2=taken)
        private int[,] seatStatus;
        private Button[,] seatButtons;
        private string selectedSeat = "";
        private string maChuyenBay = "";
        private string selectedServiceClass = "";
        private List<string> bookedSeats = new List<string>();
        private Dictionary<string, int> seatCountByClass = new Dictionary<string, int>();
        
        // Service class mapping
        private Dictionary<string, string> serviceClassMapping = new Dictionary<string, string>
        {
            { "Phổ thông", "ECO" },
            { "Phổ thông đặc biệt", "PRE" },
            { "Thương gia", "BUS" },
            { "Hạng nhất", "FIR" }
        };

        public string SelectedSeat { get { return selectedSeat; } }

        // Aircraft config
        private int totalRows = 30;
        private int seatsPerRow = 6; // A B C [aisle] D E F
        private int currentPage = 0;
        private int totalPages = 0;
        
        // Validation flags
        private bool isInitialized = false;
        private bool hasError = false;

        public frmSeatSelection()
        {
            InitializeComponent();
        }

        public frmSeatSelection(int numRows = 30, int seatsPerRow = 6, string maChuyenBay = null, string serviceClass = null)
        {
            InitializeComponent();
            
            // Validate input parameters
            if (!ValidateInputParameters(numRows, seatsPerRow, maChuyenBay, serviceClass))
            {
                hasError = true;
                return;
            }
            
            this.totalRows = numRows;
            this.seatsPerRow = seatsPerRow;
            this.maChuyenBay = maChuyenBay;
            this.selectedServiceClass = NormalizeServiceClass(serviceClass);

            // Load aircraft configuration and booked seats
            LoadAircraftConfiguration();
        }
        
        /// <summary>
        /// Validate input parameters
        /// </summary>
        private bool ValidateInputParameters(int numRows, int seatsPerRow, string maChuyenBay, string serviceClass)
        {
            if (numRows <= 0 || numRows > 100)
            {
                MessageBox.Show("Số hàng ghế không hợp lệ (1-100)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (seatsPerRow <= 0 || seatsPerRow > 12)
            {
                MessageBox.Show("Số ghế mỗi hàng không hợp lệ (1-12)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(maChuyenBay))
            {
                MessageBox.Show("Mã chuyến bay không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
        
        /// <summary>
        /// Normalize service class name to internal code
        /// </summary>
        private string NormalizeServiceClass(string serviceClass)
        {
            if (string.IsNullOrEmpty(serviceClass))
                return null;
                
            // Try to find mapping
            foreach (var mapping in serviceClassMapping)
            {
                if (serviceClass.Contains(mapping.Key))
                {
                    return mapping.Value;
                }
            }
            
            // If no mapping found, try direct match
            string upperClass = serviceClass.ToUpper();
            if (upperClass.Contains("ECO") || upperClass.Contains("PHỔ THÔNG"))
                return "ECO";
            else if (upperClass.Contains("PRE") || upperClass.Contains("ĐẶC BIỆT"))
                return "PRE";
            else if (upperClass.Contains("BUS") || upperClass.Contains("THƯƠNG GIA"))
                return "BUS";
            else if (upperClass.Contains("FIR") || upperClass.Contains("HẠNG NHẤT"))
                return "FIR";
                
            return serviceClass.ToUpper();
        }

        private void frmSeatSelection_Load(object sender, EventArgs e)
        {
            // Check if there was an error during initialization
            if (hasError)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            
            try
            {
                InitializeSeats();
                DrawSeatMap();
                SetupPagination();
                isInitialized = true;
                
                // Debug information
                System.Diagnostics.Debug.WriteLine($"Form loaded successfully - Total rows: {totalRows}, Seats per row: {seatsPerRow}");
                System.Diagnostics.Debug.WriteLine($"Selected service class: {selectedServiceClass ?? "None"}");
                System.Diagnostics.Debug.WriteLine($"Booked seats count: {bookedSeats.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form chọn ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Load aircraft configuration from database
        /// </summary>
        private void LoadAircraftConfiguration()
        {
            if (string.IsNullOrEmpty(maChuyenBay))
            {
                System.Diagnostics.Debug.WriteLine("No flight code provided, using default configuration");
                return;
            }

            try
            {
                // Load booked seats
                bookedSeats = KhachHangDAO.Instance.GetBookedSeats(maChuyenBay);
                System.Diagnostics.Debug.WriteLine($"Loaded {bookedSeats.Count} booked seats for flight {maChuyenBay}");

                // Load seat count by service class
                LoadSeatCountByClass();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading aircraft configuration: {ex.Message}");
                MessageBox.Show($"Lỗi tải cấu hình máy bay: {ex.Message}\nSẽ sử dụng cấu hình mặc định.", 
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bookedSeats = new List<string>();
                LoadDefaultSeatConfiguration();
            }
        }
        
        /// <summary>
        /// Load default seat configuration when database fails
        /// </summary>
        private void LoadDefaultSeatConfiguration()
        {
            seatCountByClass["ECO"] = totalRows * seatsPerRow;
            seatCountByClass["PRE"] = 0;
            seatCountByClass["BUS"] = 0;
            seatCountByClass["FIR"] = 0;
            System.Diagnostics.Debug.WriteLine("Using default seat configuration");
        }

        /// <summary>
        /// Load seat count by service class from database
        /// </summary>
        private void LoadSeatCountByClass()
        {
            try
            {
                // Initialize with default values first
                LoadDefaultSeatConfiguration();

                if (string.IsNullOrEmpty(maChuyenBay))
                    return;

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LayChiTietMayBay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                seatCountByClass["ECO"] = reader["SoGheEconomy"] != DBNull.Value ? Convert.ToInt32(reader["SoGheEconomy"]) : totalRows * seatsPerRow;
                                seatCountByClass["PRE"] = reader["SoGhePremium"] != DBNull.Value ? Convert.ToInt32(reader["SoGhePremium"]) : 0;
                                seatCountByClass["BUS"] = reader["SoGheBusiness"] != DBNull.Value ? Convert.ToInt32(reader["SoGheBusiness"]) : 0;
                                seatCountByClass["FIR"] = reader["SoGheFirst"] != DBNull.Value ? Convert.ToInt32(reader["SoGheFirst"]) : 0;
                                
                                // Validate seat counts
                                ValidateSeatCounts();
                            }
                        }
                    }
                }
                
                // Debug logging
                System.Diagnostics.Debug.WriteLine($"Seat counts loaded: ECO={seatCountByClass["ECO"]}, PRE={seatCountByClass["PRE"]}, BUS={seatCountByClass["BUS"]}, FIR={seatCountByClass["FIR"]}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading seat counts: {ex.Message}");
                LoadDefaultSeatConfiguration();
            }
        }
        
        /// <summary>
        /// Validate seat counts to ensure they make sense
        /// </summary>
        private void ValidateSeatCounts()
        {
            int totalConfiguredSeats = seatCountByClass["ECO"] + seatCountByClass["PRE"] + seatCountByClass["BUS"] + seatCountByClass["FIR"];
            int totalPossibleSeats = totalRows * seatsPerRow;
            
            if (totalConfiguredSeats > totalPossibleSeats)
            {
                System.Diagnostics.Debug.WriteLine($"Warning: Configured seats ({totalConfiguredSeats}) exceed total possible seats ({totalPossibleSeats})");
                // Adjust economy seats to fit
                seatCountByClass["ECO"] = Math.Max(0, totalPossibleSeats - seatCountByClass["PRE"] - seatCountByClass["BUS"] - seatCountByClass["FIR"]);
            }
        }

        /// <summary>
        /// Initialize seat status array and buttons
        /// </summary>
        private void InitializeSeats()
        {
            // Calculate total pages based on rows per page
            totalPages = (int)Math.Ceiling((double)totalRows / ROWS_PER_PAGE);
            
            seatStatus = new int[totalRows, seatsPerRow];
            seatButtons = new Button[totalRows, seatsPerRow];

            // Initialize all seats as available (0)
            for (int r = 0; r < totalRows; r++)
            {
                for (int c = 0; c < seatsPerRow; c++)
                {
                    seatStatus[r, c] = 0; // All available by default
                }
            }

            // Mark booked seats as taken (2)
            foreach (string seatLabel in bookedSeats)
            {
                // Parse seat label (e.g., "12A" -> row 11, col 0)
                if (ParseSeatLabel(seatLabel, out int row, out int col))
                {
                    if (row >= 0 && row < totalRows && col >= 0 && col < seatsPerRow)
                    {
                        seatStatus[row, col] = 2; // Taken
                    }
                }
            }
        }

        /// <summary>
        /// Parse seat label to row and column indices
        /// </summary>
        private bool ParseSeatLabel(string seatLabel, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (string.IsNullOrEmpty(seatLabel) || seatLabel.Length < 2)
                return false;

            try
            {
                // Extract row number (e.g., "12" from "12A")
                string rowStr = seatLabel.Substring(0, seatLabel.Length - 1);
                if (!int.TryParse(rowStr, out int rowNumber))
                    return false;

                row = rowNumber - 1; // Convert to 0-based index

                // Extract column letter (e.g., "A" from "12A")
                char colChar = seatLabel[seatLabel.Length - 1];
                col = colChar - 'A'; // A=0, B=1, C=2, etc.

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Draw seat map UI with pagination support
        /// </summary>
        private void DrawSeatMap()
        {
            try
            {
                // Clear existing controls
                this.Controls.Clear();
                this.Controls.Add(lblSelected); // Keep the selected seat label

                // Create main panel for seat map
                Panel pnlMain = new Panel();
                pnlMain.Location = new Point(10, 40);
                pnlMain.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 140);
                pnlMain.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlMain);

                // Create scrollable panel for seats
                Panel pnlSeats = new Panel();
                pnlSeats.AutoScroll = true;
                pnlSeats.Location = new Point(5, 5);
                pnlSeats.Size = new Size(pnlMain.Width - 10, pnlMain.Height - 10);
                pnlSeats.BorderStyle = BorderStyle.None;
                pnlMain.Controls.Add(pnlSeats);

                // Calculate seat layout based on service class
                int startRow = currentPage * ROWS_PER_PAGE;
                int endRow = Math.Min(startRow + ROWS_PER_PAGE, totalRows);
                int rowsToShow = endRow - startRow;

                // Calculate panel dimensions
                int panelWidth = (seatsPerRow * (SEAT_SIZE + SEAT_SPACING)) + AISLE_WIDTH + 20;
                int panelHeight = (rowsToShow * (SEAT_SIZE + SEAT_SPACING)) + 50;

                pnlSeats.AutoScrollMinSize = new Size(panelWidth, panelHeight);

                // Draw seat labels (A, B, C, D, E, F)
                DrawSeatColumnLabels(pnlSeats, rowsToShow);

                // Draw seats for current page
                for (int r = startRow; r < endRow; r++)
                {
                    for (int c = 0; c < seatsPerRow; c++)
                    {
                        int displayRow = r - startRow;
                        int x = 30 + (c * (SEAT_SIZE + SEAT_SPACING)) + (c >= seatsPerRow / 2 ? AISLE_WIDTH : 0);
                        int y = 30 + (displayRow * (SEAT_SIZE + SEAT_SPACING));

                        Button btnSeat = new Button();
                        btnSeat.Tag = $"{r},{c}";
                        btnSeat.Width = SEAT_SIZE;
                        btnSeat.Height = SEAT_SIZE;
                        btnSeat.Location = new Point(x, y);
                        btnSeat.Font = new Font("Arial", 7, FontStyle.Bold);
                        btnSeat.Text = GetSeatLabel(r, c);
                        btnSeat.Cursor = Cursors.Hand;

                        // Set color based on status and service class
                        UpdateSeatColor(btnSeat, seatStatus[r, c], r, c);

                        btnSeat.Click += BtnSeat_Click;

                        seatButtons[r, c] = btnSeat;
                        pnlSeats.Controls.Add(btnSeat);
                    }
                }

                // Add legend and controls
                DrawLegendAndControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi vẽ seat map: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Draw seat column labels (A, B, C, D, E, F)
        /// </summary>
        private void DrawSeatColumnLabels(Panel parent, int rowsToShow)
        {
            for (int c = 0; c < seatsPerRow; c++)
            {
                int x = 30 + (c * (SEAT_SIZE + SEAT_SPACING)) + (c >= seatsPerRow / 2 ? AISLE_WIDTH : 0);
                
                Label lblCol = new Label();
                lblCol.Text = ((char)('A' + c)).ToString();
                lblCol.Location = new Point(x + SEAT_SIZE/2 - 5, 5);
                lblCol.Size = new Size(10, 15);
                lblCol.Font = new Font("Arial", 8, FontStyle.Bold);
                lblCol.TextAlign = ContentAlignment.MiddleCenter;
                parent.Controls.Add(lblCol);
            }
        }

        /// <summary>
        /// Draw legend and control buttons
        /// </summary>
        private void DrawLegendAndControls()
        {
            // Add legend
            Panel pnlLegend = new Panel();
            pnlLegend.Location = new Point(10, this.ClientSize.Height - 100);
            pnlLegend.Size = new Size(this.ClientSize.Width - 20, 40);
            pnlLegend.BorderStyle = BorderStyle.FixedSingle;
            pnlLegend.BackColor = Color.WhiteSmoke;

            Label lblLegend = new Label();
            lblLegend.Text = "■ Có sẵn   ■ Đã chọn   ■ Đã được đặt   ■ Không khả dụng";
            lblLegend.Location = new Point(10, 10);
            lblLegend.Size = new Size(500, 20);
            lblLegend.AutoSize = false;
            pnlLegend.Controls.Add(lblLegend);

            this.Controls.Add(pnlLegend);

            // Add pagination controls
            if (totalPages > 1)
            {
                DrawPaginationControls();
            }

            // Add action buttons
            DrawActionButtons();
        }

        /// <summary>
        /// Draw pagination controls
        /// </summary>
        private void DrawPaginationControls()
        {
            Panel pnlPagination = new Panel();
            pnlPagination.Location = new Point(10, this.ClientSize.Height - 60);
            pnlPagination.Size = new Size(300, 30);

            Button btnPrev = new Button();
            btnPrev.Text = "◀ Trước";
            btnPrev.Location = new Point(0, 0);
            btnPrev.Size = new Size(80, 25);
            btnPrev.Enabled = currentPage > 0;
            btnPrev.Click += BtnPrev_Click;
            pnlPagination.Controls.Add(btnPrev);

            Label lblPage = new Label();
            lblPage.Text = $"Trang {currentPage + 1}/{totalPages}";
            lblPage.Location = new Point(90, 5);
            lblPage.Size = new Size(100, 20);
            lblPage.TextAlign = ContentAlignment.MiddleCenter;
            pnlPagination.Controls.Add(lblPage);

            Button btnNext = new Button();
            btnNext.Text = "Sau ▶";
            btnNext.Location = new Point(200, 0);
            btnNext.Size = new Size(80, 25);
            btnNext.Enabled = currentPage < totalPages - 1;
            btnNext.Click += BtnNext_Click;
            pnlPagination.Controls.Add(btnNext);

            this.Controls.Add(pnlPagination);
        }

        /// <summary>
        /// Draw action buttons (OK, Cancel)
        /// </summary>
        private void DrawActionButtons()
        {
            Button btnOK = new Button();
            btnOK.Text = "Xác nhận";
            btnOK.Location = new Point(this.ClientSize.Width - 180, this.ClientSize.Height - 35);
            btnOK.Size = new Size(80, 30);
            btnOK.BackColor = Color.Green;
            btnOK.ForeColor = Color.White;
            btnOK.Click += (s, e) => this.DialogResult = DialogResult.OK;
            this.Controls.Add(btnOK);

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Location = new Point(this.ClientSize.Width - 90, this.ClientSize.Height - 35);
            btnCancel.Size = new Size(80, 30);
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = Color.White;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);
        }

        /// <summary>
        /// Setup pagination
        /// </summary>
        private void SetupPagination()
        {
            totalPages = (int)Math.Ceiling((double)totalRows / ROWS_PER_PAGE);
            currentPage = 0;
        }

        /// <summary>
        /// Handle previous page button click
        /// </summary>
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                DrawSeatMap();
            }
        }

        /// <summary>
        /// Handle next page button click
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages - 1)
            {
                currentPage++;
                DrawSeatMap();
            }
        }

        /// <summary>
        /// Handle seat click with improved validation and user feedback
        /// </summary>
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            if (!isInitialized)
            {
                MessageBox.Show("Form chưa được khởi tạo hoàn tất", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btn = sender as Button;
            if (btn?.Tag == null) return;
            
            string tag = btn.Tag.ToString();
            string[] parts = tag.Split(',');
            
            if (parts.Length != 2 || !int.TryParse(parts[0], out int row) || !int.TryParse(parts[1], out int col))
            {
                MessageBox.Show("Lỗi xác định vị trí ghế", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string seatLabel = GetSeatLabel(row, col);
            string seatClass = DetermineSeatClass(row, col);
            
            // Debug logging
            System.Diagnostics.Debug.WriteLine($"Seat clicked: {seatLabel}, Status: {seatStatus[row, col]}, Class: {seatClass}, SelectedClass: {selectedServiceClass}");

            // Can't select taken seats
            if (seatStatus[row, col] == 2)
            {
                MessageBox.Show($"Ghế {seatLabel} đã được đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if seat is available for selected service class
            if (!IsSeatAvailableForServiceClass(row, col))
            {
                string serviceClassName = GetServiceClassName(selectedServiceClass);
                string seatClassName = GetServiceClassName(seatClass);
                MessageBox.Show($"Ghế {seatLabel} ({seatClassName}) không khả dụng cho hạng vé đã chọn ({serviceClassName})", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toggle selection
            if (seatStatus[row, col] == 0)
            {
                // Deselect previous seat if any
                DeselectAllSeats();

                // Select new seat
                seatStatus[row, col] = 1;
                selectedSeat = seatLabel;
                UpdateSeatColor(btn, 1, row, col);

                string serviceClassName = GetServiceClassName(seatClass);
                lblSelected.Text = $"Ghế đã chọn: {selectedSeat} ({serviceClassName})";
                System.Diagnostics.Debug.WriteLine($"Seat {selectedSeat} selected successfully");
            }
            else if (seatStatus[row, col] == 1)
            {
                // Deselect
                seatStatus[row, col] = 0;
                selectedSeat = "";
                UpdateSeatColor(btn, 0, row, col);
                lblSelected.Text = "Ghế đã chọn: (chưa chọn)";
                System.Diagnostics.Debug.WriteLine($"Seat {seatLabel} deselected");
            }
        }
        
        /// <summary>
        /// Get user-friendly service class name
        /// </summary>
        private string GetServiceClassName(string serviceClassCode)
        {
            if (string.IsNullOrEmpty(serviceClassCode))
                return "Không xác định";
                
            switch (serviceClassCode.ToUpper())
            {
                case "ECO":
                    return "Phổ thông";
                case "PRE":
                    return "Phổ thông đặc biệt";
                case "BUS":
                    return "Thương gia";
                case "FIR":
                    return "Hạng nhất";
                default:
                    return serviceClassCode;
            }
        }

        /// <summary>
        /// Deselect all currently selected seats
        /// </summary>
        private void DeselectAllSeats()
        {
            for (int r = 0; r < totalRows; r++)
            {
                for (int c = 0; c < seatsPerRow; c++)
                {
                    if (seatStatus[r, c] == 1)
                    {
                        seatStatus[r, c] = 0;
                        if (seatButtons[r, c] != null)
                        {
                            UpdateSeatColor(seatButtons[r, c], 0, r, c);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check if seat is available for selected service class
        /// </summary>
        private bool IsSeatAvailableForServiceClass(int row, int col)
        {
            // If no service class is selected, all seats are available
            if (string.IsNullOrEmpty(selectedServiceClass))
                return true;

            // Determine seat class based on row position
            string seatClass = DetermineSeatClass(row, col);
            
            // Check if this seat class matches the selected service class
            bool isAvailable = seatClass.Equals(selectedServiceClass, StringComparison.OrdinalIgnoreCase);
            
            // Debug logging
            System.Diagnostics.Debug.WriteLine($"Seat {GetSeatLabel(row, col)}: Class={seatClass}, SelectedClass={selectedServiceClass}, Available={isAvailable}");
            
            return isAvailable;
        }

        /// <summary>
        /// Determine seat class based on row and column position
        /// </summary>
        private string DetermineSeatClass(int row, int col)
        {
            // If no seat count configuration, default to Economy
            if (seatCountByClass == null || seatCountByClass.Count == 0)
                return "ECO";

            // Get seat counts for each class
            int ecoSeats = seatCountByClass.ContainsKey("ECO") ? seatCountByClass["ECO"] : totalRows * seatsPerRow;
            int preSeats = seatCountByClass.ContainsKey("PRE") ? seatCountByClass["PRE"] : 0;
            int busSeats = seatCountByClass.ContainsKey("BUS") ? seatCountByClass["BUS"] : 0;
            int firSeats = seatCountByClass.ContainsKey("FIR") ? seatCountByClass["FIR"] : 0;

            // Calculate seat index (0-based)
            int seatIndex = row * seatsPerRow + col;
            
            // Debug logging
            System.Diagnostics.Debug.WriteLine($"Seat {GetSeatLabel(row, col)} (index {seatIndex}): FIR={firSeats}, BUS={busSeats}, PRE={preSeats}, ECO={ecoSeats}");

            // Determine class based on seat position
            // First class seats are typically at the front
            if (firSeats > 0 && seatIndex < firSeats)
                return "FIR";
            // Business class seats follow first class
            else if (busSeats > 0 && seatIndex < firSeats + busSeats)
                return "BUS";
            // Premium economy seats follow business class
            else if (preSeats > 0 && seatIndex < firSeats + busSeats + preSeats)
                return "PRE";
            // All remaining seats are economy
            else
                return "ECO";
        }

        /// <summary>
        /// Get seat label (e.g., 1A, 1B, etc.)
        /// </summary>
        private string GetSeatLabel(int row, int col)
        {
            char letter = (char)('A' + col);
            return $"{row + 1}{letter}";
        }

        /// <summary>
        /// Update seat button color based on status and service class with improved visual feedback
        /// </summary>
        private void UpdateSeatColor(Button btn, int status, int row, int col)
        {
            if (btn == null) return;

            // Determine seat class
            string seatClass = DetermineSeatClass(row, col);
            bool isAvailableForSelectedClass = IsSeatAvailableForServiceClass(row, col);

            switch (status)
            {
                case 0: // Available
                    if (isAvailableForSelectedClass)
                    {
                        btn.BackColor = GetClassColor(seatClass);
                        btn.ForeColor = Color.White;
                        btn.Enabled = true;
                        btn.Cursor = Cursors.Hand;
                        btn.FlatStyle = FlatStyle.Standard;
                    }
                    else
                    {
                        btn.BackColor = Color.LightGray;
                        btn.ForeColor = Color.DarkGray;
                        btn.Enabled = false;
                        btn.Cursor = Cursors.No;
                        btn.FlatStyle = FlatStyle.Flat;
                    }
                    break;
                case 1: // Selected
                    btn.BackColor = Color.Blue;
                    btn.ForeColor = Color.White;
                    btn.Enabled = true;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatStyle = FlatStyle.Standard;
                    break;
                case 2: // Taken
                    btn.BackColor = Color.Gray;
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                    btn.Cursor = Cursors.No;
                    btn.FlatStyle = FlatStyle.Flat;
                    break;
            }
            
            // Add border for better visual separation
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.DarkGray;
        }

        /// <summary>
        /// Get color for service class with improved color scheme
        /// </summary>
        private Color GetClassColor(string seatClass)
        {
            switch (seatClass.ToUpper())
            {
                case "FIR":
                    return Color.FromArgb(128, 0, 128); // Purple - Hạng nhất
                case "BUS":
                    return Color.FromArgb(255, 140, 0); // Orange - Thương gia
                case "PRE":
                    return Color.FromArgb(0, 128, 128); // Teal - Phổ thông đặc biệt
                case "ECO":
                default:
                    return Color.FromArgb(34, 139, 34); // Forest Green - Phổ thông
            }
        }
    }
}
