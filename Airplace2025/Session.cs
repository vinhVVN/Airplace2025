using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025
{
    public static class Session
    {
        public static string MaNhanVien { get; set; }
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string MaVaiTro { get; set; }
        public static string TenVaiTro { get; set; }

        public static object AnhDaiDien { get; set; }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(MaNhanVien);

        public static void Clear()
        {
            MaNhanVien = null;
            TenDangNhap = null;
            HoTen = null;
            MaVaiTro = null;
            TenVaiTro = null;
            AnhDaiDien = null;
        }
    }
}

