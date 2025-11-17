using System;
using Airplace2025.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmShoppingCart : Form
    {
        private const int CollapsedHeight = 160;
        private const int ExpandedHeight = 453;
        private const int AnimationStep = 25;
        private readonly Timer animationTimer;
        private int targetHeight;
        private SelectedFareInfo selectedFare;

        public frmShoppingCart()
        {
            InitializeComponent();
            animationTimer = new Timer
            {
                Interval = 15
            };
            animationTimer.Tick += AnimationTimer_Tick;
            InitializeCollapsedState();
        }

        public frmShoppingCart(SelectedFareInfo fareInfo) : this()
        {
            PopulateFareDetails(fareInfo);
        }

        private void pnlArriveFlight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PopulateFareDetails(SelectedFareInfo fareInfo)
        {
            if (fareInfo?.Flight == null)
            {
                return;
            }

            selectedFare = fareInfo;
            var flight = fareInfo.Flight;
            var culture = new CultureInfo("vi-VN");
            TimeSpan duration = CalculateDuration(flight);
            int durationHours = (int)duration.TotalHours;
            int durationMinutes = duration.Minutes;
            string fromName = FormatAirportName(flight.TenSanBayDi, flight.MaSanBayDi);
            string toName = FormatAirportName(flight.TenSanBayDen, flight.MaSanBayDen);

            lblRoute1.Text = $"{fromName} đến {toName}";
            lblDate.Text = flight.NgayGioBay.ToString("dddd, dd 'tháng' MM, yyyy", culture);
            depTimeLabel.Text = flight.NgayGioBay.ToString("HH:mm");
            depCodeLabel.Text = flight.MaSanBayDi;
            depTerminalLabel.Text = string.Empty;

            arrTimeLabel.Text = flight.NgayGioDen.ToString("HH:mm");
            arrCodeLabel.Text = flight.MaSanBayDen;
            arrTerminalLabel.Text = string.Empty;

            durationLabel.Text = "Bay thẳng";
            durationTime.Text = $"Thời gian bay {durationHours}h {durationMinutes}phút";
            airlineLabel.Text = $" ✈️ {flight.MaChuyenBay} khai thác bởi {flight.TenHangBay}";
            TypeLabel.Text = fareInfo.CabinClass;
            fareType.Text = fareInfo.CabinClass;
            ApplyFarePerks(fareInfo.CabinClass);

            string departureTimeline = $"{flight.NgayGioBay:HH:mm} {fromName}";
            string arrivalTimeline = $"{flight.NgayGioDen:HH:mm} {toName}";

            lblDepartureTime.Text = departureTimeline;
            lblDepartureAirport.Text = fromName;
            lblDepartureTerminal.Text = string.Empty;

            lblArrivalTime.Text = arrivalTimeline;
            lblArrivalAirport.Text = toName;
            lblArrivalTerminal.Text = string.Empty;
            lblNextDay.Visible = flight.NgayGioDen.Date > flight.NgayGioBay.Date;
            lblNextDay.Text = lblNextDay.Visible ? "(+1 ngày)" : string.Empty;

            lblAirline.Text = $"Khai thác bởi {flight.TenHangBay}";
            lblFlightNumberTitle.Text = $"Số hiệu chuyến bay {flight.MaChuyenBay}";
            lblAircraft.Text = flight.TenMayBay ?? "Đang cập nhật";
            lblFlightDuration.Text = $"{durationHours} giờ {durationMinutes} phút";
        }

        private static TimeSpan CalculateDuration(ChuyenBayDTO flight)
        {
            if (flight.NgayGioDen > flight.NgayGioBay)
            {
                return flight.NgayGioDen - flight.NgayGioBay;
            }

            return TimeSpan.FromMinutes(Math.Max(0, flight.ThoiGianBay));
        }

        private static string FormatAirportName(string name, string code)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return name;
            }

            return code ?? string.Empty;
        }

        private void ApplyFarePerks(string cabinClass)
        {
            string normalized = NormalizeCabinClass(cabinClass);
            switch (normalized)
            {
                case "Premium":
                    lblThayVe.Text = "🔄 Thay đổi vé: Được phép";
                    lblHoanVe.Text = "🎫 Hoàn vé: Phí hoàn tối đa 500.000 VND mỗi hành khách cho toàn bộ vé";
                    lblHanhLyKyGui.Text = "💼 Hành lý ký gửi: 1 × 32 kg";
                    lblHanhLyXachTay.Text = "🎒 Hành lý xách tay: 1 × 10 kg";
                    break;
                case "Business":
                    lblThayVe.Text = "🔄 Thay đổi vé: Phí đổi tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    lblHoanVe.Text = "🎫 Hoàn vé: Phí hoàn tối đa 1.000.000 VND mỗi hành khách cho toàn bộ vé";
                    lblHanhLyKyGui.Text = "💼 Hành lý ký gửi: 1 × 32 kg";
                    lblHanhLyXachTay.Text = "🎒 Hành lý xách tay: 1 × 18 kg";
                    break;
                default:
                    lblThayVe.Text = "🔄 Thay đổi vé: Phí đổi tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    lblHoanVe.Text = "🎫 Hoàn vé: Phí hoàn tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    lblHanhLyKyGui.Text = "💼 Hành lý ký gửi: 1 × 23 kg";
                    lblHanhLyXachTay.Text = "🎒 Hành lý xách tay: 1 × 10 kg";
                    break;
            }
        }

        private static string NormalizeCabinClass(string cabinClass)
        {
            if (string.IsNullOrWhiteSpace(cabinClass))
            {
                return "Economy";
            }

            string normalized = cabinClass.Trim().ToUpperInvariant();

            if (normalized.Contains("ĐẶC BIỆT") || normalized.Contains("PREMIUM"))
            {
                return "Premium";
            }

            if (normalized.Contains("THƯƠNG GIA") || normalized.Contains("BUSINESS"))
            {
                return "Business";
            }

            return "Economy";
        }

        private void InitializeCollapsedState()
        {
            pnlArriveFlight.Height = CollapsedHeight;
            detailsPanel.Visible = false;
            expandBtn.Text = "˅";
            targetHeight = CollapsedHeight;
        }

        private void expandBtn_Click(object sender, EventArgs e)
        {
            if (animationTimer.Enabled)
            {
                return;
            }

            bool expanding = pnlArriveFlight.Height <= CollapsedHeight;
            targetHeight = expanding ? ExpandedHeight : CollapsedHeight;
            expandBtn.Text = expanding ? "˄" : "˅";

            if (expanding)
            {
                detailsPanel.Visible = true;
            }

            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            int direction = targetHeight > pnlArriveFlight.Height ? 1 : -1;
            int nextHeight = pnlArriveFlight.Height + direction * AnimationStep;

            bool reachedTarget = direction > 0
                ? nextHeight >= targetHeight
                : nextHeight <= targetHeight;

            pnlArriveFlight.Height = reachedTarget ? targetHeight : nextHeight;

            if (reachedTarget)
            {
                animationTimer.Stop();
                if (targetHeight == CollapsedHeight)
                {
                    detailsPanel.Visible = false;
                }
            }
        }
    }
}
