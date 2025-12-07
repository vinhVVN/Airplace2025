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
                // Calculate Adult Costs - Sử dụng constants từ frmShoppingCart
                decimal adultBase = baseFareDep + baseFareRet;
                decimal fuelSurcharge = 200000m * flightCount;      // Phụ thu nhiên liệu
                decimal airportFee = 100000m * flightCount;         // Phí sân bay
                decimal securityFee = 50000m * flightCount;         // Phí an ninh
                decimal vatTax = 100000m * flightCount;             // Thuế VAT
                decimal totalSurcharge = fuelSurcharge + airportFee + securityFee + vatTax; // = 450,000 VND/chặng
                decimal totalAdult = adultBase + totalSurcharge;
                decimal grandTotalAdult = totalAdult * adultCount;

                AddPassengerItem($"{adultCount} Người lớn", $"{grandTotalAdult:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{adultBase:N0} VND", new[] { ("Giá vé", $"{adultBase:N0} VND") }),
                    ("Phụ thu của hãng hàng không", $"{fuelSurcharge:N0} VND", new[] { ("Phụ thu nhiên liệu", $"{fuelSurcharge:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{(airportFee + securityFee + vatTax):N0} VND", new[]
                    {
                        ("Phí dịch vụ sân bay, Việt Nam", $"{airportFee:N0} VND"),
                        ("Phí soi chiếu an ninh hành khách và hành lý", $"{securityFee:N0} VND"),
                        ("Thuế giá trị gia tăng, Việt Nam", $"{vatTax:N0} VND")
                    })
                });
            }

            // --- Children ---
            int childCount = PassengerSelectionState.Child;
            if (childCount > 0)
            {
                // Calculate Child Costs (90% of base) - ~85% phụ thu người lớn
                decimal childBase = (baseFareDep * 0.9m) + (baseFareRet * 0.9m);
                decimal fuelSurcharge = 170000m * flightCount;      // Phụ thu nhiên liệu
                decimal airportFee = 85000m * flightCount;          // Phí sân bay
                decimal securityFee = 40000m * flightCount;         // Phí an ninh
                decimal vatTax = 85000m * flightCount;              // Thuế VAT
                decimal totalSurcharge = fuelSurcharge + airportFee + securityFee + vatTax; // = 380,000 VND/chặng
                decimal totalChild = childBase + totalSurcharge;
                decimal grandTotalChild = totalChild * childCount;

                AddPassengerItem($"{childCount} Trẻ em", $"{grandTotalChild:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{childBase:N0} VND", new[] { ("Giá vé (90%)", $"{childBase:N0} VND") }),
                    ("Phụ thu của hãng hàng không", $"{fuelSurcharge:N0} VND", new[] { ("Phụ thu nhiên liệu", $"{fuelSurcharge:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{(airportFee + securityFee + vatTax):N0} VND", new[]
                    {
                        ("Phí dịch vụ sân bay, Việt Nam", $"{airportFee:N0} VND"),
                        ("Phí soi chiếu an ninh hành khách và hành lý", $"{securityFee:N0} VND"),
                        ("Thuế giá trị gia tăng, Việt Nam", $"{vatTax:N0} VND")
                    })
                });
            }

            // --- Infants ---
            int infantCount = PassengerSelectionState.Infant;
            if (infantCount > 0)
            {
                // Calculate Infant Costs (10% of base) - Chỉ thuế và phí cơ bản
                decimal infantBase = (baseFareDep * 0.1m) + (baseFareRet * 0.1m);
                decimal vatTax = 80000m * flightCount;              // Thuế VAT
                decimal securityFee = 40000m * flightCount;         // Phí an ninh
                decimal totalSurcharge = vatTax + securityFee;      // = 120,000 VND/chặng
                decimal totalInfant = infantBase + totalSurcharge;
                decimal grandTotalInfant = totalInfant * infantCount;

                AddPassengerItem($"{infantCount} Trẻ em (Sơ sinh)", $"{grandTotalInfant:N0} VND", new[]
                {
                    ("Phí vận chuyển hàng không", $"{infantBase:N0} VND", new[] { ("Giá vé (10%)", $"{infantBase:N0} VND") }),
                    ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", $"{totalSurcharge:N0} VND", new[]
                    {
                        ("Thuế giá trị gia tăng, Việt Nam", $"{vatTax:N0} VND"),
                        ("Phí soi chiếu an ninh", $"{securityFee:N0} VND")
                    })
                });
            }
            
            // Update total summary - Sử dụng cùng giá trị với frmShoppingCart
            decimal total = 0;
            // Re-calculate total to be sure (or pass it from ShoppingCart)
            // Adults: giá vé + 450,000 VND phụ thu/chặng
            total += ((baseFareDep + baseFareRet) + (frmShoppingCart.ADULT_SURCHARGE * flightCount)) * adultCount;
            // Children: 90% giá vé + 380,000 VND phụ thu/chặng
            total += (((baseFareDep + baseFareRet) * 0.9m) + (frmShoppingCart.CHILD_SURCHARGE * flightCount)) * childCount;
            // Infants: 10% giá vé + 120,000 VND phụ thu/chặng
            total += (((baseFareDep + baseFareRet) * 0.1m) + (frmShoppingCart.INFANT_SURCHARGE * flightCount)) * infantCount;

            totalPriceLabel.Text = $"{total:N0} VND";
        }

        private void AddPassengerItem(string passengerType, string totalPrice, (string category, string price, (string item, string price)[] items)[] breakdown)
        {
            // Calculate width to avoid horizontal scrollbar if vertical one appears
            int itemWidth = contentPanel.Width - 70;

            // Create collapsible passenger panel
            Guna2Panel passengerPanel = new Guna2Panel
            {
                Width = itemWidth,
                Height = 65,
                FillColor = Color.FromArgb(0, 102, 153),
                BorderRadius = 8,
                Margin = new Padding(0, 8, 0, 0),
                Cursor = Cursors.Hand
            };

            Label passengerLabel = new Label
            {
                Text = "👤 " + passengerType,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 20),
                AutoSize = true
            };
            passengerPanel.Controls.Add(passengerLabel);

            Label priceLabel = new Label
            {
                Text = totalPrice,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 215, 0),
                Location = new Point(passengerPanel.Width - 220, 20),
                AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            passengerPanel.Controls.Add(priceLabel);

            Label arrowLabel = new Label
            {
                Text = "▼",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(passengerPanel.Width - 40, 22),
                AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            passengerPanel.Controls.Add(arrowLabel);

            // Details panel (hidden initially)
            Guna2Panel detailsPanel = new Guna2Panel
            {
                Width = itemWidth,
                AutoSize = true,
                FillColor = Color.FromArgb(248, 249, 250),
                BorderColor = Color.FromArgb(200, 200, 200),
                BorderThickness = 1,
                BorderRadius = 0,
                Visible = false,
                Padding = new Padding(20, 15, 20, 15),
                Margin = new Padding(0, 0, 0, 10)
            };

            FlowLayoutPanel detailsFlow = new FlowLayoutPanel
            {
                Width = itemWidth - 40,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            detailsPanel.Controls.Add(detailsFlow);

            // Add breakdown items
            foreach (var category in breakdown)
            {
                // Category header panel with background
                Guna2Panel categoryPanel = new Guna2Panel
                {
                    Width = itemWidth - 60,
                    Height = 40,
                    FillColor = Color.FromArgb(233, 236, 239),
                    BorderRadius = 5,
                    Margin = new Padding(0, 8, 0, 5)
                };

                Label categoryLabel = new Label
                {
                    Text = "📋 " + category.category,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(33, 37, 41),
                    Location = new Point(15, 10),
                    AutoSize = true
                };
                categoryPanel.Controls.Add(categoryLabel);

                Label categoryPrice = new Label
                {
                    Text = category.price,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 102, 153),
                    Location = new Point(categoryPanel.Width - 150, 10),
                    AutoSize = true,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top
                };
                categoryPanel.Controls.Add(categoryPrice);

                detailsFlow.Controls.Add(categoryPanel);

                // Add sub-items with better styling
                foreach (var item in category.items)
                {
                    Panel itemPanel = new Panel
                    {
                        Width = itemWidth - 80,
                        Height = 30,
                        BackColor = Color.Transparent,
                        Margin = new Padding(25, 2, 0, 2)
                    };

                    Label itemLabel = new Label
                    {
                        Text = "  • " + item.item,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.FromArgb(73, 80, 87),
                        Location = new Point(5, 6),
                        AutoSize = true
                    };
                    itemPanel.Controls.Add(itemLabel);

                    Label itemPrice = new Label
                    {
                        Text = item.price,
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.FromArgb(0, 123, 167),
                        Location = new Point(itemPanel.Width - 130, 6),
                        AutoSize = true,
                        Anchor = AnchorStyles.Right | AnchorStyles.Top
                    };
                    itemPanel.Controls.Add(itemPrice);

                    detailsFlow.Controls.Add(itemPanel);
                }
            }

            // Toggle visibility on click with smooth animation feel
            bool isExpanded = false;
            EventHandler toggleHandler = (s, e) =>
            {
                isExpanded = !isExpanded;
                detailsPanel.Visible = isExpanded;
                arrowLabel.Text = isExpanded ? "▲" : "▼";
                passengerPanel.FillColor = isExpanded 
                    ? Color.FromArgb(0, 82, 123) 
                    : Color.FromArgb(0, 102, 153);
                
                // Scroll to show the expanded details
                if (isExpanded)
                {
                    contentPanel.ScrollControlIntoView(detailsPanel);
                }
            };

            passengerPanel.Click += toggleHandler;
            passengerLabel.Click += toggleHandler;
            priceLabel.Click += toggleHandler;
            arrowLabel.Click += toggleHandler;

            // Hover effects
            passengerPanel.MouseEnter += (s, e) => {
                passengerPanel.FillColor = isExpanded 
                    ? Color.FromArgb(0, 72, 113) 
                    : Color.FromArgb(0, 82, 133);
            };
            passengerPanel.MouseLeave += (s, e) => {
                passengerPanel.FillColor = isExpanded 
                    ? Color.FromArgb(0, 82, 123) 
                    : Color.FromArgb(0, 102, 153);
            };

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
