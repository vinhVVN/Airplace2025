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
    public partial class FlightCard : UserControl
    {
        private const string EconomyLabel = "Phổ Thông";
        private const string PremiumLabel = "Phổ Thông Đặc Biệt";
        private const string BusinessLabel = "Thương Gia";
        private Color originalColor1;
        private Color originalColor2;
        private Color originalColor3;
        private Size originalSize1;
        private Point originalLocation1;
        public event EventHandler<SelectedFareEventArgs> FareSelected;

        public ChuyenBayDTO FlightData { get; set; }
        public decimal EconomyPriceValue { get; set; }
        public decimal PremiumPriceValue { get; set; }
        public decimal BusinessPriceValue { get; set; }

        public FlightCard()
        {
            InitializeComponent();
            // Ẩn label +1 ngày mặc định
            lblNextDay.Visible = false;

            originalColor1 = pricePanel1.FillColor;
            originalColor2 = pricePanel2.FillColor;
            originalColor3 = pricePanel3.FillColor;
            originalSize1 = pricePanel1.Size;
            originalLocation1 = pricePanel1.Location;

            // Thêm sự kiện MouseEnter và MouseLeave cho cả 3 panel
            SetupHoverEffects();
        }

        private void SetupHoverEffects()
        {
            // Panel 1
            pricePanel1.MouseEnter += PricePanel1_MouseEnter;
            pricePanel1.MouseLeave += PricePanel1_MouseLeave;

            // Panel 2
            pricePanel2.MouseEnter += PricePanel2_MouseEnter;
            pricePanel2.MouseLeave += PricePanel2_MouseLeave;

            // Panel 3
            pricePanel3.MouseEnter += PricePanel3_MouseEnter;
            pricePanel3.MouseLeave += PricePanel3_MouseLeave;
        }

        private void PricePanel1_MouseEnter(object sender, EventArgs e)
        {
            // Panel được hover - nổi bật
            pricePanel1.Size = new Size(originalSize1.Width + 6, originalSize1.Height + 6);
            pricePanel1.Location = new Point(originalLocation1.X - 3, originalLocation1.Y - 3);
            pricePanel1.BringToFront();

            // Làm mờ 2 panel còn lại
            pricePanel2.FillColor = Color.FromArgb(180, pricePanel2.FillColor);
            pricePanel3.FillColor = Color.FromArgb(180, pricePanel3.FillColor);

            this.Cursor = Cursors.Hand;
        }

        private void PricePanel1_MouseLeave(object sender, EventArgs e)
        {
            // Trả về trạng thái ban đầu
            pricePanel1.Size = originalSize1;
            pricePanel1.Location = originalLocation1;

            pricePanel2.FillColor = originalColor2;
            pricePanel3.FillColor = originalColor3;

            this.Cursor = Cursors.Default;
        }

        // ===== PANEL 2 =====
        private void PricePanel2_MouseEnter(object sender, EventArgs e)
        {
            // Panel được hover - nổi bật
            pricePanel2.Size = new Size(pricePanel2.Width + 6, pricePanel2.Height + 6);
            pricePanel2.Location = new Point(pricePanel2.Location.X - 3, pricePanel2.Location.Y - 3);
            pricePanel2.BringToFront();

            // Làm mờ 2 panel còn lại
            pricePanel1.FillColor = Color.FromArgb(180, pricePanel1.FillColor);
            pricePanel3.FillColor = Color.FromArgb(180, pricePanel3.FillColor);

            this.Cursor = Cursors.Hand;
        }

        private void PricePanel2_MouseLeave(object sender, EventArgs e)
        {
            // Trả về trạng thái ban đầu
            pricePanel2.Size = new Size(150, 140);
            pricePanel2.Location = new Point(633, 0);

            pricePanel1.FillColor = originalColor1;
            pricePanel3.FillColor = originalColor3;

            this.Cursor = Cursors.Default;
        }

        // ===== PANEL 3 =====
        private void PricePanel3_MouseEnter(object sender, EventArgs e)
        {
            // Panel được hover - nổi bật
            pricePanel3.Size = new Size(pricePanel3.Width + 6, pricePanel3.Height + 6);
            pricePanel3.Location = new Point(pricePanel3.Location.X - 3, pricePanel3.Location.Y - 3);
            pricePanel3.BringToFront();

            // Làm mờ 2 panel còn lại
            pricePanel1.FillColor = Color.FromArgb(180, pricePanel1.FillColor);
            pricePanel2.FillColor = Color.FromArgb(180, pricePanel2.FillColor);

            this.Cursor = Cursors.Hand;
        }

        private void PricePanel3_MouseLeave(object sender, EventArgs e)
        {
            // Trả về trạng thái ban đầu
            pricePanel3.Size = new Size(150, 140);
            pricePanel3.Location = new Point(783, 0);

            pricePanel1.FillColor = originalColor1;
            pricePanel2.FillColor = originalColor2;

            this.Cursor = Cursors.Default;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            // Tạo FlightDetailForm và truyền dữ liệu
            FlightDetailForm detailForm = new FlightDetailForm();

            // Populate dữ liệu vào form
            detailForm.SetFlightData(new FlightDetailData
            {
                RouteTitle = $"{DepartureCity} - {ArrivalCity}",
                DepartureDate = DepartureDate,
                ArrivalDate = ArrivalDate,
                TotalDuration = Duration,
                DepartureTime = DepartureTime,
                DepartureCity = DepartureCity,
                DepartureAirport = DepartureAirport,
                DepartureTerminal = DepartureTerminal,
                ArrivalTime = ArrivalTime,
                ArrivalCity = ArrivalCity,
                ArrivalAirport = ArrivalAirport,
                ArrivalTerminal = ArrivalTerminal,
                FlightNumber = FlightNumber,
                Airline = Airline,
                Aircraft = Aircraft,
                FlightDuration = Duration,
                IsNextDay = IsNextDay
            });

            // Hiển thị form chi tiết
            detailForm.ShowDialog();
        }

        public string DepartureTime
        {
            get => lblDepartureTime.Text;
            set => lblDepartureTime.Text = value;
        }

        public string DepartureCity
        {
            get => lblDepartureCity.Text;
            set => lblDepartureCity.Text = value;
        }

        public string DepartureTerminal
        {
            get => lblDepartureTerminal.Text;
            set => lblDepartureTerminal.Text = value;
        }

        public string ArrivalTime
        {
            get => lblArrivalTime.Text;
            set => lblArrivalTime.Text = value;
        }

        public string ArrivalCity
        {
            get => lblArrivalCity.Text;
            set => lblArrivalCity.Text = value;
        }

        public string ArrivalTerminal
        {
            get => lblArrivalTerminal.Text;
            set => lblArrivalTerminal.Text = value;
        }

        public string Duration
        {
            get => lblFlightDuration.Text;
            set => lblFlightDuration.Text = value;
        }

        public string Airline
        {
            get => lblAirline.Text;
            set => lblAirline.Text = value;
        }

        public string EconomyPrice
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        public string PremiumPrice
        {
            get => lblPricePre.Text;
            set => lblPricePre.Text = value;
        }

        public string BusinessPrice
        {
            get => lblPriceBus.Text;
            set => lblPriceBus.Text = value;
        }

        public int EconomySeats
        {
            set
            {
                lblSeatsEco.Visible = value < 10;
                lblSeatsEco.Text = value > 0 ? $"{value} ghế còn lại" : "Hết chỗ";
            }
        }

        public int PremiumSeats
        {
            set
            {
                lblSeatsPre.Visible = value < 10;
                lblSeatsPre.Text = value > 0 ? $"{value} ghế còn lại" : "Hết chỗ";
            }
        }

        public int BusinessSeats
        {
            set
            {
                lblSeatsBus.Visible = value < 10;
                lblSeatsBus.Text = value > 0 ? $"{value} ghế còn lại" : "Hết chỗ";
            }
        }

        // Thêm các property để lưu trữ dữ liệu chi tiết
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string FlightNumber { get; set; }
        public string Aircraft { get; set; }
        
        private bool _isNextDay;
        public bool IsNextDay 
        { 
            get => _isNextDay;
            set 
            {
                _isNextDay = value;
                lblNextDay.Visible = value;
            }
        }
        
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

        private void pricePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pricePanel1_Click(object sender, EventArgs e)
        {
            NotifyFareSelected(EconomyLabel, EconomyPriceValue);
        }

        private void pricePanel2_Click(object sender, EventArgs e)
        {
            NotifyFareSelected(PremiumLabel, PremiumPriceValue);
        }

        private void pricePanel3_Click(object sender, EventArgs e)
        {
            NotifyFareSelected(BusinessLabel, BusinessPriceValue);
        }

        private void NotifyFareSelected(string cabinClass, decimal price)
        {
            if (FlightData == null)
            {
                return;
            }

            var info = new SelectedFareInfo(FlightData, cabinClass, price);
            FareSelected?.Invoke(this, new SelectedFareEventArgs(info));
        }
    }
}
