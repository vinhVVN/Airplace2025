using Airplace2025.BLL;
using Airplace2025.BLL.DTO;
using Airplace2025.DAL;
using Airplace2025.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmChonChuyenBayVe : Form
    {
        private string sanBayDi;
        private string sanBayDen;
        private DateTime ngayDi;
        private DateTime ngayVe;
        private string soLuongHanhKhach;
        private bool isRoundTrip;
        private bool isUpdatingCombos = false;
        private List<string> airportOptions = new List<string>();
        private DataTable airportsDisplayTable;
        private List<ChuyenBayDTO> currentFlights = new List<ChuyenBayDTO>();
        private string filterCabin = "Tất cả";
        private decimal filterMaxBudget = decimal.MaxValue;
        private bool filterDirectFlightOnly = false;
        private int filterDepartureTimeSlot = 0;
        private int filterArrivalTimeSlot = 0;
        private List<string> filterAirlines = new List<string>();
        private List<ChuyenBayDTO> originalFlights = new List<ChuyenBayDTO>();
        private decimal minFlightPrice = 0;
        private decimal maxFlightPrice = 0;
        private readonly SelectedFareInfo departureFareInfo;

        public frmChonChuyenBayVe(
            string sanBayDi,
            string sanBayDen,
            DateTime ngayDi,
            DateTime ngayVe,
            string soLuongHanhKhach,
            bool isRoundTrip,
            SelectedFareInfo departureFare = null)
        {
            InitializeComponent();
            this.sanBayDi = sanBayDi;
            this.sanBayDen = sanBayDen;
            this.ngayDi = ngayDi < DateTime.Today ? DateTime.Today : ngayDi;
            this.ngayVe = ngayVe < DateTime.Today ? DateTime.Today : ngayVe;
            this.soLuongHanhKhach = soLuongHanhKhach;
            this.isRoundTrip = isRoundTrip;
            this.departureFareInfo = departureFare;
            LoadFlights();
        }

        private void frmChonChuyenBayVe_Load(object sender, EventArgs e)
        {
            LoadAirportsToCombos();

            if (!string.IsNullOrEmpty(sanBayDi))
            {
                lblFrom.Text = sanBayDi;
                TrySelectComboValue(cbSanBayDi, sanBayDi);
            }

            if (!string.IsNullOrEmpty(sanBayDen) && !string.Equals(sanBayDi, sanBayDen, StringComparison.OrdinalIgnoreCase))
            {
                lblTo.Text = sanBayDen;
                TrySelectComboValue(cbSanBayDen, sanBayDen);
            }

            dtpNgayDi.MinDate = DateTime.Today;
            dtpNgayVe.MinDate = DateTime.Today;

            dtpNgayDi.Value = ngayDi;
            dtpNgayVe.Value = ngayVe;

            dtpDeparture.Text = FormatDate(dtpNgayDi.Value);
            dtpReturn.Text = FormatDate(dtpNgayVe.Value);

            lblTotalPassengers.Text = FormatPassengerCount(soLuongHanhKhach);
            btnTotalCustomers.Text = FormatTotalPassengerCount(soLuongHanhKhach);

            if (isRoundTrip)
            {
                btnRoundTrip.Checked = true;
                btnOneWay.Checked = false;
                pnlRoundTrip.Visible = true;
                pnlOneWay.Visible = false;
                lblReturn.Visible = true;
                dtpReturn.Visible = true;
            }
            else
            {
                btnRoundTrip.Checked = false;
                btnOneWay.Checked = true;
                pnlRoundTrip.Visible = false;
                pnlOneWay.Visible = true;
                lblReturn.Visible = false;
                dtpReturn.Visible = false;
            }

            pnlChonChuyenBay.Location = new System.Drawing.Point(0, 100);
            LoadFlights();
        }

        private void LoadAirportsToCombos()
        {
            try
            {
                DataTable airports = ChuyenBayDAO.Instance.GetAirports();
                DataTable buildDisplay(DataTable src)
                {
                    DataTable dt = src.Copy();
                    if (!dt.Columns.Contains("Display"))
                    {
                        dt.Columns.Add("Display", typeof(string));
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        string code = row["MaSanBay"].ToString();
                        string name = row["TenSanBay"].ToString();
                        row["Display"] = string.IsNullOrWhiteSpace(name) ? code : ($"{code} - {name}");
                    }
                    return dt;
                }

                airportsDisplayTable = buildDisplay(airports);

                cbSanBayDi.DisplayMember = "Display";
                cbSanBayDi.ValueMember = "MaSanBay";
                cbSanBayDi.DataSource = airportsDisplayTable.Copy();

                cbSanBayDen.DisplayMember = "Display";
                cbSanBayDen.ValueMember = "MaSanBay";
                cbSanBayDen.DataSource = airportsDisplayTable.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFromLabel()
        {
            string code = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            if (!string.IsNullOrWhiteSpace(code))
            {
                lblFrom.Text = code;
            }
        }

        private string GetSelectedAirportCode(object selectedValue, object selectedItem)
        {
            if (selectedValue != null)
            {
                return selectedValue.ToString();
            }
            if (selectedItem != null)
            {
                var text = selectedItem.ToString();
                int dash = text.IndexOf(" - ");
                if (dash > 0) return text.Substring(0, dash).Trim();
                return text.Trim();
            }
            return string.Empty;
        }

        private void TrySelectComboValue(ComboBox combo, string value)
        {
            try
            {
                if (combo.DataSource != null && !string.IsNullOrWhiteSpace(value))
                {
                    combo.SelectedValue = value;
                }
            }
            catch { }
        }

        private string FormatDate(DateTime date)
        {
            string[] thuViet = { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
            string thu = thuViet[(int)date.DayOfWeek];

            return $"{thu}, {date.Day:D2} thg {date.Month:D2}";
        }

        private string FormatPassengerCount(string passengerText)
        {
            if (string.IsNullOrEmpty(passengerText))
                return "1 người";

            string number = ExtractNumberFromText(passengerText);

            return $"{number} người";
        }

        private string FormatTotalPassengerCount(string passengerText)
        {
            if (string.IsNullOrEmpty(passengerText))
                return "1 hành khách";

            string number = ExtractNumberFromText(passengerText);

            return $"{number} hành khách";
        }

        private string ExtractNumberFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "1";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    int start = i;
                    while (i < text.Length && char.IsDigit(text[i]))
                    {
                        i++;
                    }
                    return text.Substring(start, i - start);
                }
            }

            return "1";
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnChange.Checked;
            lblDown.Visible = !isExpanded;
            lblUp.Visible = isExpanded;
            pnlChange.Visible = isExpanded;

            if (isExpanded)
            {
                pnlChonChuyenBay.Location = new System.Drawing.Point(0, 306);
                if (isRoundTrip)
                {
                    btnRoundTrip.Checked = true;
                    btnOneWay.Checked = false;
                }
                else
                {
                    btnRoundTrip.Checked = false;
                    btnOneWay.Checked = true;
                }
            }
            else
            {
                pnlChonChuyenBay.Location = new System.Drawing.Point(0, 100);
            }
        }

        private void btnTotalCustomers_Click(object sender, EventArgs e)
        {
            frmSoLuongKhachHang soLuongKhachHangForm = new frmSoLuongKhachHang();
            soLuongKhachHangForm.ShowDialog(this);

            int total = PassengerSelectionStateTemp.Total;
            btnTotalCustomers.Text = $"{total} Hành khách";
        }

        private void btnRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            bool isRoundTripView = btnRoundTrip.Checked;
            lblReturnDate.Visible = isRoundTripView;
            dtpNgayVe.Visible = isRoundTripView;
        }

        private void btnOneWay_CheckedChanged(object sender, EventArgs e)
        {
            if (btnOneWay.Checked)
            {
                lblReturnDate.Visible = false;
                dtpNgayVe.Visible = false;
            }
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionStateTemp.Adult);
            PassengerSelectionState.SetChild(PassengerSelectionStateTemp.Child);
            PassengerSelectionState.SetInfant(PassengerSelectionStateTemp.Infant);

            string newSanBayDi = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            string newSanBayDen = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
            DateTime newNgayDi = dtpNgayDi.Value;
            DateTime newNgayVe = dtpNgayVe.Value;
            int total = PassengerSelectionStateTemp.Total;
            string newSoLuongHanhKhach = $"{total} hành khách";
            bool newIsRoundTrip = btnRoundTrip.Checked;

            this.DialogResult = DialogResult.OK;

            frmChonChuyenBayVe newForm = new frmChonChuyenBayVe(
                newSanBayDi,
                newSanBayDen,
                newNgayDi,
                newNgayVe,
                newSoLuongHanhKhach,
                newIsRoundTrip,
                departureFareInfo
            );

            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayVe.MinDate = dtpNgayDi.Value.Date;
            ValidateReturnDate();
        }

        private void dtpNgayVe_ValueChanged(object sender, EventArgs e)
        {
            ValidateReturnDate();
        }

        private void ValidateReturnDate()
        {
            if (dtpNgayVe.Value < dtpNgayDi.Value)
            {
                dtpNgayVe.Value = dtpNgayDi.Value;
            }
        }

        private void cbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingCombos) return;
            try
            {
                isUpdatingCombos = true;

                string selectedFromCode = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
                string currentToCode = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);

                if (airportsDisplayTable != null)
                {
                    string escaped = (selectedFromCode ?? string.Empty).Replace("'", "''");
                    var view = new DataView(airportsDisplayTable);
                    view.RowFilter = string.IsNullOrWhiteSpace(escaped) ? string.Empty : $"MaSanBay <> '{escaped}'";

                    cbSanBayDen.DisplayMember = "Display";
                    cbSanBayDen.ValueMember = "MaSanBay";
                    cbSanBayDen.DataSource = view;

                    if (!string.IsNullOrWhiteSpace(currentToCode) && !string.Equals(currentToCode, selectedFromCode, StringComparison.OrdinalIgnoreCase))
                    {
                        TrySelectComboValue(cbSanBayDen, currentToCode);
                    }
                    else
                    {
                        cbSanBayDen.SelectedIndex = -1;
                    }
                }

                UpdateFromLabel();
            }
            finally
            {
                isUpdatingCombos = false;
            }
            cbSanBayDi.Invalidate();
            UpdateEditButton();
            LoadFlights();
        }

        private void cbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEditButton();
            LoadFlights();
        }

        private void UpdateEditButton()
        {
            btnEditSave.Enabled = ValidateForm();
        }

        private bool ValidateForm()
        {
            if (cbSanBayDi.SelectedIndex < 0 || cbSanBayDi.SelectedItem == null)
            {
                return false;
            }

            if (cbSanBayDen.SelectedIndex < 0 || cbSanBayDen.SelectedItem == null)
            {
                return false;
            }

            string fromCode = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            string toCode = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);

            if (string.Equals(fromCode, toCode, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            filterForm.SetPriceRange(minFlightPrice, maxFlightPrice);

            if (filterForm.ShowDialog(this) == DialogResult.OK)
            {
                filterCabin = filterForm.SelectedCabin;
                filterMaxBudget = filterForm.MaxBudget;
                filterDirectFlightOnly = filterForm.DirectFlightOnly;
                filterDepartureTimeSlot = filterForm.DepartureTimeSlot;
                filterArrivalTimeSlot = filterForm.ArrivalTimeSlot;
                filterAirlines = filterForm.SelectedAirlines;

                currentFlights = new List<ChuyenBayDTO>(originalFlights);

                ApplyFilters();
                ApplySorting();
                RenderFlights(currentFlights);
            }
        }

        private void LoadFlights()
        {
            try
            {
                if (!ValidateForm())
                {
                    RenderFlights(new List<ChuyenBayDTO>());
                    return;
                }

                string maSanBayDi = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
                string maSanBayDen = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
                DateTime searchDate = dtpNgayVe.Value.Date;

                if (searchDate < DateTime.Today)
                {
                    dtpNgayVe.Value = DateTime.Today;
                    searchDate = DateTime.Today;
                }

                int soNguoiLon = PassengerSelectionStateTemp.Adult;
                int soTreEm = PassengerSelectionStateTemp.Child;
                int soGheCan = Math.Max(1, soNguoiLon + soTreEm);

                var flights = ChuyenBayBLL.Instance.TimKiemChuyenBay(maSanBayDi, maSanBayDen, searchDate, soGheCan);

                originalFlights = flights != null ? new List<ChuyenBayDTO>(flights) : new List<ChuyenBayDTO>();
                currentFlights = flights ?? new List<ChuyenBayDTO>();

                CalculateMinMaxPrice();
                UpdateFilterSortVisibility();
                ApplyFilters();
                ApplySorting();
                RenderFlights(currentFlights);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RenderFlights(new List<ChuyenBayDTO>());
            }
        }

        /// <summary>
        /// Tính min/max giá vé từ danh sách chuyến bay (tất cả các hạng vé)
        /// </summary>
        private void CalculateMinMaxPrice()
        {
            if (originalFlights == null || originalFlights.Count == 0)
            {
                minFlightPrice = 0;
                maxFlightPrice = 0;
                return;
            }

            // Thu thập tất cả giá vé từ tất cả các hạng (Economy, Premium, Business)
            var allPrices = new List<decimal>();
            
            foreach (var flight in originalFlights)
            {
                // Thêm giá Economy nếu có
                if (flight.GiaEconomy.HasValue && flight.GiaEconomy > 0)
                    allPrices.Add(flight.GiaEconomy.Value);
                
                // Thêm giá Premium nếu có
                if (flight.GiaPremium.HasValue && flight.GiaPremium > 0)
                    allPrices.Add(flight.GiaPremium.Value);
                
                // Thêm giá Business nếu có
                if (flight.GiaBusiness.HasValue && flight.GiaBusiness > 0)
                    allPrices.Add(flight.GiaBusiness.Value);
                
                // Nếu không có giá nào, dùng GiaCoBan
                if (allPrices.Count == 0 && flight.GiaCoBan > 0)
                    allPrices.Add(flight.GiaCoBan);
            }

            if (allPrices.Count > 0)
            {
                minFlightPrice = allPrices.Min();
                maxFlightPrice = allPrices.Max();
            }
            else
            {
                minFlightPrice = 0;
                maxFlightPrice = 0;
            }
        }

        private void UpdateFilterSortVisibility()
        {
            bool hasFlights = originalFlights != null && originalFlights.Count > 0;

            btnFilter.Visible = hasFlights;
            cboSortType.Visible = hasFlights;
            lblSapXep.Visible = hasFlights;
        }

        private void RenderFlights(List<ChuyenBayDTO> flights)
        {
            try
            {
                tlpFlights.SuspendLayout();
                tlpFlights.Controls.Clear();
                tlpFlights.RowStyles.Clear();
                tlpFlights.AutoScroll = true;
                tlpFlights.ColumnCount = 1;
                tlpFlights.RowCount = 0;
                tlpFlights.Dock = DockStyle.None;
                tlpFlights.ColumnStyles.Clear();
                tlpFlights.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                if (flights == null || flights.Count == 0)
                {
                    Label lblNoFlights = new Label
                    {
                        Text = "Không tìm thấy chuyến bay phù hợp",
                        Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Regular),
                        ForeColor = Color.Gray,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Height = 100
                    };
                    tlpFlights.RowCount = 1;
                    tlpFlights.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tlpFlights.Controls.Add(lblNoFlights, 0, 0);
                }
                else
                {
                    foreach (var flight in flights)
                    {
                        var card = new FlightCard();

                        var duration = flight.NgayGioDen > flight.NgayGioBay
                            ? (flight.NgayGioDen - flight.NgayGioBay)
                            : TimeSpan.FromMinutes(Math.Max(0, flight.ThoiGianBay));

                        int hours = (int)duration.TotalHours;
                        int minutes = duration.Minutes;

                        bool isNextDay = flight.NgayGioDen.Date > flight.NgayGioBay.Date;

                        card.DepartureTime = flight.NgayGioBay.ToString("HH:mm");
                        card.DepartureCity = flight.MaSanBayDi;
                        card.DepartureTerminal = "";
                        card.ArrivalTime = flight.NgayGioDen.ToString("HH:mm");
                        card.ArrivalCity = flight.MaSanBayDen;
                        card.ArrivalTerminal = "";
                        card.Duration = $"⏱ Thời gian bay {hours}h {minutes}phút";
                        card.Airline = $"✈ {flight.MaChuyenBay} Khai thác bởi {flight.TenHangBay}";

                        decimal economyPrice = flight.GiaEconomy ?? flight.GiaCoBan;
                        decimal premiumPrice = flight.GiaPremium ?? (flight.GiaCoBan * 1.5m);
                        decimal businessPrice = flight.GiaBusiness ?? (flight.GiaCoBan * 2.5m);

                        card.EconomyPrice = string.Format("{0:#,##0}", economyPrice);
                        card.PremiumPrice = string.Format("{0:#,##0}", premiumPrice);
                        card.BusinessPrice = string.Format("{0:#,##0}", businessPrice);
                        card.EconomyPriceValue = economyPrice;
                        card.PremiumPriceValue = premiumPrice;
                        card.BusinessPriceValue = businessPrice;
                        card.FlightData = flight;
                        card.EconomySeats = flight.GheEconomy ?? flight.SoGheTrong;
                        card.PremiumSeats = flight.GhePremium ?? 0;
                        card.BusinessSeats = flight.GheBusiness ?? 0;

                        card.DepartureDate = "Khởi hành vào " + flight.NgayGioBay.ToString("dddd, dd 'tháng' MM, yyyy", new System.Globalization.CultureInfo("vi-VN"));
                        card.ArrivalDate = "Đến vào " + flight.NgayGioDen.ToString("dddd, dd 'tháng' MM, yyyy", new System.Globalization.CultureInfo("vi-VN"));
                        card.FlightNumber = flight.MaChuyenBay;
                        card.Aircraft = flight.TenMayBay ?? "N/A";
                        card.IsNextDay = isNextDay;
                        card.DepartureAirport = flight.TenSanBayDi;
                        card.ArrivalAirport = flight.TenSanBayDen;

                        // Áp dụng bộ lọc khoang - disable các panel không được chọn
                        card.SetCabinFilter(filterCabin);

                        card.Margin = new Padding(5, 10, 5, 10);
                        card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        card.FareSelected += FlightCard_FareSelected;

                        tlpFlights.RowCount += 1;
                        tlpFlights.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        tlpFlights.Controls.Add(card, 0, tlpFlights.RowCount - 1);
                    }
                }

                tlpFlights.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            if (originalFlights == null || originalFlights.Count == 0)
            {
                currentFlights = new List<ChuyenBayDTO>();
                return;
            }

            var filteredFlights = originalFlights.AsEnumerable();

            if (filterCabin != "Tất cả")
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    if (filterCabin == "PHỔ THÔNG")
                        return (f.GheEconomy ?? 0) > 0;
                    else if (filterCabin == "PHỔ THÔNG ĐẶC BIỆT")
                        return (f.GhePremium ?? 0) > 0;
                    else if (filterCabin == "THƯƠNG GIA")
                        return (f.GheBusiness ?? 0) > 0;
                    return true;
                });
            }

            if (filterMaxBudget != decimal.MaxValue)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    decimal economyPrice = f.GiaEconomy ?? f.GiaCoBan;
                    return economyPrice <= filterMaxBudget;
                });
            }

            if (filterDirectFlightOnly)
            {
                filteredFlights = filteredFlights.Where(f => f.ThoiGianBay > 0);
            }

            if (filterDepartureTimeSlot != 0)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    int hour = f.NgayGioBay.Hour;
                    switch (filterDepartureTimeSlot)
                    {
                        case 1:
                            return hour >= 0 && hour < 12;
                        case 2:
                            return hour >= 12 && hour < 18;
                        case 3:
                            return hour >= 18 && hour < 24;
                        default:
                            return true;
                    }
                });
            }

            if (filterArrivalTimeSlot != 0)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    int hour = f.NgayGioDen.Hour;
                    switch (filterArrivalTimeSlot)
                    {
                        case 1:
                            return hour >= 0 && hour < 12;
                        case 2:
                            return hour >= 12 && hour < 18;
                        case 3:
                            return hour >= 18 && hour < 24;
                        default:
                            return true;
                    }
                });
            }

            if (filterAirlines != null && filterAirlines.Count > 0 && !filterAirlines.Contains("All"))
            {
                filteredFlights = filteredFlights.Where(f =>
                    filterAirlines.Any(airline => f.TenHangBay?.Contains(airline) == true)
                );
            }

            currentFlights = filteredFlights.ToList();
        }

        private void ApplySorting()
        {
            if (currentFlights == null || currentFlights.Count == 0)
                return;

            string sortType = cboSortType.SelectedItem?.ToString() ?? "Mặc định";

            switch (sortType)
            {
                case "Rẻ nhất":
                    currentFlights = currentFlights
                        .OrderBy(f => f.GiaEconomy ?? f.GiaCoBan)
                        .ToList();
                    break;

                case "Thời gian khởi hành tăng dần":
                    currentFlights = currentFlights
                        .OrderBy(f => f.NgayGioBay)
                        .ToList();
                    break;

                case "Thời gian khởi hành giảm dần":
                    currentFlights = currentFlights
                        .OrderByDescending(f => f.NgayGioBay)
                        .ToList();
                    break;

                case "Thời gian bay tăng dần":
                    currentFlights = currentFlights
                        .OrderBy(f =>
                        {
                            if (f.NgayGioDen > f.NgayGioBay)
                                return (f.NgayGioDen - f.NgayGioBay).TotalMinutes;
                            return f.ThoiGianBay;
                        })
                        .ToList();
                    break;

                case "Mặc định":
                default:
                    break;
            }
        }

        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySorting();
            RenderFlights(currentFlights);
        }

        private void FlightCard_FareSelected(object sender, SelectedFareEventArgs e)
        {
            if (e?.FareInfo == null)
            {
                return;
            }

            Action<SelectedFareInfo> onConfirm = info =>
            {
                if (departureFareInfo != null)
                {
                    using (var cart = new frmShoppingCart(departureFareInfo, info))
                    {
                        cart.ShowDialog(this);
                    }
                }
                else
                {
                    using (var cart = new frmShoppingCart(info))
                    {
                        cart.ShowDialog(this);
                    }
                }

                Close();
            };

            void ShowTicketDetails()
            {
                using (var detail = new frmChiTietVe(e.FareInfo, onConfirm))
                {
                    detail.ShowDialog(this);
                }
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action(ShowTicketDetails));
            }
            else
            {
                ShowTicketDetails();
            }
        }
    }
}
