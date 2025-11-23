using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmPriceDetails : Form
    {
        private Color clrTextPrimary = ColorTranslator.FromHtml("#006D75"); // Xanh cổ vịt
        private Color clrTextSecondary = Color.FromArgb(60, 60, 60); // Xám đen
        private Color clrButton = ColorTranslator.FromHtml("#F0B90B"); // Vàng cam
        private Color clrDivider = Color.FromArgb(220, 220, 220);
        public frmPriceDetails()
        {
            InitializeComponent();
            SetupForm();
            BuildUI();
        }

        private void SetupForm()
        {
            this.Size = new Size(900, 600);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Bo tròn góc Form và tạo bóng
            Guna2BorderlessForm borderless = new Guna2BorderlessForm(this.components);
            borderless.BorderRadius = 12;
            borderless.ShadowColor = Color.Black;
            borderless.ContainerControl = this;
        }

        private void BuildUI()
        {
            // --- 1. HEADER ---
            Panel pnlHeader = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(20, 0, 20, 0) };

            Label lblTitle = new Label
            {
                Text = "Chi tiết giá",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = clrTextPrimary,
                AutoSize = true,
                Location = new Point(20, 15)
            };

            Guna2ControlBox btnCloseIcon = new Guna2ControlBox
            {
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                FillColor = Color.Transparent,
                IconColor = Color.Black, // Hoặc màu vàng trong vòng tròn như ảnh
                Location = new Point(this.Width - 50, 10)
            };
            // Tùy chỉnh icon đóng giống ảnh (vòng tròn vàng) nếu cần thiết kế kỹ hơn

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnCloseIcon);
            this.Controls.Add(pnlHeader);

            // --- 3. FOOTER (Nút Đóng ở dưới) ---
            Panel pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 70, Padding = new Padding(0, 10, 20, 10) };

            Guna2Button btnClose = new Guna2Button
            {
                Text = "ĐÓNG",
                FillColor = clrButton,
                ForeColor = Color.Black, // Chữ màu đen/nâu
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BorderRadius = 6,
                Size = new Size(100, 40),
                Location = new Point(this.Width - 120, 10),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            btnClose.Click += (s, e) => this.Close();

            pnlFooter.Controls.Add(btnClose);
            this.Controls.Add(pnlFooter);

            // --- 2. BODY (Phần nội dung cuộn) ---
            FlowLayoutPanel pnlContent = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(20, 10, 20, 0)
            };
            // Hack để FlowLayoutPanel full width
            pnlContent.SizeChanged += (s, e) => {
                foreach (Control c in pnlContent.Controls) c.Width = pnlContent.Width - 50;
            };

            this.Controls.Add(pnlContent);

            // === THÊM DỮ LIỆU VÀO BODY ===

            // 1. Tổng giá vé to đùng
            pnlContent.Controls.Add(CreateTotalHeader("Giá vé", "11.227.000 VND"));
            pnlContent.Controls.Add(CreateNote("Tổng giá cho tất cả các hành khách (đã bao gồm thuế, phí và chiết khấu)."));
            pnlContent.Controls.Add(CreateSpacer());

            // 2. Người lớn
            pnlContent.Controls.Add(CreateSectionHeader("1 Người lớn", "5.672.000 VND", true));
            pnlContent.Controls.Add(CreateDetailRow("Phí vận chuyển hàng không", "4.198.000 VND", true));
            pnlContent.Controls.Add(CreateSubDetail("Giá vé", "4.198.000 VND"));

            pnlContent.Controls.Add(CreateDetailRow("Phụ thu của hãng hàng không", "900.000 VND", true));
            pnlContent.Controls.Add(CreateSubDetail("Phụ thu quản trị hệ thống", "900.000 VND"));

            pnlContent.Controls.Add(CreateDetailRow("Thuế/giá dịch vụ/phụ thu của sân bay/chính phủ", "574.000 VND", true));
            pnlContent.Controls.Add(CreateSubDetail("Phí dịch vụ hành khách chặng nội địa", "198.000 VND"));
            pnlContent.Controls.Add(CreateSubDetail("Thuế giá trị gia tăng, Việt Nam", "336.000 VND"));

            pnlContent.Controls.Add(CreateSpacer());

            // 3. Trẻ em
            pnlContent.Controls.Add(CreateSectionHeader("1 Trẻ em", "5.101.000 VND", true)); // Có icon mũi tên
                                                                                             // ... (Thêm các dòng chi tiết tương tự như trên nếu muốn mở rộng)

            pnlContent.Controls.Add(CreateSpacer());

            // 4. Em bé
            pnlContent.Controls.Add(CreateSectionHeader("1 Trẻ em (Sơ sinh)", "454.000 VND", true));
        }

        private Control CreateTotalHeader(string title, string price)
        {
            Panel p = new Panel { Height = 40, Margin = new Padding(0, 10, 0, 0) };
            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = clrTextPrimary, AutoSize = true, Location = new Point(0, 5) };
            Label lblPrice = new Label { Text = price, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = clrTextPrimary, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            p.Controls.Add(lblTitle);
            p.Controls.Add(lblPrice);
            // Căn chỉnh Label giá sang phải
            lblPrice.Location = new Point(800 - lblPrice.Width, 0); // Sẽ được resize lại theo Panel
            p.Resize += (s, e) => lblPrice.Left = p.Width - lblPrice.Width;

            return p;
        }

        private Control CreateNote(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 10)
            };
        }

        private Control CreateSectionHeader(string title, string price, bool showArrow)
        {
            Guna2Panel p = new Guna2Panel { Height = 50, Margin = new Padding(0, 10, 0, 5) };

            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = clrTextPrimary, AutoSize = true, Location = new Point(0, 12) };
            Label lblPrice = new Label { Text = price, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = clrTextPrimary, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            p.Controls.Add(lblTitle);
            p.Controls.Add(lblPrice);

            p.Resize += (s, e) => {
                lblPrice.Left = p.Width - lblPrice.Width - (showArrow ? 30 : 0);
            };

            if (showArrow)
            {
                // Giả lập icon mũi tên (Chevron)
                Label lblArrow = new Label { Text = "⌄", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = clrTextPrimary, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };
                p.Controls.Add(lblArrow);
                p.Resize += (s, e) => lblArrow.Left = p.Width - lblArrow.Width;
            }

            return p;
        }

        private Control CreateDetailRow(string title, string price, bool hasSeparator = false)
        {
            Panel container = new Panel { AutoSize = true, Margin = new Padding(0, 10, 0, 0) };

            Panel p = new Panel { Height = 25, Dock = DockStyle.Top };
            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(40, 40, 40), AutoSize = true, Location = new Point(0, 0) };
            Label lblPrice = new Label { Text = price, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.Black, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            p.Controls.Add(lblTitle);
            p.Controls.Add(lblPrice);
            p.Resize += (s, e) => lblPrice.Left = p.Width - lblPrice.Width;

            container.Controls.Add(p);

            if (hasSeparator)
            {
                Guna2Separator sep = new Guna2Separator { Height = 10, Dock = DockStyle.Bottom, FillColor = clrTextPrimary };
                // Trong ảnh đường kẻ nằm dưới text
                container.Controls.Add(sep);
            }
            return container;
        }

        private Control CreateSubDetail(string title, string price)
        {
            Panel p = new Panel { Height = 25, Margin = new Padding(10, 5, 0, 0) }; // Margin left để thụt vào
            Label lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.FromArgb(80, 80, 80), AutoSize = true, Location = new Point(10, 0) };
            Label lblPrice = new Label { Text = price, Font = new Font("Segoe UI", 9, FontStyle.Regular), ForeColor = Color.FromArgb(80, 80, 80), AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            p.Controls.Add(lblTitle);
            p.Controls.Add(lblPrice);
            p.Resize += (s, e) => lblPrice.Left = p.Width - lblPrice.Width;

            return p;
        }

        private Control CreateSpacer()
        {
            return new Panel { Height = 20 };
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
