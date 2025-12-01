using Airplace2025.BLL;
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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();

            PhanQuyen();

            
        }
        // Màu sắc tùy chỉnh (Bạn có thể thay đổi)
        private Color INACTIVE_COLOR = Color.Black; // Màu chữ khi không chọn
        private Color ACTIVE_COLOR = Color.DodgerBlue; // Màu chữ và màu gạch chân khi chọn

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button activeBtn)
        {
            // --- 1. RESET (Đưa tất cả các nút về trạng thái Mặc định) ---
            // Tạo một List hoặc mảng chứa tất cả các nút menu của bạn
            Guna.UI2.WinForms.Guna2Button[] menuButtons =
                new Guna.UI2.WinForms.Guna2Button[] { btnChuyenBay, btnVeMayBay, btnBaoCao,btnMayBay, btnLapLichBay };

            foreach (var btn in menuButtons)
            {
                // Đặt màu chữ về màu mặc định
                btn.ForeColor = INACTIVE_COLOR;

                // Đặt màu gạch chân (BorderColor) về màu nền (ẩn gạch chân)
                btn.BorderColor = Color.Transparent;
            }

            // --- 2. THIẾT LẬP (Nổi bật nút được chọn) ---

            // Đặt màu chữ cho nút đang được chọn
            activeBtn.ForeColor = ACTIVE_COLOR;

            // Đặt màu gạch chân cho nút đang được chọn (hiện gạch chân)
            activeBtn.BorderColor = ACTIVE_COLOR;

            // Nếu bạn muốn đổi cả màu nền khi chọn, bạn có thể thêm:
            // activeBtn.FillColor = Color.LightGray; 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmDanhSachChuyenBay());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmDatVe());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            LoadFormIntoPanel(new frmThongKe());

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            // ShowUserControl(new UC_ChuyenBay());
            LoadFormIntoPanel(new frmTraCuuDatVe());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Lấy nút vừa click (sender) và gọi hàm thiết lập trạng thái
            SetActiveButton((Guna.UI2.WinForms.Guna2Button)sender);

            // *Thực hiện các chức năng: Ví dụ: Hiển thị UserControl Chuyến Bay*
            LoadFormIntoPanel(new frmLapLichChuyenBay());
        }


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;

        private void LoadFormIntoPanel(Form childform)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            childform.FormBorderStyle = FormBorderStyle.None;

            pnlCommon.Controls.Clear();
            pnlCommon.Controls.Add(childform);
            pnlCommon.Tag = childform;
            childform.Show();
        }

        private void timerUpdateStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                FlightDAO.Instance.UpdateFlightStatusAuto();

            }
            catch
            {
                // Bỏ qua lỗi để không làm phiền người dùng
            }
        }

        private void PhanQuyen()
        {
           


            // Kiểm tra xem ai đang đăng nhập
            bool isAdmin = (Session.MaVaiTro == "ADMIN");

            // --- CẤU HÌNH CHO STAFF (Ẩn nút Admin, Hiện nút Staff) ---
            btnChuyenBay.Visible = !isAdmin;
            btnVeMayBay.Visible = !isAdmin;
            btnBaoCao.Visible = !isAdmin;
            btnMayBay.Visible = !isAdmin;
            btnLapLichBay.Visible = !isAdmin;

            // --- CẤU HÌNH CHO ADMIN (Hiện nút Admin, Ẩn nút Staff) ---
            // Giả sử bạn đã tạo nút btnNhanVien trên giao diện
            if (btnNhanVien != null)
            {
                btnNhanVien.Visible = isAdmin;
            }

            // --- MỞ FORM MẶC ĐỊNH TƯƠNG ỨNG ---
            if (isAdmin)
            {
                // Nếu là Admin -> Mở form Quản lý nhân viên
                if (btnNhanVien != null) SetActiveButton(btnNhanVien);

                // Bạn cần tạo frmQuanLyNhanVien trước nhé
                LoadFormIntoPanel(new frmQuanLiNhanVien()); 

                // (Tạm thời nếu chưa có form nhân viên thì hiện thông báo hoặc form rỗng)
                MessageBox.Show("Chào Admin! Đang tải giao diện quản trị...");
            }
            else
            {
                // Nếu là Staff -> Mở form Danh sách chuyến bay (như cũ)
                SetActiveButton(btnChuyenBay);
                LoadFormIntoPanel(new frmDanhSachChuyenBay());
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Xóa session
            this.Close(); // Đóng trang chủ
            frmDangNhap frm = new frmDangNhap();
            frm.Show(); // Hiện lại form đăng nhập
        }

        private void pnlCommon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {

            try
            {
                object value = Session.AnhDaiDien;

                // 1. Nếu không có dữ liệu
                if (value == null || value == DBNull.Value || value.ToString() == "")
                {
                    picMe.Image = Properties.Resources.noun_avatar_6781879;
                    picMe.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }

                byte[] imageData = null;

                // 2. TRƯỜNG HỢP A: Dữ liệu là Binary (byte[]) - Chuẩn VARBINARY
                if (value is byte[] bytes)
                {
                    imageData = bytes;
                }
                // 3. TRƯỜNG HỢP B: Dữ liệu là String (Base64) - Chuẩn bạn đang dùng
                else if (value is string base64String)
                {
                    try
                    {
                        // Chuyển chuỗi Base64 thành mảng byte
                        imageData = Convert.FromBase64String(base64String);
                    }
                    catch
                    {
                        // Nếu chuỗi không phải Base64 hợp lệ (ví dụ lưu đường dẫn file)
                        // Bạn có thể thử: picMe.Image = Image.FromFile(base64String);
                        imageData = null;
                    }
                }

                // 4. Hiển thị ảnh
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picMe.Image = new Bitmap(ms);
                    }
                    picMe.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    // Fallback về ảnh mặc định nếu chuyển đổi thất bại
                    picMe.Image = Properties.Resources.noun_avatar_6781879;
                    picMe.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                // Gặp lỗi bất kỳ -> dùng ảnh mặc định
                // Console.WriteLine(ex.Message);
                picMe.Image = Properties.Resources.noun_avatar_6781879;
                picMe.SizeMode = PictureBoxSizeMode.Zoom;
            }


        }

        private void picMe_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo form menu
            frmUserMenu menu = new frmUserMenu();

            // 2. Tính toán vị trí hiển thị
            // Lấy vị trí của ảnh đại diện trên màn hình (Screen coordinates)
            Point screenPos = picMe.PointToScreen(Point.Empty);

            // Đặt vị trí menu:
            // X = Cạnh phải của ảnh - Chiều rộng menu (để căn lề phải)
            // Y = Cạnh dưới của ảnh + 5px
            int x = screenPos.X + picMe.Width - menu.Width/2 - 20;
            int y = screenPos.Y + picMe.Height + 5;

            menu.Location = new Point(x, y);

            // 3. Hiển thị form menu
            menu.Show();
        }

        private void pnlCommon_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            Session.Clear(); // Xóa session
            this.Close(); // Đóng trang chủ
            frmDangNhap frm = new frmDangNhap();
            frm.Show(); // Hiện lại form đăng nhập
        }
    }
}
