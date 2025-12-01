using Guna.UI2.WinForms;
using Airplace2025.BLL.DTO;
using Airplace2025.State;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmPriceDetails : Form
    {
        public frmPriceDetails()
        {
            InitializeComponent();
            
            // Form settings
            this.BackColor = Color.FromArgb(240, 240, 240);
            
            // Clear any designer placeholder items
            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
            }
        }

        public void SetData(SelectedFareInfo depFare, SelectedFareInfo retFare)
        {
            contentPanel.Controls.Clear();

            int flightCount = (depFare != null ? 1 : 0) + (retFare != null ? 1 : 0);
            if (flightCount == 0) return;

            decimal baseFareDep = depFare?.FarePrice ?? 0;
            decimal baseFareRet = retFare?.FarePrice ?? 0;

            // --- Adults ---
            int adultCount = PassengerSelectionState.Adult;
            if (adultCount > 0)
            {
                // Calculate Adult Costs
                decimal adultBase = baseFareDep + baseFareRet;
                decimal airlineSurcharge = 900000m * flightCount;
                decimal airportFees = 574000m * flightCount; // 198k + 40k + 336k
                decimal totalAdult = adultBase + airlineSurcharge + airportFees;
                decimal grandTotalAdult = totalAdult * adultCount;

                AddPassengerItem($"{adultCount} Người lớn", $"{grandTotalAdult:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{adultBase:N0} VND", new[] { ("Giá vé", $"{adultBase:N0} VND") }),
                    ("Phụ thu của hãng hàng không", $"{airlineSurcharge:N0} VND", new[] { ("Phụ thu quản trị hệ thống", $"{airlineSurcharge:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{airportFees:N0} VND", new[]
                    {
                        ("Phí dịch vụ hành khách chặng nội địa, Việt Nam", $"{198000m * flightCount:N0} VND"),
                        ("Phí soi chiếu an ninh hành khách và hành lý, Việt Nam", $"{40000m * flightCount:N0} VND"),
                        ("Thuế giá trị gia tăng, Việt Nam", $"{336000m * flightCount:N0} VND")
                    })
                });
            }

            // --- Children ---
            int childCount = PassengerSelectionState.Child;
            if (childCount > 0)
            {
                // Calculate Child Costs (90% of base)
                decimal childBase = (baseFareDep * 0.9m) + (baseFareRet * 0.9m);
                decimal airlineSurcharge = 900000m * flightCount;
                decimal airportFees = 422000m * flightCount; // 99k + 20k + 303k
                decimal totalChild = childBase + airlineSurcharge + airportFees;
                decimal grandTotalChild = totalChild * childCount;

                AddPassengerItem($"{childCount} Trẻ em", $"{grandTotalChild:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{childBase:N0} VND", new[] { ("Giá vé", $"{childBase:N0} VND") }),
                    ("Phụ thu của hãng hàng không", $"{airlineSurcharge:N0} VND", new[] { ("Phụ thu quản trị hệ thống", $"{airlineSurcharge:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{airportFees:N0} VND", new[]
                    {
                        ("Phí dịch vụ hành khách chặng nội địa, Việt Nam", $"{99000m * flightCount:N0} VND"),
                        ("Phí soi chiếu an ninh hành khách và hành lý, Việt Nam", $"{20000m * flightCount:N0} VND"),
                        ("Thuế giá trị gia tăng, Việt Nam", $"{303000m * flightCount:N0} VND")
                    })
                });
            }

            // --- Infants ---
            int infantCount = PassengerSelectionState.Infant;
            if (infantCount > 0)
            {
                // Calculate Infant Costs (10% of base)
                decimal infantBase = (baseFareDep * 0.1m) + (baseFareRet * 0.1m);
                decimal tax = 34000m * flightCount;
                decimal totalInfant = infantBase + tax;
                decimal grandTotalInfant = totalInfant * infantCount;

                AddPassengerItem($"{infantCount} Trẻ em (Sơ sinh)", $"{grandTotalInfant:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{infantBase:N0} VND", new[] { ("Giá vé", $"{infantBase:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{tax:N0} VND", new[]
                    {
                        ("Thuế giá trị gia tăng, Việt Nam", $"{tax:N0} VND")
                    })
                });
            }
            
            // Update total summary
            decimal total = 0;
            // Re-calculate total to be sure (or pass it from ShoppingCart)
            // Adults
            total += ((baseFareDep + baseFareRet) + (1474000m * flightCount)) * adultCount;
            // Children
            total += (((baseFareDep + baseFareRet) * 0.9m) + (1322000m * flightCount)) * childCount;
            // Infants
            total += (((baseFareDep + baseFareRet) * 0.1m) + (34000m * flightCount)) * infantCount;

            totalPriceLabel.Text = $"{total:N0} VND";
        }

        private void AddPassengerItem(string passengerType, string totalPrice, (string category, string price, (string item, string price)[] items)[] breakdown)
        {
            // Calculate width to avoid horizontal scrollbar if vertical one appears
            int itemWidth = contentPanel.Width - 50 - 20; 

            // Create collapsible passenger panel
            Guna2Panel passengerPanel = new Guna2Panel
            {
                Width = itemWidth,
                Height = 60,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderThickness = 1,
                Margin = new Padding(0, 5, 0, 5),
                Cursor = Cursors.Hand
            };

            Label passengerLabel = new Label
            {
                Text = passengerType,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 102),
                Location = new Point(15, 18),
                AutoSize = true
            };
            passengerPanel.Controls.Add(passengerLabel);

            Label priceLabel = new Label
            {
                Text = totalPrice,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 102),
                Location = new Point(passengerPanel.Width - 200, 18),
                AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            passengerPanel.Controls.Add(priceLabel);

            Label arrowLabel = new Label
            {
                Text = "˅",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 102, 102),
                Location = new Point(passengerPanel.Width - 40, 15),
                AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            passengerPanel.Controls.Add(arrowLabel);

            // Details panel (hidden initially)
            Guna2Panel detailsPanel = new Guna2Panel
            {
                Width = itemWidth,
                AutoSize = true,
                FillColor = Color.FromArgb(250, 250, 250),
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderThickness = 1,
                Visible = false,
                Padding = new Padding(15),
                Margin = new Padding(0, 0, 0, 5)
            };

            FlowLayoutPanel detailsFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true
            };
            detailsPanel.Controls.Add(detailsFlow);

            // Add breakdown items
            foreach (var category in breakdown)
            {
                // Category header
                Guna2Panel categoryPanel = new Guna2Panel
                {
                    Width = detailsFlow.Width - 30, // Adjust for internal padding
                    Height = 50,
                    FillColor = Color.Transparent,
                    Margin = new Padding(0, 10, 0, 0)
                };

                Label categoryLabel = new Label
                {
                    Text = category.category,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    Width = 600
                };
                categoryPanel.Controls.Add(categoryLabel);

                Label categoryPrice = new Label
                {
                    Text = category.price,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(categoryPanel.Width - 150, 10),
                    AutoSize = true,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top
                };
                categoryPanel.Controls.Add(categoryPrice);

                detailsFlow.Controls.Add(categoryPanel);

                // Add sub-items
                foreach (var item in category.items)
                {
                    Guna2Panel itemPanel = new Guna2Panel
                    {
                        Width = detailsFlow.Width - 30,
                        Height = 35,
                        FillColor = Color.Transparent,
                        Margin = new Padding(20, 0, 0, 0)
                    };

                    Label itemLabel = new Label
                    {
                        Text = item.item,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        Location = new Point(10, 8),
                        Width = 600
                    };
                    itemPanel.Controls.Add(itemLabel);

                    Label itemPrice = new Label
                    {
                        Text = item.price,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        Location = new Point(itemPanel.Width - 150, 8),
                        AutoSize = true,
                        Anchor = AnchorStyles.Right | AnchorStyles.Top
                    };
                    itemPanel.Controls.Add(itemPrice);

                    detailsFlow.Controls.Add(itemPanel);
                }

                // Add separator line
                Guna2Separator separator = new Guna2Separator
                {
                    Width = detailsFlow.Width - 30,
                    FillColor = Color.FromArgb(230, 230, 230),
                    Margin = new Padding(0, 5, 0, 5)
                };
                detailsFlow.Controls.Add(separator);
            }

            // Toggle visibility on click
            bool isExpanded = false;
            EventHandler toggleHandler = (s, e) =>
            {
                isExpanded = !isExpanded;
                detailsPanel.Visible = isExpanded;
                arrowLabel.Text = isExpanded ? "˄" : "˅";
            };

            passengerPanel.Click += toggleHandler;
            passengerLabel.Click += toggleHandler;
            priceLabel.Click += toggleHandler;
            arrowLabel.Click += toggleHandler;

            contentPanel.Controls.Add(passengerPanel);
            contentPanel.Controls.Add(detailsPanel);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
