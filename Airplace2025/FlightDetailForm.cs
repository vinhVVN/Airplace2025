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
