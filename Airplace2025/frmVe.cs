using Airplace2025.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmVe : Form
    {
        public frmVe()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox33_TextChanged(object sender, EventArgs e)
        {

        }

        // Hàm nhận dữ liệu từ DataRow (giả sử lấy từ SP TraCuuDatVe)
        public void SetTicketData(DataRow ticketData)
        {
            if (ticketData == null) return;

            try
            {
                // 1. Lấy dữ liệu thô
                string hoTen = ticketData["HoTen"].ToString().ToUpper();
                string maDatVe = ticketData["MaDatVe"].ToString();
                string maGhe = ticketData["MaGhe"].ToString();
                string maChuyenBay = ticketData["MaChuyenBay"].ToString();
                string tenHangVeVN = ticketData["TenHangVe"].ToString();
                string tenHangBay = ticketData["TenHangBay"].ToString();
                string quocgiaDi = ticketData["QuocGiaDi"].ToString();
                string quocgiaDen = ticketData["QuocGiaDen"].ToString();
                string maSanBayDi = ticketData["MaSanBayDi"].ToString();

                DateTime ngayDi = Convert.ToDateTime(ticketData["NgayGioBay"]);
                int thoiGianBay = Convert.ToInt32(ticketData["ThoiGianBay"]);
                DateTime ngayDen = ngayDi.AddMinutes(thoiGianBay);

                string sanBayDi = ticketData["TenSanBayDi"].ToString(); // VD: Tân Sơn Nhất
                string sanBayDen = ticketData["TenSanBayDen"].ToString(); // VD: Đà Nẵng
                string maSanBayDen = ticketData["MaSanBayDen"].ToString(); // VD: DAD

                // 2. Xử lý & Format dữ liệu

                // lbTenKhachHang: Tên khách
                if (lbTenKhachHang != null) lbTenKhachHang.Text = hoTen;
                if (lbTenKhachHang2 != null) lbTenKhachHang2.Text = hoTen; // Tên ở cuống vé nhỏ

                // lbNgayDi_NgayDen_NoiDen: "20/05 > 20/05 TRIP TO SAN BAY DA NANG"
                string noiDenKhongDau = TicketHelper.RemoveSign(sanBayDen).ToUpper();

                lbNgayDi_NgayDen_NoiDen.Text = $"{ngayDi:dd/MM} > {ngayDen:dd/MM} TRIP TO {noiDenKhongDau}";
                lbNgayBay.Text = $"{ngayDi:dd/MM}";
                lbQuocGiaDi.Text = quocgiaDi;
                lbQuocGiaDen.Text = quocgiaDen;
                lbTenHangBay.Text = tenHangBay;
                lbMaChuyenBay.Text = maChuyenBay;
                lbMaSanBayDi.Text = maSanBayDi;
                lbMaSanBayDen.Text = maSanBayDen;
                lbThoiGianBay.Text = TicketHelper.FormatDuration(thoiGianBay);
                lbThoiDiemBay.Text = ngayDi.ToString("HH:mm");
                lbThoiDiemDen.Text = ngayDen.ToString("HH:mm");

                lbSanBayDi.Text = TicketHelper.RemoveSign(sanBayDi).ToUpper();
                lbSanBayDi.TextAlign = HorizontalAlignment.Left;
                lbSanBayDen.Text = TicketHelper.RemoveSign(sanBayDen).ToUpper();
                lbSanBayDen.TextAlign = HorizontalAlignment.Left;
                lbTenHangVe.Text = TicketHelper.TranslateTicketClass(tenHangVeVN).ToUpper();
                lbTenMayBay.Text = ticketData["TenMayBay"].ToString();

                // lbMaGhe & lbTenHangVe
                if (lbMaGhe != null) lbMaGhe.Text = string.IsNullOrEmpty(maGhe) ? "TBA" : maGhe;


                // Các control có sẵn trong Designer bạn gửi
                if (lbMaDatVe != null) lbMaDatVe.Text = maDatVe;
                if (lbMaHoaDon != null) lbMaHoaDon.Text = ticketData["MaHoaDon"].ToString();

                // Logo hãng (nếu có cột Logo byte[])
                if (ticketData.Table.Columns.Contains("Logo") && ticketData["Logo"] != DBNull.Value && picAirline != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])ticketData["Logo"]))
                    {
                        picAirline.Image = Image.FromStream(ms);
                    }
                }
                FormatAsLabels(
                    lbTenKhachHang,
                    lbTenKhachHang2,
                    lbNgayDi_NgayDen_NoiDen,
                    lbThoiGianBay,
                    lbThoiDiemBay,
                    lbSanBayDi,
                    lbMaGhe,
                    lbMaDatVe,
                    lbMaHoaDon,
                    lbTenHangVe,
                    lbTenMayBay,
                    lbThoiDiemDen,
                    lbSanBayDen,
                    lbMaChuyenBay,
                    lbMaSanBayDi,
                    lbMaSanBayDen,
                    lbTenHangBay,
                    lbQuocGiaDi,
                    lbQuocGiaDen,
                    guna2TextBox2,
                    guna2TextBox3,
                    guna2TextBox6,
                    guna2TextBox8,
                    guna2TextBox11,
                    guna2TextBox14,
                    guna2TextBox13,
                    guna2TextBox16,
                    guna2TextBox21,
                    guna2TextBox22,
                    guna2TextBox23,
                    guna2TextBox24,
                    guna2TextBox29,
                    guna2TextBox32,
                    guna2TextBox33,
                    guna2TextBox34,
                    lbNgayBay
                );

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị vé: " + ex.Message);
            }
        }

        private void FormatAsLabels(params Control[] controls)
        {
            foreach (Control c in controls)
            {
                // Kiểm tra xem có phải là Guna2TextBox không trước khi ép kiểu
                if (c is Guna.UI2.WinForms.Guna2TextBox txt)
                {
                    txt.ReadOnly = true;                // Không cho sửa
                    txt.BorderThickness = 0;            // Ẩn viền
                    txt.Cursor = Cursors.Default;       // Con trỏ chuột bình thường (không phải I-beam)
                    txt.FocusedState.BorderColor = Color.Transparent; // Không hiện viền khi click vào

                    
                }
            }
        }

        

    }
}
