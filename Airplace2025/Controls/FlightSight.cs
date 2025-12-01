using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025.Controls
{
    public partial class FlightSight: UserControl
    {
        public FlightSight()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void SetData(string aircraftName, string originAirport, string destinationAirport,
            string originAirportName, string destinationAirportName, string departureTime, string arrivalTime, string departureDay,
            string arrivalDay, string duration, Image logo, string Seat
            )
        {
            lbTenMayBay.Text = aircraftName;
            lbMaSanBayDi.Text = originAirport;
            lbTenSanBayDi.Text = originAirportName;
            lbMaSanBayDen.Text = destinationAirport;
            lbTenSanBayDen.Text = destinationAirportName;
            lbThoiGianDi.Text = departureTime;
            lbThoiGianDen.Text = arrivalTime;
            lbNgayDi.Text = departureDay;
            lbNgayDen.Text = arrivalDay;
            lbThoiLuong.Text = duration;
            imgLogo.Image = logo;
            lbSeat.Text = Seat;
            
        }

    }
}
