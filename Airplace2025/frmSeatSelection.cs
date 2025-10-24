using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplace2025
{
    /// <summary>
    /// Form để chọn ghế trực quan dựa trên layout máy bay
    /// </summary>
    public partial class frmSeatSelection : Form
    {
        private const int SEAT_SIZE = 40;
        private const int SEAT_SPACING = 5;
        private const int AISLE_WIDTH = 20;

        // Seat data: [row][col] = status (0=available, 1=selected, 2=taken)
        private int[,] seatStatus;
        private Button[,] seatButtons;
        private string selectedSeat = "";

        public string SelectedSeat { get { return selectedSeat; } }

        // Aircraft config
        private int rows = 30;
        private int seatsPerRow = 6; // A B C [aisle] D E F

        public frmSeatSelection()
        {
            InitializeComponent();
        }

        public frmSeatSelection(int numRows = 30, int seatsPerRow = 6)
        {
            InitializeComponent();
            this.rows = numRows;
            this.seatsPerRow = seatsPerRow;
        }

        private void frmSeatSelection_Load(object sender, EventArgs e)
        {
            InitializeSeats();
            DrawSeatMap();
        }

        /// <summary>
        /// Initialize seat status array and buttons
        /// </summary>
        private void InitializeSeats()
        {
            seatStatus = new int[rows, seatsPerRow];
            seatButtons = new Button[rows, seatsPerRow];

            // Initialize all seats as available (0)
            // Randomly set some as taken (2) - for demo
            Random rand = new Random();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < seatsPerRow; c++)
                {
                    seatStatus[r, c] = rand.NextDouble() < 0.15 ? 2 : 0; // 15% taken
                }
            }
        }

        /// <summary>
        /// Draw seat map UI
        /// </summary>
        private void DrawSeatMap()
        {
            try
            {
                // Create panel for seat map
                Panel pnlSeats = new Panel();
                pnlSeats.AutoScroll = true;
                pnlSeats.Location = new Point(10, 10);
                pnlSeats.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 100);
                pnlSeats.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnlSeats);

                int panelWidth = (seatsPerRow * (SEAT_SIZE + SEAT_SPACING)) + AISLE_WIDTH + 20;
                int panelHeight = (rows * (SEAT_SIZE + SEAT_SPACING)) + 50;

                pnlSeats.AutoScrollMinSize = new Size(panelWidth, panelHeight);

                // Draw seats
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < seatsPerRow; c++)
                    {
                        int x = 10 + (c * (SEAT_SIZE + SEAT_SPACING)) + (c >= seatsPerRow / 2 ? AISLE_WIDTH : 0);
                        int y = 10 + (r * (SEAT_SIZE + SEAT_SPACING));

                        Button btnSeat = new Button();
                        btnSeat.Tag = $"{r},{c}";
                        btnSeat.Width = SEAT_SIZE;
                        btnSeat.Height = SEAT_SIZE;
                        btnSeat.Location = new Point(x, y);
                        btnSeat.Font = new Font("Arial", 8, FontStyle.Bold);
                        btnSeat.Text = GetSeatLabel(r, c);
                        btnSeat.Cursor = Cursors.Hand;

                        // Set color based on status
                        UpdateSeatColor(btnSeat, seatStatus[r, c]);

                        btnSeat.Click += BtnSeat_Click;

                        seatButtons[r, c] = btnSeat;
                        pnlSeats.Controls.Add(btnSeat);
                    }
                }

                // Add legend
                Panel pnlLegend = new Panel();
                pnlLegend.Location = new Point(10, this.ClientSize.Height - 80);
                pnlLegend.Size = new Size(this.ClientSize.Width - 20, 60);
                pnlLegend.BorderStyle = BorderStyle.FixedSingle;
                pnlLegend.BackColor = Color.WhiteSmoke;

                Label lblLegend = new Label();
                lblLegend.Text = "■ Có sẵn   ■ Đã chọn   ■ Đã được đặt";
                lblLegend.Location = new Point(10, 10);
                lblLegend.Size = new Size(400, 40);
                lblLegend.AutoSize = false;
                pnlLegend.Controls.Add(lblLegend);

                this.Controls.Add(pnlLegend);

                // Buttons
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi vẽ seat map: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle seat click
        /// </summary>
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tag = btn.Tag.ToString();
            string[] parts = tag.Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);

            // Can't select taken seats
            if (seatStatus[row, col] == 2)
            {
                MessageBox.Show("Ghế này đã được đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Toggle selection
            if (seatStatus[row, col] == 0)
            {
                // Deselect previous seat if any
                foreach (int r in System.Linq.Enumerable.Range(0, rows))
                {
                    foreach (int c in System.Linq.Enumerable.Range(0, seatsPerRow))
                    {
                        if (seatStatus[r, c] == 1)
                        {
                            seatStatus[r, c] = 0;
                            UpdateSeatColor(seatButtons[r, c], 0);
                        }
                    }
                }

                // Select new seat
                seatStatus[row, col] = 1;
                selectedSeat = GetSeatLabel(row, col);
                UpdateSeatColor(btn, 1);

                lblSelected.Text = $"Ghế đã chọn: {selectedSeat}";
            }
            else if (seatStatus[row, col] == 1)
            {
                // Deselect
                seatStatus[row, col] = 0;
                selectedSeat = "";
                UpdateSeatColor(btn, 0);
                lblSelected.Text = "Ghế đã chọn: (chưa chọn)";
            }
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
        /// Update seat button color
        /// </summary>
        private void UpdateSeatColor(Button btn, int status)
        {
            switch (status)
            {
                case 0: // Available
                    btn.BackColor = Color.LightGreen;
                    btn.ForeColor = Color.Black;
                    break;
                case 1: // Selected
                    btn.BackColor = Color.Blue;
                    btn.ForeColor = Color.White;
                    break;
                case 2: // Taken
                    btn.BackColor = Color.Gray;
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                    break;
            }
        }
    }
}
