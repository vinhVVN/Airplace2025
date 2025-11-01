using Airplace2025.BLL.DAO;
using Airplace2025.Properties;
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
    public partial class frmMayBay: Form
    {
        public frmMayBay()
        {
            InitializeComponent();
        }

        private void frmMayBay_Load(object sender, EventArgs e)
        {
            KichHoatControl(false);
            LoadAllAirline();
            LoadAirplane("Tất cả");
        }

        private void LoadAllAirline()
        {
            DataTable dt = AirlineDAO.Instance.GetAirlineList();
            cbHangBay.DataSource = dt;
            DataRow newRow = dt.NewRow();
            newRow["TenHangBay"] = "Tất cả";
            newRow["MaHangBay"] = "";
            dt.Rows.InsertAt(newRow, 0);
            cbHangBay.DisplayMember = "TenHangBay";
            cbHangBay.ValueMember = "MaHangBay";
            cbHangBay.SelectedIndex = 0;
        }

        private void LoadAirplane(string TenHangBay)
        {
            dgvAirplane.DataSource = AirplaneDAO.Instance.GetAirplanes_Airline(TenHangBay);
            
        }

        private void dgvAirplane_SelectionChanged(object sender, EventArgs e)
        {

            // NẾU ĐANG SỬA mà click sang hàng khác
            if (rowDangSua != null && dgvAirplane.SelectedRows.Count > 0 && dgvAirplane.SelectedRows[0] != rowDangSua)
            {
                // Hủy bỏ chỉnh sửa
                rowDangSua = null;
                KichHoatControl(false);
                btnFind.Enabled = true;
                btnAdd.Enabled = true;
            }

            if (dgvAirplane.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvAirplane.SelectedRows[0];
                    if (row.IsNewRow)
                    {
                        txtAirlineId.Text = string.Empty;
                        txtAirlineName.Text = string.Empty;
                        txtSeat.Text = string.Empty;
                        txtAirplaneId.Text = string.Empty;
                        txtAirplaneName.Text = string.Empty;
                        txtDescrip.Text = string.Empty;
                    }
                    else
                    {
                        txtAirplaneId.Text = row.Cells["MaMayBay"].Value?.ToString() ?? "";
                        txtAirplaneName.Text = row.Cells["TenMayBay"].Value?.ToString() ?? "";
                        txtSeat.Text = row.Cells["SoGhe"].Value?.ToString() ?? "";
                        txtAirlineId.Text = row.Cells["MaHangBay"].Value?.ToString() ?? "";

                        txtAirlineName.Text = row.Cells["TenHangBay"].Value?.ToString() ?? "";
                        txtDescrip.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                        try
                        {
                            object value = row.Cells["Logo"].Value;
                            if (value == null || value == DBNull.Value)
                            {
                                imgLogo.Image = Resources.pngaaa_com_791768;
                            }
                            else
                            {
                                byte[] imageData = (byte[])value;

                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    
                                    imgLogo.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            imgLogo.Image = Resources.pngaaa_com_791768;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataGridViewRow rowDangSua = null;

        private void dgvAirplane_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // nếu click vào tiêu đề

            string tenCot = dgvAirplane.Columns[e.ColumnIndex].Name;
            DataGridViewRow rowHienTai = dgvAirplane.Rows[e.RowIndex];

            if (tenCot == "btnEdit")
            {
                if (rowDangSua == null)
                {
                    rowDangSua = rowHienTai;
                    KichHoatControl(true);
                    btnFind.Enabled = false;
                    btnAdd.Enabled = false;

                }
                else if (rowDangSua == rowHienTai)
                {
                    try
                    {
                        string MaMayBay = txtAirplaneName.Text;
                        string TenMayBayMoi = txtAirplaneName.Text;
                        int SoGheMoi;
                        if (string.IsNullOrWhiteSpace(TenMayBayMoi))
                        {
                            MessageBox.Show("Tên máy bay không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(txtSeat.Text, out SoGheMoi) || SoGheMoi <= 0)
                        {
                            MessageBox.Show("Số ghế phải là một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            // đã chọn ảnh mới 
                            imageData = File.ReadAllBytes(imagePath);
                        }
                        else
                        {
                            // không chọn ảnh mới. 
                            if (imgLogo.Image != null && imgLogo.Image != Resources.pngaaa_com_791768)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    imgLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    imageData = ms.ToArray();
                                }
                            }
                            else
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Resources.pngaaa_com_791768.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    imageData = ms.ToArray();
                                }
                            }
                        }

                        if (AirplaneDAO.Instance.UpdateAirplaneAndAirline(
                                txtAirplaneId.Text, txtAirplaneName.Text,
                                Convert.ToInt32(txtSeat.Text), txtAirlineId.Text,
                                txtAirlineName.Text,txtDescrip.Text, imageData
                            
                            ))
                        {
                            rowDangSua = null;
                            KichHoatControl(false);
                            btnFind.Enabled = true;
                            btnAdd.Enabled = true;
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAirplane("Tất cả");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
            }
            else if (tenCot == "btnDel")
            {
                // Nếu đang sửa thì không cho xóa
                if (rowDangSua != null)
                {
                    MessageBox.Show("Vui lòng hoàn tất/hủy bỏ chỉnh sửa trước khi xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xoá máy bay này?",
                                               "Xác nhận",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    AirplaneDAO.Instance.DeleteAirplane(rowHienTai.Cells["MaMayBay"].Value.ToString());
                    LoadAirplane("Tất cả");
                }
            }
        }

        private void KichHoatControl(bool tt)
        {
            txtAirlineName.Enabled = tt;
            txtAirplaneName.Enabled = tt;
            txtDescrip.Enabled = tt;
            txtSeat.Enabled = tt;
            imgLogo.Enabled = tt;


        }

        private string imagePath;
        private byte[] imageData;

        private void imgLogo_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    imgLogo.Image = Image.FromFile(imagePath);
                    imgLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadAirplane(cbHangBay.Text);
        }
    }
}
