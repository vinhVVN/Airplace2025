using System;

namespace Airplace2025.BLL.DTO
{
    /// <summary>
    /// Tham số tìm kiếm chuyến bay
    /// </summary>
    public class SearchFlightParams
    {
        public string MaSanBayDi { get; set; }
        public string MaSanBayDen { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime? NgayVe { get; set; } // Null nếu 1 chiều
        public int SoNguoiLon { get; set; }
        public int SoTreEm { get; set; }
        public int SoEmBe { get; set; }
        public string HangDichVu { get; set; } // Economy, Premium, Business, 
        public bool LaKhuHoi { get; set; }

        public SearchFlightParams()
        {
            NgayDi = DateTime.Now;
            SoNguoiLon = 1;
            SoTreEm = 0;
            SoEmBe = 0;
            HangDichVu = "Economy";
            LaKhuHoi = false;
        }
    }
}



