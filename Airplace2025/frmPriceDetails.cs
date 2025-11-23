using Guna.UI2.WinForms;
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
            
            // Form settings from snippet (applying to this form)
            this.BackColor = Color.FromArgb(240, 240, 240);
            
            // Clear any designer placeholder items from content panel
            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                LoadFareData();
            }
        }

        private void LoadFareData()
        {
            // Adult passenger
            AddPassengerItem("1 Người lớn", "5.672.000 VND", new[]
            {
                ("Phí vận chuyển hàng không", "4.198.000 VND", new[] { ("Giá vé", "4.198.000 VND") }),
                ("Phụ thu của hãng hàng không", "900.000 VND", new[] { ("Phụ thu quản trị hệ thống", "900.000 VND") }),
                ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", "574.000 VND", new[]
                {
                    ("Phí dịch vụ hành khách chặng nội địa, Việt Nam", "198.000 VND"),
                    ("Phí soi chiếu an ninh hành khách và hành lý, Việt Nam", "40.000 VND"),
                    ("Thuế giá trị gia tăng, Việt Nam", "336.000 VND")
                })
            });

            // Child 1
            AddPassengerItem("1 Trẻ em", "5.101.000 VND", new[]
            {
                ("Phí vận chuyển hàng không", "3.779.000 VND", new[] { ("Giá vé", "3.779.000 VND") }),
                ("Phụ thu của hãng hàng không", "900.000 VND", new[] { ("Phụ thu quản trị hệ thống", "900.000 VND") }),
                ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", "422.000 VND", new[]
                {
                    ("Phí dịch vụ hành khách chặng nội địa, Việt Nam", "99.000 VND"),
                    ("Phí soi chiếu an ninh hành khách và hành lý, Việt Nam", "20.000 VND"),
                    ("Thuế giá trị gia tăng, Việt Nam", "303.000 VND")
                })
            });

            // Child 2
            AddPassengerItem("1 Trẻ em (Sơ sinh)", "454.000 VND", new[]
            {
                ("Phí vận chuyển hàng không", "420.000 VND", new[] { ("Giá vé", "420.000 VND") }),
                ("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", "34.000 VND", new[]
                {
                    ("Thuế giá trị gia tăng, Việt Nam", "34.000 VND")
                })
            });
        }

        private void AddPassengerItem(string passengerType, string totalPrice, (string category, string price, (string item, string price)[] items)[] breakdown)
        {
            // Calculate width to avoid horizontal scrollbar if vertical one appears
            // Padding is 25 left + 25 right = 50. Scrollbar is approx 20.
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
