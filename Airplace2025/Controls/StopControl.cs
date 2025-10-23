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
    public partial class StopControl: UserControl
    {
        public StopControl()
        {
            InitializeComponent();
        }

        private string FormatDuration(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            if (hours > 0)
            {
                return $"{hours}h {minutes}m";
            }
            else
            {
                return $"{minutes}m";
            }
        }
        public void SetData(int duration)
        {
            lbThoiLuong.Text = FormatDuration(duration);
        }

        private void pnlTimeline_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = pnlTimeline.Width / 4;
            int circleRadius = 5;
            int topMargin = 8;
            Pen dotpen = new Pen(Color.Gray, 2)
            {
                DashPattern = new float[] { 1, 3 }
            };
            Pen redPen = new Pen(Color.Red, 2);
            Brush whiteBrush = Brushes.White;

            g.DrawLine(dotpen, centerX, 0, centerX, this.Height);

            // Vẽ đường đỏ rỗng ở trên
            Rectangle stopRect = new Rectangle(
                centerX - circleRadius,
                topMargin,
                circleRadius * 2,
                circleRadius * 2
            );

            g.FillEllipse(whiteBrush, stopRect); // Tô trắng bên trong
            g.DrawEllipse(redPen, stopRect); // Vẽ viền đỏ ở ngoài

            dotpen.Dispose();
            redPen.Dispose();

        }
    }
}
