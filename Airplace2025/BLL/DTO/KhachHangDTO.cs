using System;

namespace Airplace2025.BLL.DTO
{
    public class KhachHangDTO
    {
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string CCCD { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiKhachHang { get; set; } // Red, Silver, Gold, Diamond

        /// <summary>
        /// Format hiển thị cho ComboBox
        /// </summary>
        public override string ToString()
        {
            return $"{MaKhachHang} - {HoTen}";
        }
    }
}


