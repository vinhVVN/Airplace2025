using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Airplace2025.Controls;

namespace Airplace2025
{
    public partial class FlightLegControl: UserControl
    {
        public FlightLegControl()
        {
            InitializeComponent();
        }

        private TimelineNodeType _nodeType = TimelineNodeType.None;

        public void SetData(string filghtId, string airlineName, string aircraftName, string originAirport, string destinationAirport,
            string originAirportName, string destinationAirportName, string departureTime, string arrivalTime, string departureDay,
            string arrivalDay, string duration, Image logo, TimelineNodeType nodeType
            )
        {
            lbMaChuyenBay.Text = filghtId;
            lbTenHang.Text = airlineName;
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

            _nodeType = nodeType;
            pnlTimeline.Invalidate(); // Yêu cầu vẽ lại panel
        }

        public void SetDuration(string duration)
        {
            lbThoiLuong.Text = duration;
        }

        private void pnlTimeline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Bật chế độ làm mịn đường vẽ

            int centerX = pnlTimeline.Width / 4;
            int circleRadius = 5; // Bán kính chấm tròn
            int topMargin = 20;

            // Bút vẽ chấm
            Pen dotpen = new Pen(Color.Gray, 2)
            {
                DashPattern = new float[] { 1, 3 } // 1px vẽ, 3px trống
            };

            // Chổi tô màu vàng
            Brush yellowBrush = Brushes.Orange;
            // Luôn vẽ đường chấm từ trên xuống dưới
            if (_nodeType == TimelineNodeType.Start)
            {
                g.DrawLine(dotpen, centerX, 20, centerX, this.Height);
            }
            else if (_nodeType == TimelineNodeType.End)
            {
                g.DrawLine(dotpen, centerX, 0, centerX, this.Height-20);
            }
            else if (_nodeType == TimelineNodeType.StartAndEnd)
            {
                g.DrawLine(dotpen, centerX, 20, centerX, this.Height - 20);
            }

            // Vẽ chấm tròn dựa trên loại nút
            if (_nodeType == TimelineNodeType.Start || _nodeType == TimelineNodeType.StartAndEnd)
            {
                // Vẽ chấm vàng ở trên
                Rectangle topRect = new Rectangle(
                    centerX - circleRadius,
                    topMargin,
                    circleRadius * 2,
                    circleRadius * 2
                );
                g.FillEllipse(yellowBrush, topRect);
            }

            if (_nodeType == TimelineNodeType.End || _nodeType == TimelineNodeType.StartAndEnd)
            {
                // Vẽ chấm vàng ở dưới
                Rectangle bottomRect = new Rectangle(
                    centerX - circleRadius,
                    this.Height - topMargin - (circleRadius * 2), // Căn lề dưới
                    circleRadius * 2,
                    circleRadius * 2
                );
                g.FillEllipse(yellowBrush, bottomRect);
            }

            dotpen.Dispose(); // Giải phóng tài nguyên

        }
    }
}
