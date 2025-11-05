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
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {

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
    }
}
