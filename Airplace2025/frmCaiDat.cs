using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Airplace2025.BLL.DAO; // Thư viện kết nối SQL Server


namespace Airplace2025
{
    public partial class frmCaiDat : Form
    {
        private object reader;
        private DataTable originalSettings;

        public frmCaiDat()
        {
            InitializeComponent();
        }
        private void SetEditMode(bool isEditable)
        {
            // Dựa trên bảng ánh xạ trước đó:
            txtMinFlightTime.ReadOnly = !isEditable;
            txtMaxTransitCount.ReadOnly = !isEditable;
            txtMinTransitDuration.ReadOnly = !isEditable;
            txtMaxTransitDuration.ReadOnly = !isEditable;
            txtLatestBookingDays.ReadOnly = !isEditable;
            txtLatestCancelDays.ReadOnly = !isEditable;

            // Đặt trạng thái hiển thị cho các nút
            btnSave_Click.Enabled = isEditable; // Chỉ cho phép lưu khi đang chỉnh sửa
            btnUpdate_Click.Enabled = !isEditable; // Không cho phép chỉnh sửa khi đã ở chế độ chỉnh sửa
            btnReset_Click.Enabled = isEditable;
        }

        private void frmCaiDat_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu (DataTable dt chứa 1 hàng tham số)
            DataTable dt = ParameterDAO.Instance.GetParameter();

            // 2. Kiểm tra nếu có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                originalSettings = dt.Copy();
                DataRow row = originalSettings.Rows[0]; // Lấy dữ liệu từ bản sao

                // 3. Ánh xạ dữ liệu từ DataRow vào các Control
                txtMinFlightTime.Text = row["ThoiGianBayToiThieu"].ToString();
                txtMaxTransitCount.Text = row["SoSanBayTrungGianToiDa"].ToString();

                // Lưu ý: Nếu có ThoiGianDungToiThieu, bạn cũng phải thêm vào
                // Ví dụ: txtMinTransitDuration.Text = row["ThoiGianDungToiThieu"].ToString();

                txtMaxTransitDuration.Text = row["ThoiGianDungToiDa"].ToString();
                txtLatestBookingDays.Text = row["ThoiGianDatVeChamNhat"].ToString();
                txtLatestCancelDays.Text = row["ThoiGianHuyChamNhat"].ToString();
                txtMinTransitDuration.Text = row["ThoiGianDungToiThieu"].ToString();
                txtRefundPercentage.Text = row["PhanTramHoanTienKhiHuy"].ToString();
            }
            SetEditMode(false);
            // Bạn có thể xóa "private object reader;" vì nó không còn được dùng nữa.
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Đảm bảo tên nút Lưu của bạn là BtnSave

            // Kiểm tra định dạng trước khi Parse để tránh Exception
            if (!int.TryParse(txtMaxTransitCount.Text, out int maxTransitCount) ||
                !int.TryParse(txtLatestBookingDays.Text, out int latestBookingDays) ||
                !int.TryParse(txtLatestCancelDays.Text, out int latestCancelDays))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ cho các trường số.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy các giá trị chuỗi
            string minFlightTime = txtMinFlightTime.Text;
            string minTransitDuration = txtMinTransitDuration.Text;
            string maxTransitDuration = txtMaxTransitDuration.Text;

            try
            {
                // 2. Gọi hàm UPDATE từ BLL/DAO
                bool result = ParameterDAO.Instance.UpdateParameter(
                    maxTransitCount,
                    minFlightTime,
                    minTransitDuration,
                    maxTransitDuration,
                    latestBookingDays,
                    latestCancelDays
                );

                if (result)
                {
                    MessageBox.Show("Cài đặt đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🚀 HÀNH ĐỘNG MỚI: Tắt chế độ chỉnh sửa sau khi lưu thành công
                    SetEditMode(false);
                }
                else
                {
                    MessageBox.Show("Lưu thất bại. Vui lòng kiểm tra log.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // ... (Khối Catch giữ nguyên)
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào không đúng định dạng số hoặc thời gian.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Bật chế độ chỉnh sửa: các ô TextBox sẽ có ReadOnly = false
            SetEditMode(true);

            // (Tùy chọn) Đặt trọng tâm (focus) vào ô đầu tiên
            txtMinFlightTime.Focus();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (originalSettings != null && originalSettings.Rows.Count > 0)
            {
                // Lấy hàng dữ liệu gốc
                DataRow originalRow = originalSettings.Rows[0];

                // Gán lại các giá trị gốc vào các Control (TextBoxes)
                txtMinFlightTime.Text = originalRow["ThoiGianBayToiThieu"].ToString();
                txtMaxTransitCount.Text = originalRow["SoSanBayTrungGianToiDa"].ToString();
                txtMinTransitDuration.Text = originalRow["ThoiGianDungToiThieu"].ToString();
                txtMaxTransitDuration.Text = originalRow["ThoiGianDungToiDa"].ToString();
                txtLatestBookingDays.Text = originalRow["ThoiGianDatVeChamNhat"].ToString();
                txtLatestCancelDays.Text = originalRow["ThoiGianHuyChamNhat"].ToString();

                MessageBox.Show("Các tham số đã được khôi phục về giá trị ban đầu.", "Reset Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu gốc để khôi phục.", "Lỗi Reset", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
