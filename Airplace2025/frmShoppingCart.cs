using System;
using Airplace2025.BLL.DTO;
using Airplace2025.State;
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
        private const int PanelSpacing = 30; // Khoảng cách giữa các panel

        private readonly Timer animationTimer;
        private readonly Timer returnAnimationTimer;
        private int targetHeight;
        private int returnTargetHeight;
        private SelectedFareInfo departureFare;
        private SelectedFareInfo returnFare;

        // Constants for fees (per flight sector)
        public const decimal ADULT_SURCHARGE = 1474000m;
        public const decimal CHILD_SURCHARGE = 1322000m;
        public const decimal INFANT_SURCHARGE = 34000m;

        public frmShoppingCart()
        {
            InitializeComponent();
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;
            returnAnimationTimer = new Timer { Interval = 15 };
            returnAnimationTimer.Tick += ReturnAnimationTimer_Tick;
            
            // Initial layout update
            InitializeCollapsedState();
            InitializeReturnCollapsedState();
        }

        public frmShoppingCart(SelectedFareInfo departureFare, SelectedFareInfo returnFare = null) : this()
        {
            PopulateDepartureFare(departureFare);
            PopulateReturnFare(returnFare);
            CalculateTotal();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Kiểm tra các controls quan trọng
            if (pnlArriveFlight == null)
            {
                MessageBox.Show("pnlArriveFlight chưa được khởi tạo!");
                return;
            }

            if (pnlReturnFlight == null)
            {
                MessageBox.Show("pnlReturnFlight chưa được khởi tạo!");
                return;
            }

            if (guna2Panel2 == null)
            {
                MessageBox.Show("guna2Panel2 chưa được khởi tạo!");
                return;
            }

            if (PriceSummaryPanel == null)
            {
                MessageBox.Show("PriceSummaryPanel chưa được khởi tạo!");
                return;
            }

            // Ensure layout is correct when form loads and controls are ready
            UpdateLayoutPositions();
        }

        private void CalculateTotal()
        {
            int adultCount = PassengerSelectionState.Adult;
            int childCount = PassengerSelectionState.Child;
            int infantCount = PassengerSelectionState.Infant;

            decimal total = 0;

            if (departureFare != null)
            {
                total += CalculateFlightTotal(departureFare.FarePrice, adultCount, childCount, infantCount);
            }

            if (returnFare != null)
            {
                total += CalculateFlightTotal(returnFare.FarePrice, adultCount, childCount, infantCount);
            }

            totalPrice1.Text = $"{total:N0} VND";
            totalPrice2.Text = $"{total:N0} VND";
        }

        private decimal CalculateFlightTotal(decimal baseFare, int adults, int children, int infants)
        {
            decimal adultTotal = (baseFare + ADULT_SURCHARGE) * adults;
            decimal childTotal = ((baseFare * 0.9m) + CHILD_SURCHARGE) * children;
            decimal infantTotal = ((baseFare * 0.1m) + INFANT_SURCHARGE) * infants;
            return adultTotal + childTotal + infantTotal;
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
                UpdateLayoutPositions();
                return;
            }

            pnlReturnFlight.Visible = true;
            pnlReturnFlight.BringToFront(); // Ensure it's visible and on top
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
        }

        private void InitializeReturnCollapsedState()
        {
            pnlReturnFlight.Height = CollapsedHeight;
            if (guna2Panel2 != null) // Thêm kiểm tra
            {
                guna2Panel2.Visible = false;
            }
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

            UpdateLayoutPositions();

            if (reachedTarget)
            {
                animationTimer.Stop();
                if (targetHeight == CollapsedHeight)
                {
                    detailsPanel.Visible = false;
                }
            }
        }

        private void expandbtn2_Click(object sender, EventArgs e)
        {
            if (!pnlReturnFlight.Visible || returnAnimationTimer.Enabled || guna2Panel2 == null) // Thêm kiểm tra
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
            try
            {
                int direction = returnTargetHeight > pnlReturnFlight.Height ? 1 : -1;
                int nextHeight = pnlReturnFlight.Height + direction * AnimationStep;

                bool reachedTarget = direction > 0
                    ? nextHeight >= returnTargetHeight
                    : nextHeight <= returnTargetHeight;

                pnlReturnFlight.Height = reachedTarget ? returnTargetHeight : nextHeight;

                UpdateLayoutPositions();

                if (reachedTarget)
                {
                    returnAnimationTimer.Stop();
                    if (returnTargetHeight == CollapsedHeight)
                    {
                        if (guna2Panel2 != null)
                        {
                            guna2Panel2.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("guna2Panel2 is null!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnAnimationTimer.Stop();
                MessageBox.Show($"Lỗi: {ex.Message}\n\nStack Trace: {ex.StackTrace}");
            }
        }

        private void UpdateLayoutPositions()
        {
            if (pnlArriveFlight == null || PriceSummaryPanel == null || panel == null) return;

            // Base Y start position for the first panel (pnlArriveFlight)
            int currentY = pnlArriveFlight.Location.Y + pnlArriveFlight.Height + PanelSpacing;

            // Update pnlReturnFlight if visible and not null
            if (pnlReturnFlight != null && pnlReturnFlight.Visible)
            {
                pnlReturnFlight.Location = new Point(pnlReturnFlight.Location.X, currentY);
                currentY = pnlReturnFlight.Location.Y + pnlReturnFlight.Height + PanelSpacing;
            }

            // Update PriceSummaryPanel
            PriceSummaryPanel.Location = new Point(PriceSummaryPanel.Location.X, currentY);
            currentY = PriceSummaryPanel.Location.Y + PriceSummaryPanel.Height + PanelSpacing;

            // Update Continue Button Panel
            panel.Location = new Point(panel.Location.X, currentY);

            // Optional: Adjust container height if using a container panel inside a ScrollPanel
            if (containerPanel != null)
            {
                int newTotalHeight = panel.Location.Y + panel.Height + 50; // + padding bottom
                if (containerPanel.Height != newTotalHeight)
                {
                    containerPanel.Height = newTotalHeight;
                }
            }
        }

        private void detailsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPriceDetails frmPriceDetails = new frmPriceDetails();
            frmPriceDetails.SetData(departureFare, returnFare);
            frmPriceDetails.ShowDialog();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            using (frmCustomerInfo frmCustomerInfo = new frmCustomerInfo())
            {
                // Pass Flight Info
                frmCustomerInfo.DepartureFlight = departureFare;
                frmCustomerInfo.ReturnFlight = returnFare;

                if (frmCustomerInfo.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. Create Bookings
                        var customers = frmCustomerInfo.SelectedCustomers;
                        var representative = frmCustomerInfo.RepresentativeCustomer;

                        if (customers == null || customers.Count == 0)
                        {
                            MessageBox.Show("Danh sách hành khách trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        List<string> ticketIds = Airplace2025.BLL.DatVeBLL.Instance.ProcessBooking(customers, departureFare, returnFare);

                        if (ticketIds.Count == 0)
                        {
                            MessageBox.Show("Không thể tạo vé. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 2. Calculate Total Price
                        decimal totalAmount = 0;
                        if (decimal.TryParse(totalPrice1.Text.Replace(" VND", "").Replace(",", "").Replace(".", ""), out decimal t1)) totalAmount = t1;
                        // If totalPrice1 and totalPrice2 are same (one label updated both?), check logic.
                        // In CalculateTotal, both are updated. Using one is fine.

                        // 3. Open Payment Form
                        using (frmThanhToan frmPayment = new frmThanhToan(totalAmount, representative.HoTen, ticketIds))
                        {
                            if (frmPayment.ShowDialog() == DialogResult.OK)
                            {
                                // Success
                                // Navigate to Home or Success Page
                                this.Hide();
                                // Assuming we want to close the flow
                                // For now just close this form or reset
                                this.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xử lý đặt vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
