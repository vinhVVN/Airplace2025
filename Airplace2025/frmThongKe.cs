using Airplace2025.BLL.DAO;
using Airplace2025.DAL;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TheArtOfDevHtmlRenderer.Core;

namespace Airplace2025
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();



        }

        private void UpdataData()
        {
            lbMoney.Text = TongThuNhap(dtpStart.Value, dtpEnd.Value).ToString() + " đ";
            lbTicket.Text = TongVeDaBan(dtpStart.Value, dtpEnd.Value).ToString();
            lbFlight.Text = TongChuyenBay(dtpStart.Value, dtpEnd.Value).ToString();
            DoanhThuNgay(dtpStart.Value, dtpEnd.Value);
            LoadDataDGV(dtpStart.Value, dtpEnd.Value);
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dtpEnd.Value = DateTime.Now;
            dtpStart.Value = DateTime.Now.AddMonths(-1);
            UpdataData();
            Top5DuongBay();

        }



        bool isUpdating = false;

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Nếu đang cập nhật, thoát ngay

            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                isUpdating = true;
                dtpEnd.Value = startDate.AddDays(1); // hoặc logic bạn muốn
                isUpdating = false;

                return;
            }

            UpdataData();

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                isUpdating = true;
                dtpStart.Value = endDate.AddDays(-1);
                isUpdating = false;

                return;
            }

            if (endDate.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Thời gian kết thúc không được hơn hôm nay",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                isUpdating = true;
                dtpEnd.Value = DateTime.Now;
                isUpdating = false;

                return;
            }

            UpdataData();

        }

        private decimal TongThuNhap(DateTime startDate, DateTime endDate)
        {
            decimal totalRevenue = 0;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TongDoanhThu", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kiểm tra nếu giá trị có tồn tại trong cột "TongDoanhThu"
                                if (!reader.IsDBNull(reader.GetOrdinal("TongDoanhThu")))
                                {
                                    totalRevenue = reader.GetDecimal(reader.GetOrdinal("TongDoanhThu"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng thu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalRevenue;
        }

        private int TongVeDaBan(DateTime startDate, DateTime endDate)
        {
            int res = 0;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_TongVeDaBan", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kiểm tra nếu giá trị có tồn tại trong cột "TongDoanhThu"
                                if (!reader.IsDBNull(reader.GetOrdinal("TongVeDaBan")))
                                {
                                    res = reader.GetInt32(reader.GetOrdinal("TongVeDaBan"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }

        private int TongChuyenBay(DateTime startDate, DateTime endDate)
        {
            int res = 0;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_ThongKe_TongChuyenBay", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kiểm tra nếu giá trị có tồn tại trong cột "TongDoanhThu"
                                if (!reader.IsDBNull(reader.GetOrdinal("TongChuyenBay")))
                                {
                                    res = reader.GetInt32(reader.GetOrdinal("TongChuyenBay"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return res;
        }


        private bool DoanhThuNgay(DateTime startDate, DateTime endDate)
        {
            bool hasData = false;
            var dataPoints = new List<Tuple<string, decimal>>();

            string designerSeriesName = "Series1"; // Tên series đã thiết kế

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_ThongKe_DoanhThuTheoNgay", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.HasRows && reader.Read())
                            {
                                hasData = true;
                                DateTime date = reader.GetDateTime(0);
                                decimal revenue = reader.GetDecimal(1);
                                dataPoints.Add(Tuple.Create(date.ToString("dd/MM/yyyy"), revenue));
                            }
                        }
                    }
                }

                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;

                chartDoanhThu.Invoke((MethodInvoker)(() =>
                {
                    Series targetSeries = null;

                    var YAxis = chartDoanhThu.ChartAreas[0].AxisY;

                    // Cố gắng tìm Series đã được thiết kế sẵn bằng tên của nó
                    if (chartDoanhThu.Series.IndexOf(designerSeriesName) >= 0)
                    {
                        // Lấy tham chiếu đến Series đã có từ Designer
                        targetSeries = chartDoanhThu.Series[designerSeriesName];

                        // Xóa các điểm dữ liệu cũ, MỌI THIẾT KẾ SẼ ĐƯỢC GIỮ NGUYÊN
                        targetSeries.Points.Clear();


                        int pointIndex = targetSeries.Points.AddXY(DateTime.Now.AddYears(-2).ToString("dd/MM/yyyy"), 0);
                        DataPoint beforePoint = targetSeries.Points[pointIndex];
                        beforePoint.AxisLabel = " ";

                        // Thêm các điểm dữ liệu mới vào Series này
                        if (hasData)
                        {
                            YAxis.Minimum = double.NaN;
                            YAxis.Maximum = double.NaN;
                            foreach (var point in dataPoints)
                            {
                                targetSeries.Points.AddXY(point.Item1, point.Item2);
                            }

                        }
                        else
                        {
                            YAxis.Minimum = 0;
                            YAxis.Maximum = 100000;
                        }

                        int pointIndex2 = targetSeries.Points.AddXY(DateTime.Now.AddYears(2).ToString("dd/MM/yyyy"), 0);
                        DataPoint afterPoint = targetSeries.Points[pointIndex2];
                        afterPoint.AxisLabel = " ";

                    }
                    else
                    {
                        MessageBox.Show("Lỗi Cấu Hình Biểu Đồ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật biểu đồ doanh thu ngày: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return hasData;
        }

        private void Top5DuongBay()
        {
            var legend = chartDuongBay.Legends["Legend1"];

            // Đưa Legend xuống dưới (Bottom)
            legend.Docking = Docking.Bottom;

            // Căn lề Legend sang bên phải (Far = Right-aligned)
            legend.Alignment = StringAlignment.Far;
            legend.ForeColor = Color.Black;

            // Đảm bảo ChartArea tự động căn chỉnh
            // Khi Legend được đưa xuống dưới, ChartArea sẽ tự động
            // chiếm phần không gian còn lại (ở giữa, phía trên).
            chartDuongBay.ChartAreas[0].Position.Auto = true;

            bool hasData = false;
            // dataPoints sẽ lưu: <"SGN - HAN", 120>
            var dataPoints = new List<Tuple<string, int>>();

            string designerSeriesName = "Series1"; // Tên series đã thiết kế

            List<Color> customSliceColors = new List<Color>
            {
                Color.FromArgb(0, 122, 204),   // Xanh dương đậm (VS Blue)
                Color.FromArgb(255, 128, 0),   // Cam đậm
                Color.FromArgb(0, 150, 136),   // Xanh mòng két (Teal)
                Color.FromArgb(216, 0, 115),   // Hồng đậm (Magenta)
                Color.FromArgb(255, 193, 7)    // Vàng hổ phách (Amber)
            };

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    // THAY ĐỔI 1: Đổi tên SP
                    using (SqlCommand command = new SqlCommand("sp_Top5DuongBay", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hasData = true;

                                string tenSanBayDi = reader.GetString(1);
                                string tenSanBayDen = reader.GetString(3);
                                int soVe = reader.GetInt32(4);

                                // Tạo nhãn mới
                                string duongBayLabel = $"{tenSanBayDi} - {tenSanBayDen}";

                                dataPoints.Add(Tuple.Create(duongBayLabel, soVe));
                            }
                        }

                        // Giả sử biểu đồ của bạn tên là chartLoaiPhong
                        chartDuongBay.Invoke((MethodInvoker)(() =>
                        {
                            Series targetSeries = null;
                            if (chartDuongBay.Series.IndexOf(designerSeriesName) >= 0)
                            {
                                targetSeries = chartDuongBay.Series[designerSeriesName];
                                targetSeries.Points.Clear();

                                if (hasData)
                                {
                                    int colorIndex = 0;
                                    foreach (var point in dataPoints)
                                    {

                                        string duongBayLabel = point.Item1;
                                        decimal countValue = point.Item2;

                                        int pointIndex = targetSeries.Points.AddXY(duongBayLabel, countValue);
                                        DataPoint addedPoint = targetSeries.Points[pointIndex];

                                        // (Gán màu và nhãn)
                                        addedPoint.Color = customSliceColors[colorIndex % customSliceColors.Count]; // Dùng modulo để tránh lỗi
                                        addedPoint.Label = countValue.ToString();
                                        addedPoint.LegendText = duongBayLabel;

                                        colorIndex++;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lỗi Cấu Hình Biểu Đồ: Không tìm thấy Series 'Series1'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadDataDGV(DateTime startDate, DateTime endDate)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("sp_ThongKe_DoanhThuTheoNgay", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@DateStart", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@DateEnd", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(dt);

                        dgvDoanhThu.DataSource = dt;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            DataTable dtBaoCao;
            try
            { 
                dtBaoCao = ReportDAO.Instance.GetMonthlySalesReport(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. CHỌN NƠI LƯU FILE
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FileName = $"BaoCaoDoanhThu_{DateTime.Now.Year}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Huynh Mai Cao Nhan");

                    using (var p = new ExcelPackage())
                    {
                        var ws = p.Workbook.Worksheets.Add("BaoCaoDoanhThu");

                        // --- 3. ĐỊNH DẠNG FILE EXCEL ---

                        // Đặt chiều rộng cột (giống ảnh mẫu)
                        ws.Column(1).Width = 5;  // STT
                        ws.Column(2).Width = 15; // Tháng
                        ws.Column(3).Width = 20; // Số chuyến bay (hóa đơn)
                        ws.Column(4).Width = 25; // Doanh thu
                        ws.Column(5).Width = 10; // Tỷ lệ

                        //  Logo và Tiêu đề
                        Image logo = Properties.Resources.mb1;
                        using (var stream = new MemoryStream())
                        {
                            logo.Save(stream, System.Drawing.Imaging.ImageFormat.Png); // Save the image to a memory stream
                            stream.Position = 0; // Reset the stream position to the beginning
                            var pic = ws.Drawings.AddPicture("Logo", stream); // Use the stream to add the picture
                            pic.SetPosition(0, 0, 0, 0); // Đặt ở góc A1
                            pic.SetSize(120, 50); // Điều chỉnh kích thước
                        }
                        
                        ws.Cells["A1:B3"].Merge = true;

                        // Tiêu đề chính
                        ws.Cells["C1:E3"].Merge = true;
                        ws.Cells["C1"].Value = "Báo cáo";
                        ws.Cells["C1"].Style.Font.Bold = true;
                        ws.Cells["C1"].Style.Font.Size = 18;
                        ws.Cells["C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // 3.2. Khối "Thông tin dự án"
                        var infoHeader = ws.Cells["A5:E5"];
                        infoHeader.Merge = true;
                        infoHeader.Value = "Thông tin trình bày";
                        infoHeader.Style.Font.Bold = true;
                        infoHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        infoHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        infoHeader.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                        ws.Cells["A6:B6"].Merge = true;
                        ws.Cells["A6"].Value = "Tiêu đề";
                        ws.Cells["A6"].Style.Font.Bold = true;
                        ws.Cells["C6:E6"].Merge = true;
                        ws.Cells["C6"].Value = "Quản lý bán vé máy bay";

                        ws.Cells["A7:B7"].Merge = true;
                        ws.Cells["A7"].Value = "Ngày báo cáo";
                        ws.Cells["A7"].Style.Font.Bold = true;
                        ws.Cells["C7:E7"].Merge = true;
                        ws.Cells["C7"].Value = DateTime.Now.ToString("dd-MM-yyyy");

                        ws.Cells["A8:B8"].Merge = true;
                        ws.Cells["A8"].Value = "Người báo cáo";
                        ws.Cells["A8"].Style.Font.Bold = true;
                        ws.Cells["C8:E8"].Merge = true;
                        // (Giả sử bạn có thông tin người dùng, ví dụ:)
                        // ws.Cells["C8"].Value = Session.CurrentUser.HoTen; 
                        ws.Cells["C8"].Value = "Vinh SaGe"; // Hoặc Hardcode


                        // 3.3. Khối "Thông tin báo cáo"
                        var dataHeader = ws.Cells["A9:E9"]; 
                        dataHeader.Merge = true;
                        dataHeader.Value = "Thông tin báo cáo";
                        dataHeader.Style.Font.Bold = true;
                        dataHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        dataHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        dataHeader.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                        // Tiêu đề bảng
                        ws.Cells["A10"].Value = "STT";
                        ws.Cells["B10"].Value = "Tháng";
                        ws.Cells["C10"].Value = "Số hóa đơn"; // Sửa lại
                        ws.Cells["D10"].Value = "Doanh thu (VNĐ)";
                        ws.Cells["E10"].Value = "Tỷ lệ";
                        ws.Cells["A10:E10"].Style.Font.Bold = true;
                        ws.Cells["A10:E10"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // 3.4. Đổ dữ liệu
                        int currentRow = 11;
                        int stt = 1;
                        decimal tongDoanhThu = 0;
                        foreach (DataRow dr in dtBaoCao.Rows)
                        {
                            ws.Cells[currentRow, 1].Value = stt++;
                            ws.Cells[currentRow, 2].Value = dr["Thang"];
                            ws.Cells[currentRow, 3].Value = dr["SoHoaDon"];
                            ws.Cells[currentRow, 4].Value = dr["DoanhThu"];
                            ws.Cells[currentRow, 5].Value = dr["TyLe"];

                            tongDoanhThu += Convert.ToDecimal(dr["DoanhThu"]);
                            currentRow++;
                        }

                        // Định dạng số
                        ws.Cells[$"C11:C{currentRow - 1}"].Style.Numberformat.Format = "#,##0";
                        ws.Cells[$"D11:D{currentRow - 1}"].Style.Numberformat.Format = "#,##0.00";
                        ws.Cells[$"E11:E{currentRow - 1}"].Style.Numberformat.Format = "0.0";
                        ws.Cells[$"A11:E{currentRow - 1}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[$"D11:D{currentRow - 1}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        // 3.5. Dòng tổng kết
                        var footerCell = ws.Cells[currentRow, 2, currentRow, 5];
                        footerCell.Merge = true;
                        footerCell.Value = "Tổng doanh thu: " + tongDoanhThu.ToString("#,##0.00");
                        footerCell.Style.Font.Bold = true;
                        footerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        footerCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        footerCell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(173, 216, 230)); // LightBlue (Azure)

                        // 4. LƯU FILE
                        p.SaveAs(new FileInfo(saveFileDialog.FileName));

                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
