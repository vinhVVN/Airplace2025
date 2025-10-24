using System;

namespace Airplace2025.BLL.DTO
{
    /// <summary>
    /// Data Transfer Object cho thông tin chuyến bay
    /// </summary>
    public class ChuyenBayDTO
    {
        public string MaChuyenBay { get; set; }
        public string MaSanBayDi { get; set; }
        public string MaSanBayDen { get; set; }
        public string TenSanBayDi { get; set; }
        public string TenSanBayDen { get; set; }
        public DateTime NgayGioBay { get; set; }
        public DateTime NgayGioDen { get; set; }
        public string TrangThai { get; set; }
        public string MaHangBay { get; set; }
        public string TenHangBay { get; set; }
        public string Logo { get; set; }
        public string MaMayBay { get; set; }
        public string TenMayBay { get; set; }
        public int SoGheTrong { get; set; }
        public decimal GiaCoBan { get; set; }
        public int ThoiGianBay { get; set; } // Tính bằng phút
        
        // Thông tin hạng vé
        public int? GheEconomy { get; set; }
        public int? GhePremium { get; set; }
        public int? GheBusiness { get; set; }
        public int? GheFirst { get; set; }
        public decimal? GiaEconomy { get; set; }
        public decimal? GiaPremium { get; set; }
        public decimal? GiaBusiness { get; set; }
        public decimal? GiaFirst { get; set; }
    }
}



