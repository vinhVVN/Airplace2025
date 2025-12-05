using Airplace2025.BLL.DAO;
using Airplace2025.Properties;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.BLL;

namespace Airplace2025
{
    public partial class frmXemDanhSach: Form
    {

        public frmXemDanhSach(string maChuyenBay)
        {
            InitializeComponent();
            _maChuyenBay = maChuyenBay;
        }

        private string _maChuyenBay;
        private DataTable _dtHanhKhach;
        private string NgayBay;
        private string ChangBay;
        private string HangBay;

        private void LoadData()
        {
            _dtHanhKhach = CustomerDAO.Instance.DanhSachHanhKhach(_maChuyenBay);

            if (_dtHanhKhach.Rows.Count > 0)
            {
                // Hiển thị thông tin Header (Thông tin chuyến bay)
                // Lấy dòng đầu tiên để trích xuất thông tin chung
                DataRow r = _dtHanhKhach.Rows[0];
                NgayBay = Convert.ToDateTime(r["NgayGioBay"]).ToString("dd/MM/yyyy HH:mm");
                ChangBay = $"{r["MaSanBayDi"]} - {r["MaSanBayDen"]}";
                HangBay = r["TenHangBay"].ToString();

                lbTitle.Text = "DANH SÁCH KHÁCH HÀNG TRÊN CHUYẾN BAY " + _maChuyenBay;

                // Đổ dữ liệu vào DataGridView
                dgvKhachHang.DataSource = _dtHanhKhach;

                dgvKhachHang.Columns["MaSanBayDi"].Visible = false;
                dgvKhachHang.Columns["MaSanBayDen"].Visible = false;
                dgvKhachHang.Columns["NgayGioBay"].Visible = false;
                dgvKhachHang.Columns["Logo"].Visible = false;
                dgvKhachHang.Columns["TenHangBay"].Visible = false;

                try
                {
                    DataRow row = _dtHanhKhach.Rows[0];
                    object value = row["Logo"];
                    if (value == null || value == DBNull.Value)
                    {
                        picLogo.Image = Resources.pngaaa_com_791768;
                    }
                    else
                    {
                        byte[] imageData = (byte[])value;

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {

                            picLogo.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    picLogo.Image = Resources.pngaaa_com_791768;
                }

            }
            else
            {
                MessageBox.Show("Không tìm thấy hành khách nào cho chuyến bay này.", "Thông báo");
                this.Close();
            }
        }

        private void frmXemDanhSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dtHanhKhach == null || _dtHanhKhach.Rows.Count == 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = $"DSKH_{_maChuyenBay}_{DateTime.Now:ddMMyyyy}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Cấu hình License EPPlus (v8)
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("VINH DEP TRAI");

                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("Passenger Sheet");

                        // --- 1. Thiết lập trang in ---
                        ws.PrinterSettings.PaperSize = ePaperSize.A4;
                        ws.PrinterSettings.Orientation = eOrientation.Landscape;
                        ws.PrinterSettings.FitToPage = true;

                        // --- 2. Vẽ Header ---
                        // Logo (Giả sử bạn có resource logo)
                        Image logo = Properties.Resources.mb1;
                        using (var stream = new MemoryStream())
                        {
                            logo.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // Save the image to a memory stream
                            stream.Position = 0; // Reset the stream position to the beginning
                            var pic = ws.Drawings.AddPicture("Logo", stream); // Use the stream to add the picture
                            pic.SetPosition(0, 0, 0, 0); // Đặt ở góc A1
                            pic.SetSize(120, 50); // Điều chỉnh kích thước
                        }


                        ws.Cells["D3:J3"].Merge = true;
                        ws.Cells["D3"].Value = "DANH SÁCH HÀNH KHÁCH CỦA CHUYẾN BAY " + _maChuyenBay;
                        ws.Cells["D3"].Style.Font.Size = 16;
                        ws.Cells["D3"].Style.Font.Bold = true;
                        ws.Cells["D3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Thông tin chuyến bay
                        ws.Cells["B5"].Value = $"Chuyến bay: {_maChuyenBay}";
                        ws.Cells["B6"].Value = $"Ngày bay: {NgayBay}";
                        ws.Cells["B7"].Value = $"Chặng: {ChangBay}";
                        ws.Cells["B8"].Value = $"Hãng bay: {HangBay}";

                        ws.Cells["B5:B8"].Style.Font.Bold = true;

                        // --- 3. Vẽ Bảng Dữ Liệu ---
                        int headerRow = 10;

                        // Tiêu đề cột
                        ws.Cells[headerRow, 1].Value = "STT";
                        ws.Cells[headerRow, 2].Value = "Họ và Tên";
                        ws.Cells[headerRow, 3].Value = "Ngày sinh";
                        ws.Cells[headerRow, 4].Value = "Giới tính";
                        ws.Cells[headerRow, 5].Value = "Số ghế";
                        ws.Cells[headerRow, 6].Value = "Hạng vé";
                        ws.Cells[headerRow, 7].Value = "CCCD";
                        ws.Cells[headerRow, 8].Value = "Điện thoại";

                        // Style Header
                        using (var range = ws.Cells[headerRow, 1, headerRow, 8])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }

                        // Đổ dữ liệu
                        int currentRow = headerRow + 1;
                        int stt = 1;
                        foreach (DataRow row in _dtHanhKhach.Rows)
                        {
                            ws.Cells[currentRow, 1].Value = stt++;
                            ws.Cells[currentRow, 2].Value = row["HoTen"].ToString().ToUpper();

                            if (DateTime.TryParse(row["NgaySinh"].ToString(), out DateTime dob))
                                ws.Cells[currentRow, 3].Value = dob.ToString("dd/MM/yyyy");

                            ws.Cells[currentRow, 4].Value = row["GioiTinh"];
                            ws.Cells[currentRow, 5].Value = row["MaGhe"];
                            ws.Cells[currentRow, 6].Value = row["TenHangVe"];
                            ws.Cells[currentRow, 7].Value = row["CCCD"];
                            ws.Cells[currentRow, 8].Value = row["SoDienThoai"];

                            // Căn giữa vài cột
                            ws.Cells[currentRow, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[currentRow, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[currentRow, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            currentRow++;
                        }

                        // Kẻ khung bảng
                        using (var range = ws.Cells[headerRow, 1, currentRow - 1, 8])
                        {
                            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        }

                        // AutoFit cột
                        ws.Cells.AutoFitColumns();

                        p.SaveAs(new FileInfo(sfd.FileName));
                        MessageBox.Show("Xuất file thành công!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnThongBao_Click(object sender, EventArgs e)
        {
            if (_dtHanhKhach == null || _dtHanhKhach.Rows.Count == 0) return;

            frmThongBao frm = new frmThongBao();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string subject = frm.Subject;
                string rawBody = frm.Body;

                btnThongBao.Enabled = false;
                btnThongBao.Text = "Đang xử lý...";

                // --- CHUẨN BỊ HÌNH ẢNH ---
                // 1. Logo Đại lý (Từ Resources)
                MemoryStream streamAgencyLogo = new MemoryStream();
                Properties.Resources.mb1.Save(streamAgencyLogo, System.Drawing.Imaging.ImageFormat.Png);

                // 2. Logo Hãng Bay (Từ Database - Lấy dòng đầu tiên vì cả danh sách cùng 1 chuyến)
                MemoryStream streamAirlineLogo = new MemoryStream();
                if (_dtHanhKhach.Rows[0]["Logo"] != DBNull.Value)
                {
                    byte[] logoBytes = (byte[])_dtHanhKhach.Rows[0]["Logo"];
                    streamAirlineLogo.Write(logoBytes, 0, logoBytes.Length);
                }
                else
                {
                    // Nếu không có logo hãng thì dùng tạm ảnh mặc định hoặc để trống
                    Properties.Resources.plane_icon.Save(streamAirlineLogo, System.Drawing.Imaging.ImageFormat.Png);
                }

                // Đóng gói ảnh vào Dictionary với Key là ContentId (cid)
                var images = new Dictionary<string, Stream>
                {
                    { "AgencyLogo", streamAgencyLogo },
                    { "AirlineLogo", streamAirlineLogo }
                };

                // Lấy thông tin chung chuyến bay
                DataRow rInfo = _dtHanhKhach.Rows[0];
                string tenHang = rInfo["TenHangBay"].ToString();
                string maCB = _maChuyenBay;
                string gioBay = Convert.ToDateTime(rInfo["NgayGioBay"]).ToString("HH:mm dd/MM/yyyy");
                string changBay = $"{rInfo["MaSanBayDi"]} ➔ {rInfo["MaSanBayDen"]}";

                int success = 0;

                await Task.Run(() =>
                {
                    foreach (DataRow row in _dtHanhKhach.Rows)
                    {
                        if (_dtHanhKhach.Columns.Contains("Email") && row["Email"] != DBNull.Value)
                        {
                            string emailTo = row["Email"].ToString();
                            string tenKhach = row["HoTen"].ToString();

                            // Tạo nội dung HTML riêng cho từng khách (để thay tên)
                            string htmlBody = BuildProfessionalEmailBody(tenKhach, rawBody, tenHang, maCB, gioBay, changBay);

                            // Gửi mail với ảnh nhúng
                            if (EmailService.SendMailWithImages(emailTo, subject, htmlBody, images))
                            {
                                success++;
                            }
                        }
                    }
                });

                // Dọn dẹp bộ nhớ Stream
                streamAgencyLogo.Dispose();
                streamAirlineLogo.Dispose();

                btnThongBao.Enabled = true;
                btnThongBao.Text = "Gửi thông báo";
                MessageBox.Show($"Đã gửi thành công {success} email.", "Hoàn tất");
            }
        }


        private string BuildProfessionalEmailBody(string tenKhach, string noiDungThongBao, string tenHangBay, string maChuyenBay, string gioBay, string changBay)
        {
            // Mẫu HTML sử dụng Table (tốt nhất cho Email Client)
            // Logo Đại lý dùng cid:AgencyLogo
            // Logo Hãng bay dùng cid:AirlineLogo

                return $@"
            <!DOCTYPE html>
            <html>
            <head>
            <style>
                body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333; }}
                .container {{ width: 100%; max-width: 600px; margin: 0 auto; border: 1px solid #e0e0e0; }}
                .header {{ background-color: #0056b3; padding: 20px; text-align: center; }}
                .content {{ padding: 30px 20px; background-color: #ffffff; }}
                .footer {{ background-color: #f4f4f4; padding: 15px; text-align: center; font-size: 12px; color: #777; }}
                .flight-info {{ background-color: #f9f9f9; border-left: 4px solid #0056b3; padding: 15px; margin: 20px 0; }}
                .btn {{ display: inline-block; background-color: #28a745; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; margin-top: 10px; }}
            </style>
            </head>
            <body>
            <div class='container'>
                <div class='header'>
                    <img src='cid:AgencyLogo' alt='Airplace Logo' style='max-height: 50px;' />
                    <h2 style='color: white; margin: 10px 0 0 0;'>THÔNG BÁO TỪ ĐẠI LÝ</h2>
                </div>

                <div class='content'>
                    <p>Kính gửi Quý khách <strong>{tenKhach}</strong>,</p>
                
                    <p>{noiDungThongBao.Replace("\n", "<br>")}</p>

                    <div class='flight-info'>
                        <table width='100%'>
                            <tr>
                                <td width='60px' valign='middle'>
                                    <img src='cid:AirlineLogo' alt='Airline Logo' style='width: 50px; height: auto;' />
                                </td>
                                <td valign='middle'>
                                    <strong>{tenHangBay}</strong><br/>
                                    Chuyến bay: <strong>{maChuyenBay}</strong><br/>
                                    Hành trình: {changBay}<br/>
                                    Giờ khởi hành: {gioBay}
                                </td>
                            </tr>
                        </table>
                    </div>

                    <p>Cảm ơn Quý khách đã sử dụng dịch vụ của chúng tôi.</p>
                    <p>Trân trọng,<br/><strong>Đội ngũ Airplace 2025</strong></p>
                </div>

                <div class='footer'>
                    <p>Email này được gửi tự động, vui lòng không trả lời.</p>
                    <p>Hotline hỗ trợ: 1900 xxxx</p>
                </div>
            </div>
            </body>
            </html>";
        }

    }
}
