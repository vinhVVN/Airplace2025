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
        public FlightCard()
        {
            InitializeComponent();
            // Ẩn label +1 ngày mặc định
            lblNextDay.Visible = false;
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
            set => lblSeatsEco.Text = value > 0 ? $"{value} ghế còn lại" : "Hết chỗ";
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
    }
}
