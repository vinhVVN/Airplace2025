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
    public partial class FlightDetailForm : Form
    {
        public FlightDetailForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetFlightData(FlightDetailData data)
        {
            if (data == null) return;

            // Set header title
            lblTitle.Text = data.RouteTitle;

            // Set dates
            lblDepartureDate.Text = data.DepartureDate;
            lblArrivalDate.Text = data.ArrivalDate;

            // Set duration
            lblDuration.Text = data.TotalDuration;

            // Set departure information
            lblDepartureTime.Text = $"{data.DepartureTime} {data.DepartureCity}";
            lblDepartureAirport.Text = data.DepartureAirport;
            lblDepartureTerminal.Text = data.DepartureTerminal;

            // Set arrival information
            lblArrivalTime.Text = $"{data.ArrivalTime} {data.ArrivalCity}";
            lblArrivalAirport.Text = data.ArrivalAirport;
            lblArrivalTerminal.Text = data.ArrivalTerminal;

            // Set next day indicator
            lblNextDay.Visible = data.IsNextDay;
            lblArrivalDate.Visible = data.IsNextDay;

            // Set flight duration
            lblFlightDuration.Text = data.FlightDuration?.Replace("⏱ Thời gian bay ", "")
                .Replace("h ", " giờ\n")
                .Replace("phút", " phút");

            // Set flight information
            lblFlightNumberTitle.Text = $"Số hiệu chuyến bay {data.FlightNumber}";
            lblAirline.Text = data.Airline?.Replace("✈", "Khai thác bởi");
            lblAircraft.Text = data.Aircraft;
        }
    }

    public class FlightDetailData
    {
        public string RouteTitle { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
        public string TotalDuration { get; set; }
        public string DepartureTime { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureTerminal { get; set; }
        public string ArrivalTime { get; set; }
        public string ArrivalCity { get; set; }
        public string ArrivalAirport { get; set; }
        public string ArrivalTerminal { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string Aircraft { get; set; }
        public string FlightDuration { get; set; }
        public bool IsNextDay { get; set; }
    }
}
