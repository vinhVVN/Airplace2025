using Airplace2025.BLL.DAO;
using Airplace2025.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmTraCuuDatVe: Form
    {
        public frmTraCuuDatVe()
        {
            InitializeComponent();
        }

        private void frmTraCuuDatVe_Load(object sender, EventArgs e)
        {
            TicketPnl.Visible = false;
            pnlCustomer.Visible = false;
            pnlTicketInfo.Visible = false;
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private DataTable _currentTicketData;

        private void btnFind_Click(object sender, EventArgs e)
        {

            string maVe = txtMaVe.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrEmpty(maVe) || string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã vé và Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Gọi DAO tìm kiếm
                _currentTicketData = TicketDAO.Instance.TraCuuDatVe(maVe, hoTen);

                if (_currentTicketData != null && _currentTicketData.Rows.Count > 0)
                {
                    // 2. Hiển thị thông tin khách hàng (Lấy dòng đầu tiên)
                    DataRow firstRow = _currentTicketData.Rows[0];

                    lbMaVe.Text = firstRow["MaDatVe"].ToString();

                    // Xử lý tên: Nguyễn Văn Tèo -> VĂN TÈO NGUYỄN
                    string rawName = firstRow["HoTen"].ToString();
                    lbCustomerName.Text = FormatPassengerName(rawName);

                    lbGender.Text = firstRow["GioiTinh"].ToString();

                    // 3. Hiển thị danh sách chuyến bay (FlightSight)
                    LoadFlightDetails(_currentTicketData);

                    // 4. Hiện các Panel
                    pnlTicketInfo.Visible = true;
                    pnlCustomer.Visible = true;
                    TicketPnl.Visible = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin vé.\nVui lòng kiểm tra lại Mã vé và Họ tên chính xác.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pnlTicketInfo.Visible = false;
                    pnlCustomer.Visible = false;
                    TicketPnl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string FormatPassengerName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "";

            string[] parts = fullName.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1) return parts[0].ToUpper(); // Chỉ có 1 từ

            string ho = parts[0]; // Nguyễn
            string ten = parts[parts.Length - 1]; // Tèo

            string tenDem = "";
            if (parts.Length > 2)
            {
                // Lấy các từ ở giữa làm tên đệm
                tenDem = string.Join(" ", parts.Skip(1).Take(parts.Length - 2));
            }

            // Ghép lại: Đệm + Tên + Họ
            string result = $"{tenDem} {ten} {ho}".Trim();
            return RemoveDiacritics(result).ToUpper();
        }

        private void LoadFlightDetails(DataTable dt)
        {
            TicketPnl.Controls.Clear(); // Xóa cũ

            foreach (DataRow row in dt.Rows)
            {
                // Khởi tạo UserControl
                FlightSight flightControl = new FlightSight();

                // Lấy dữ liệu từ Row
                string tenMayBay = row["TenMayBay"].ToString();
                string maSbDi = row["MaSanBayDi"].ToString();
                string maSbDen = row["MaSanBayDen"].ToString();
                string tenSbDi = row["TenSanBayDi"].ToString();
                string tenSbDen = row["TenSanBayDen"].ToString();
                string ghe = row["MaGhe"].ToString();
                string hangve = row["TenHangVe"].ToString();
                string hanhlyThem = row["HanhLyThem"].ToString();

                DateTime ngayGioDi = Convert.ToDateTime(row["NgayGioBay"]);
                int thoiGianBay = Convert.ToInt32(row["ThoiGianBay"]);
                DateTime ngayGioDen = ngayGioDi.AddMinutes(thoiGianBay);

                string gioDi = ngayGioDi.ToString("HH:mm");
                string ngayDi = ngayGioDi.ToString("dd/MM/yyyy");
                string gioDen = ngayGioDen.ToString("HH:mm");
                string ngayDen = ngayGioDen.ToString("dd/MM/yyyy");

                string thoiLuong = FormatDuration(thoiGianBay);

                // Xử lý ảnh Logo
                Image logo = null;
                if (row["Logo"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["Logo"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        logo = Image.FromStream(ms);
                    }
                }

                // Đổ dữ liệu vào Control
                flightControl.SetData(
                    tenMayBay,
                    maSbDi,
                    maSbDen,
                    tenSbDi,
                    tenSbDen,
                    gioDi,
                    gioDen,
                    ngayDi,
                    ngayDen,
                    thoiLuong,
                    logo,
                    ghe,
                    hangve,
                    hanhlyThem
                );

                // Thêm vào FlowLayoutPanel
                TicketPnl.Controls.Add(flightControl);
            }
        }

        private string FormatDuration(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            return minutes > 0 ? $"{hours}h {minutes}m" : $"{hours}h";
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            // Xử lý riêng chữ đ / Đ
            return sb.ToString()
                     .Replace("đ", "d")
                     .Replace("Đ", "D");
        }

        private void lbUpClass_Click(object sender, EventArgs e)
        {
            if (_currentTicketData == null || _currentTicketData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có thông tin vé.");
                return;
            }

            // Mở form Nâng Hạng và truyền dữ liệu vé hiện tại sang
            frmNangHang frm = new frmNangHang(_currentTicketData);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Nếu nâng hạng thành công -> Load lại dữ liệu mới nhất từ CSDL
                // Để cập nhật lại hạng vé mới trên giao diện
                btnFind_Click(sender, e);
            }
        }

        private void btnScedule_Click(object sender, EventArgs e)
        {
            
        }

        private void SuiteCasebtn_Click(object sender, EventArgs e)
        {
            if (_currentTicketData == null || _currentTicketData.Rows.Count == 0) return;

            // Lấy mã đặt vé (ví dụ: ETK001)
            string maDatVe = _currentTicketData.Rows[0]["MaDatVe"].ToString();

            frmMuaHanhLy frm = new frmMuaHanhLy(maDatVe);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu để thấy cập nhật
                btnFind_Click(sender, e);
            }
        }

        public void HienThiFormVe(DataTable dtData)
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu vé để hiển thị.");
                return;
            }

            // 1. Khởi tạo Form chứa
            Form formContainer = new Form();
            formContainer.Text = "Vé Điện Tử (E-Ticket)";
            formContainer.Size = new Size(1100, 800);
            formContainer.StartPosition = FormStartPosition.CenterScreen;
            formContainer.BackColor = Color.WhiteSmoke;

            // 2. Tạo Panel chứa nút bấm (Đưa lên ĐẦU để chắc chắn thấy)
            Panel pnlButtons = new Panel();
            pnlButtons.Dock = DockStyle.Top; // Đổi thành TOP để dễ thấy nhất
            pnlButtons.Height = 60;
            pnlButtons.BackColor = Color.LightGray; // Màu nền xám
            pnlButtons.Padding = new Padding(10); // Cách lề một chút

            // Tạo nút IN (Dock sang phải để luôn nằm ở góc phải)
            Button btnPrint = new Button();
            btnPrint.Text = "🖨 IN VÉ / XUẤT PDF";
            btnPrint.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnPrint.BackColor = Color.DodgerBlue;
            btnPrint.ForeColor = Color.White;
            btnPrint.Width = 200;
            btnPrint.Dock = DockStyle.Right; // Tự động dính sang phải
            btnPrint.Cursor = Cursors.Hand;

            pnlButtons.Controls.Add(btnPrint); // Thêm nút vào panel nút

            // 3. Tạo Panel chứa danh sách vé
            // (Đây là panel cuộn bao bên ngoài)
            Panel pnlScrollContainer = new Panel();
            pnlScrollContainer.Dock = DockStyle.Fill; // Lấp đầy phần còn lại
            pnlScrollContainer.AutoScroll = true;     // Bật thanh cuộn
            pnlScrollContainer.BackColor = Color.DarkGray; // Màu nền tối để làm nổi bật vé trắng

            // (Đây là panel nội dung vé thực tế - cái sẽ được IN)
            FlowLayoutPanel pnlFlow = new FlowLayoutPanel();
            pnlFlow.AutoSize = true;
            pnlFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlFlow.FlowDirection = FlowDirection.TopDown;
            pnlFlow.WrapContents = false;
            pnlFlow.Padding = new Padding(40); // Lề rộng rãi
            pnlFlow.BackColor = Color.White;   // Nền trắng cho giấy in

            // Căn giữa panel in trong vùng cuộn (Mẹo căn giữa)
            pnlFlow.Anchor = AnchorStyles.Top;

            // Sự kiện IN
            btnPrint.Click += (s, e) =>
            {
                // Gọi hàm in panel nội dung
                InPanel(pnlFlow);
            };

            // 4. Thêm vé vào danh sách
            foreach (DataRow row in dtData.Rows)
            {
                frmVe ve = new frmVe();
                ve.TopLevel = false;
                ve.FormBorderStyle = FormBorderStyle.None;
                ve.Visible = true;

                // Đổ dữ liệu
                ve.SetTicketData(row);

                // Tạo viền trang trí cho vé
                Panel pnlBorder = new Panel();
                pnlBorder.AutoSize = true;
                pnlBorder.Padding = new Padding(1); // Viền mỏng
                pnlBorder.Controls.Add(ve);

                pnlFlow.Controls.Add(pnlBorder);

                // Khoảng cách giữa các vé
                pnlFlow.Controls.Add(new Label { Height = 40, Width = 10 });
            }

            // Lắp ráp các thành phần
            // B1: Đưa nội dung vé vào vùng cuộn
            pnlScrollContainer.Controls.Add(pnlFlow);

            pnlScrollContainer.Resize += (s, e) =>
            {
                if (pnlFlow.Width < pnlScrollContainer.Width)
                {
                    pnlFlow.Left = (pnlScrollContainer.Width - pnlFlow.Width) / 2;
                }
                else
                {
                    pnlFlow.Left = 0; // Nếu vé to hơn màn hình thì căn trái để scoll được
                }
            };

            // B3: Thêm Panel Nút và Panel Cuộn vào Form
            // QUAN TRỌNG: Add pnlButtons trước (vì nó Dock=Top), sau đó Add pnlScrollContainer (Dock=Fill)
            formContainer.Controls.Add(pnlScrollContainer);
            formContainer.Controls.Add(pnlButtons);

            // Đảm bảo thứ tự hiển thị
            pnlButtons.BringToFront();

            // 5. Hiển thị Form
            formContainer.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_currentTicketData != null && _currentTicketData.Rows.Count > 0)
            {
                HienThiFormVe(_currentTicketData);
            }
        }

        private void lbChangeFlight_Click(object sender, EventArgs e)
        {
            if (_currentTicketData == null || _currentTicketData.Rows.Count == 0) return;

            // Lấy dòng dữ liệu của vé hiện tại (Giả sử lấy dòng đầu hoặc dòng đang chọn)
            DataRow veHienTai = _currentTicketData.Rows[0];

            // Cần đảm bảo veHienTai có cột "GiaVeThucTe"
            // Nếu SP Tra Cứu chưa trả về cột này thì bạn vào sửa SP sp_TraCuuDatVe thêm cột v.GiaVeThucTe nhé

            frmDoiChuyenBay frm = new frmDoiChuyenBay(veHienTai);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Refresh lại dữ liệu
                btnFind_Click(sender, e);
            }
        }

        public void InPanel(Panel pnlContent)
        {
            try
            {
                // 1. Lưu lại kích thước cũ để khôi phục sau khi in
                Size originalSize = pnlContent.Size;
                bool originalAutoSize = pnlContent.AutoSize;
                DockStyle originalDock = pnlContent.Dock;

                // 2. "Hack" kích thước Panel để nó bung ra toàn bộ nội dung
                // Tắt Dock và AutoSize để ta có thể chỉnh kích thước thủ công
                pnlContent.Dock = DockStyle.None;
                pnlContent.AutoSize = false;

                // Đặt kích thước panel bằng đúng kích thước nội dung bên trong (PreferredSize)
                pnlContent.Width = pnlContent.PreferredSize.Width;
                pnlContent.Height = pnlContent.PreferredSize.Height;

                // 3. Tạo Bitmap với kích thước TOÀN BỘ nội dung
                Bitmap memoryImage = new Bitmap(pnlContent.Width, pnlContent.Height);
                memoryImage.SetResolution(600, 600); // Tăng DPI để nét

                // 4. Vẽ Panel vào Bitmap
                pnlContent.DrawToBitmap(memoryImage, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

                // 5. Khôi phục lại trạng thái hiển thị cũ cho người dùng không thấy bị giật
                pnlContent.Dock = originalDock;
                pnlContent.AutoSize = originalAutoSize;
                pnlContent.Size = originalSize;

                // 6. Cấu hình trang in (Giống code cũ nhưng tối ưu hơn)
                PrintDocument printDoc = new PrintDocument();
                // Tự xoay ngang nếu ảnh rộng hơn cao
                if (memoryImage.Width > memoryImage.Height) printDoc.DefaultPageSettings.Landscape = true;
                printDoc.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20); // Lề nhỏ

                printDoc.PrintPage += (sender, e) =>
                {
                    Graphics g = e.Graphics;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;

                    RectangleF printableArea = e.MarginBounds;

                    // Tính tỷ lệ scale để nhét vừa trang giấy
                    float scaleX = printableArea.Width / (float)memoryImage.Width;
                    float scaleY = printableArea.Height / (float)memoryImage.Height;
                    float scale = Math.Min(scaleX, scaleY); // Chọn tỷ lệ nhỏ nhất để không bị mất hình

                    float printWidth = memoryImage.Width * scale;
                    float printHeight = memoryImage.Height * scale;

                    // Căn giữa trang
                    float x = printableArea.Left + (printableArea.Width - printWidth) / 2;
                    float y = printableArea.Top + (printableArea.Height - printHeight) / 2;

                    g.DrawImage(memoryImage, new RectangleF(x, y, printWidth, printHeight));
                };

                // 7. Hiển thị Preview
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDoc;
                ((Form)previewDialog).WindowState = FormWindowState.Maximized;
                previewDialog.PrintPreviewControl.Zoom = 1.0;
                previewDialog.ShowDialog();

                memoryImage.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}");
            }
        }
    }
}
