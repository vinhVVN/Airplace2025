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
    }
}
