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
        private const int ReturnPanelCollapsedY = 242;
        private const int ReturnPanelExpandedY = 551;
        private const int AnimationStep = 25;
        private readonly Timer animationTimer;
        private readonly Timer returnAnimationTimer;
        private int targetHeight;
        private int returnTargetHeight;
        private SelectedFareInfo departureFare;
        private SelectedFareInfo returnFare;

        public frmShoppingCart()
        {
            InitializeComponent();
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;
            returnAnimationTimer = new Timer { Interval = 15 };
            returnAnimationTimer.Tick += ReturnAnimationTimer_Tick;
            InitializeCollapsedState();
            InitializeReturnCollapsedState();
        }

        public frmShoppingCart(SelectedFareInfo departureFare, SelectedFareInfo returnFare = null) : this()
        {
            PopulateDepartureFare(departureFare);
            PopulateReturnFare(returnFare);
        }

        private void pnlArriveFlight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PopulateDepartureFare(SelectedFareInfo fareInfo)
        {
            if (fareInfo?.Flight == null)
            {
                return;
            }

            departureFare = fareInfo;
            var flight = fareInfo.Flight;
            var culture = new CultureInfo("vi-VN");
            TimeSpan duration = CalculateDuration(flight);
            int durationHours = (int)duration.TotalHours;
            int durationMinutes = duration.Minutes;
            string fromName = FormatAirportName(flight.TenSanBayDi, flight.MaSanBayDi);
            string toName = FormatAirportName(flight.TenSanBayDen, flight.MaSanBayDen);

            lblRoute1.Text = $"{fromName} đến {toName}";
            lblDate1.Text = flight.NgayGioBay.ToString("dddd, dd 'tháng' MM, yyyy", culture);
            depTimeLabel1.Text = flight.NgayGioBay.ToString("HH:mm");
            depCodeLabel1.Text = flight.MaSanBayDi;
            depTerminalLabel1.Text = string.Empty;

            arrTimeLabel1.Text = flight.NgayGioDen.ToString("HH:mm");
            arrCodeLabel1.Text = flight.MaSanBayDen;
            arrTerminalLabel1.Text = string.Empty;

            durationLabel.Text = "Bay thẳng";
            durationTime1.Text = $"Thời gian bay {durationHours}h {durationMinutes}phút";
            airlineLabel1.Text = $" ✈️ {flight.MaChuyenBay} khai thác bởi {flight.TenHangBay}";
            TypeLabel1.Text = fareInfo.CabinClass;
            fareType1.Text = fareInfo.CabinClass;
            ApplyFarePerks(fareInfo.CabinClass, lblThayVe1, lblHoanVe1, lblHanhLyKyGui1, lblHanhLyXachTay1);

            string departureTimeline = $"{flight.NgayGioBay:HH:mm} {fromName}";
            string arrivalTimeline = $"{flight.NgayGioDen:HH:mm} {toName}";

            lblDepartureTime1.Text = departureTimeline;
            lblDepartureAirport1.Text = fromName;
            lblDepartureTerminal1.Text = string.Empty;

            lblArrivalTime1.Text = arrivalTimeline;
            lblArrivalAirport1.Text = toName;
            lblArrivalTerminal1.Text = string.Empty;
            lblNextDay1.Visible = flight.NgayGioDen.Date > flight.NgayGioBay.Date;
            lblNextDay1.Text = lblNextDay1.Visible ? "(+1 ngày)" : string.Empty;

            lblAirline1.Text = $"Khai thác bởi {flight.TenHangBay}";
            lblFlightNumberTitle1.Text = $"Số hiệu chuyến bay {flight.MaChuyenBay}";
            lblAircraft1.Text = flight.TenMayBay ?? "Đang cập nhật";
            lblFlightDuration1.Text = $"{durationHours} giờ {durationMinutes} phút";
        }

        private void PopulateReturnFare(SelectedFareInfo fareInfo)
        {
            returnFare = fareInfo;

            if (fareInfo?.Flight == null)
            {
                returnAnimationTimer.Stop();
                pnlReturnFlight.Visible = false;
                guna2Panel2.Visible = false;
                return;
            }

            pnlReturnFlight.Visible = true;
            InitializeReturnCollapsedState();

            var flight = fareInfo.Flight;
            var culture = new CultureInfo("vi-VN");
            TimeSpan duration = CalculateDuration(flight);
            int durationHours = (int)duration.TotalHours;
            int durationMinutes = duration.Minutes;
            string fromName = FormatAirportName(flight.TenSanBayDi, flight.MaSanBayDi);
            string toName = FormatAirportName(flight.TenSanBayDen, flight.MaSanBayDen);

            lblRoute2.Text = $"{fromName} đến {toName}";
            lblDate2.Text = flight.NgayGioBay.ToString("dddd, dd 'tháng' MM, yyyy", culture);
            depTimeLabel2.Text = flight.NgayGioBay.ToString("HH:mm");
            depCodeLabel2.Text = flight.MaSanBayDi;
            depTerminalLabel2.Text = string.Empty;

            arrTimeLabel2.Text = flight.NgayGioDen.ToString("HH:mm");
            arrCodeLabel2.Text = flight.MaSanBayDen;
            arrTerminalLabel2.Text = string.Empty;

            label15.Text = "Bay thẳng";
            durationTime2.Text = $"Thời gian bay {durationHours}h {durationMinutes}phút";
            airlineLabel2.Text = $" ✈️ {flight.MaChuyenBay} khai thác bởi {flight.TenHangBay}";
            TypeLabel2.Text = fareInfo.CabinClass;
            fareType2.Text = fareInfo.CabinClass;

            string departureTimeline = $"{flight.NgayGioBay:HH:mm} {fromName}";
            string arrivalTimeline = $"{flight.NgayGioDen:HH:mm} {toName}";

            lblDepartureTime2.Text = departureTimeline;
            lblDepartureAirport2.Text = fromName;
            lblDepartureTerminal2.Text = string.Empty;

            lblArrivalTime2.Text = arrivalTimeline;
            lblArrivalAirport2.Text = toName;
            lblArrivalTerminal2.Text = string.Empty;
            lblNextDay2.Visible = flight.NgayGioDen.Date > flight.NgayGioBay.Date;
            lblNextDay2.Text = lblNextDay2.Visible ? "(+1 ngày)" : string.Empty;

            lblAirline2.Text = $"Khai thác bởi {flight.TenHangBay}";
            lblFlightNumberTitle2.Text = $"Số hiệu chuyến bay {flight.MaChuyenBay}";
            lblAircraft2.Text = flight.TenMayBay ?? "Đang cập nhật";
            lblFlightDuration2.Text = $"{durationHours} giờ {durationMinutes} phút";
            ApplyFarePerks(fareInfo.CabinClass, lblThayVe2, lblHoanVe2, lblHanhLyKyGui2, lblHanhLyXachTay2);
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

        private void ApplyFarePerks(string cabinClass, Label thayVeLabel, Label hoanVeLabel, Label hanhLyKyGuiLabel, Label hanhLyXachTayLabel)
        {
            string normalized = NormalizeCabinClass(cabinClass);
            switch (normalized)
            {
                case "Premium":
                    thayVeLabel.Text = "🔄 Thay đổi vé: Được phép";
                    hoanVeLabel.Text = "🎫 Hoàn vé: Phí hoàn tối đa 500.000 VND mỗi hành khách cho toàn bộ vé";
                    hanhLyKyGuiLabel.Text = "💼 Hành lý ký gửi: 1 × 32 kg";
                    hanhLyXachTayLabel.Text = "🎒 Hành lý xách tay: 1 × 10 kg";
                    break;
                case "Business":
                    thayVeLabel.Text = "🔄 Thay đổi vé: Phí đổi tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    hoanVeLabel.Text = "🎫 Hoàn vé: Phí hoàn tối đa 1.000.000 VND mỗi hành khách cho toàn bộ vé";
                    hanhLyKyGuiLabel.Text = "💼 Hành lý ký gửi: 1 × 32 kg";
                    hanhLyXachTayLabel.Text = "🎒 Hành lý xách tay: 1 × 18 kg";
                    break;
                default:
                    thayVeLabel.Text = "🔄 Thay đổi vé: Phí đổi tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    hoanVeLabel.Text = "🎫 Hoàn vé: Phí hoàn tối đa 860.000 VND mỗi hành khách cho toàn bộ vé";
                    hanhLyKyGuiLabel.Text = "💼 Hành lý ký gửi: 1 × 23 kg";
                    hanhLyXachTayLabel.Text = "🎒 Hành lý xách tay: 1 × 10 kg";
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
            UpdateReturnPanelLocation();
        }

        private void InitializeReturnCollapsedState()
        {
            pnlReturnFlight.Height = CollapsedHeight;
            guna2Panel2.Visible = false;
            expandbtn2.Text = "˅";
            returnTargetHeight = CollapsedHeight;
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
                UpdateReturnPanelLocation();
            }
        }

        private void expandbtn2_Click(object sender, EventArgs e)
        {
            if (!pnlReturnFlight.Visible || returnAnimationTimer.Enabled)
            {
                return;
            }

            bool expanding = pnlReturnFlight.Height <= CollapsedHeight;
            returnTargetHeight = expanding ? ExpandedHeight : CollapsedHeight;
            expandbtn2.Text = expanding ? "˄" : "˅";

            if (expanding)
            {
                guna2Panel2.Visible = true;
            }

            returnAnimationTimer.Start();
        }

        private void ReturnAnimationTimer_Tick(object sender, EventArgs e)
        {
            int direction = returnTargetHeight > pnlReturnFlight.Height ? 1 : -1;
            int nextHeight = pnlReturnFlight.Height + direction * AnimationStep;

            bool reachedTarget = direction > 0
                ? nextHeight >= returnTargetHeight
                : nextHeight <= returnTargetHeight;

            pnlReturnFlight.Height = reachedTarget ? returnTargetHeight : nextHeight;

            if (reachedTarget)
            {
                returnAnimationTimer.Stop();
                if (returnTargetHeight == CollapsedHeight)
                {
                    guna2Panel2.Visible = false;
                }
            }
        }

        private void UpdateReturnPanelLocation()
        {
            if (pnlReturnFlight == null)
            {
                return;
            }

            int newY = pnlArriveFlight.Height > CollapsedHeight
                ? ReturnPanelExpandedY
                : ReturnPanelCollapsedY;

            pnlReturnFlight.Location = new Point(pnlReturnFlight.Location.X, newY);
        }

        private void detailsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPriceDetails frmPriceDetails = new frmPriceDetails();
            frmPriceDetails.ShowDialog();
        }
    }
}
