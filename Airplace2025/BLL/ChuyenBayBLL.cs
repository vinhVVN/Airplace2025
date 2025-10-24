using Airplace2025.BLL.DTO;
using Airplace2025.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Airplace2025.BLL
{
    /// <summary>
    /// Business Logic Layer cho ChuyenBay
    /// </summary>
    public class ChuyenBayBLL
    {
        private static ChuyenBayBLL _instance;
        public static ChuyenBayBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChuyenBayBLL();
                return _instance;
            }
        }

        private ChuyenBayBLL() { }

        /// <summary>
        /// Lọc chuyến bay theo số ghế còn lại của hạng vé cụ thể
        /// </summary>
        private List<ChuyenBayDTO> FilterByServiceClassAvailability(List<ChuyenBayDTO> flights, string hangDichVu, int soHanhKhach)
        {
            if (string.IsNullOrEmpty(hangDichVu))
                return flights;

            string lowerHangDichVu = hangDichVu.ToLower();

            return flights.Where(f =>
            {
                // Kiểm tra số ghế còn lại của hạng vé đang tìm
                if (lowerHangDichVu.Contains("phổ thông") && !lowerHangDichVu.Contains("đặc biệt"))
                {
                    return (f.GheEconomy ?? 0) >= soHanhKhach;
                }
                else if (lowerHangDichVu.Contains("đặc biệt"))
                {
                    return (f.GhePremium ?? 0) >= soHanhKhach;
                }
                else if (lowerHangDichVu.Contains("thương gia"))
                {
                    return (f.GheBusiness ?? 0) >= soHanhKhach;
                }
                else if (lowerHangDichVu.Contains("hạng nhất"))
                {
                    return (f.GheFirst ?? 0) >= soHanhKhach;
                }
                else
                {
                    // Mặc định là phổ thông
                    return (f.GheEconomy ?? 0) >= soHanhKhach;
                }
            }).ToList();
        }

        /// <summary>
        /// Tìm kiếm chuyến bay với các business rules
        /// </summary>
        public List<ChuyenBayDTO> SearchFlights(SearchFlightParams searchParams)
        {
            // Validation
            if (string.IsNullOrEmpty(searchParams.MaSanBayDi))
                throw new Exception("Vui lòng chọn sân bay đi");

            if (string.IsNullOrEmpty(searchParams.MaSanBayDen))
                throw new Exception("Vui lòng chọn sân bay đến");

            if (searchParams.MaSanBayDi == searchParams.MaSanBayDen)
                throw new Exception("Sân bay đi và đến không được trùng nhau");

            if (searchParams.NgayDi < DateTime.Now.Date)
                throw new Exception("Ngày đi không được nhỏ hơn ngày hiện tại");

            if (searchParams.LaKhuHoi && searchParams.NgayVe.HasValue)
            {
                if (searchParams.NgayVe.Value < searchParams.NgayDi)
                    throw new Exception("Ngày về không được nhỏ hơn ngày đi");
            }

            int tongHanhKhach = searchParams.SoNguoiLon + searchParams.SoTreEm + searchParams.SoEmBe;
            if (tongHanhKhach == 0)
                throw new Exception("Phải có ít nhất 1 hành khách");

            if (tongHanhKhach > 9)
                throw new Exception("Tối đa 9 hành khách cho một lần đặt");

            // Kiểm tra ràng buộc INF
            if (searchParams.SoEmBe > searchParams.SoNguoiLon)
                throw new Exception("Số em bé không được vượt quá số người lớn");

            // Gọi DAL để tìm kiếm
            List<ChuyenBayDTO> flights = ChuyenBayDAO.Instance.SearchFlights(searchParams);

            // Enrich thông tin hạng vé trước khi lọc
            foreach (var flight in flights)
            {
                try
                {
                    var hangVeInfo = ChuyenBayDAO.Instance.GetHangVeInfo(flight.MaChuyenBay);

                    // Khởi tạo giá trị mặc định là 0 cho tất cả hạng vé
                    flight.GheEconomy = 0;
                    flight.GhePremium = 0;
                    flight.GheBusiness = 0;
                    flight.GheFirst = 0;

                    // Map tên hạng vé từ database (tiếng Việt) sang các thuộc tính DTO
                    if (hangVeInfo.ContainsKey("Phổ thông"))
                    {
                        flight.GheEconomy = hangVeInfo["Phổ thông"].SoLuongConLai;
                        flight.GiaEconomy = hangVeInfo["Phổ thông"].Gia;
                    }

                    if (hangVeInfo.ContainsKey("Phổ thông đặc biệt"))
                    {
                        flight.GhePremium = hangVeInfo["Phổ thông đặc biệt"].SoLuongConLai;
                        flight.GiaPremium = hangVeInfo["Phổ thông đặc biệt"].Gia;
                    }

                    if (hangVeInfo.ContainsKey("Thương gia"))
                    {
                        flight.GheBusiness = hangVeInfo["Thương gia"].SoLuongConLai;
                        flight.GiaBusiness = hangVeInfo["Thương gia"].Gia;
                    }

                    if (hangVeInfo.ContainsKey("Hạng nhất"))
                    {
                        flight.GheFirst = hangVeInfo["Hạng nhất"].SoLuongConLai;
                        flight.GiaFirst = hangVeInfo["Hạng nhất"].Gia;
                    }
                }
                catch
                {
                    // Nếu lỗi khi lấy thông tin hạng vé, giữ giá trị mặc định 0
                    flight.GheEconomy = 0;
                    flight.GhePremium = 0;
                    flight.GheBusiness = 0;
                    flight.GheFirst = 0;
                }
            }

            // Lọc theo số ghế của hạng vé đang tìm
            flights = FilterByServiceClassAvailability(flights, searchParams.HangDichVu, tongHanhKhach);

            return flights;
        }

        /// <summary>
        /// Lấy danh sách sân bay để hiển thị trên ComboBox
        /// </summary>
        public DataTable GetAirports()
        {
            return ChuyenBayDAO.Instance.GetAirports();
        }

        /// <summary>
        /// Format thông tin sân bay cho ComboBox (Mã - Tên - Thành phố)
        /// </summary>
        public List<string> GetFormattedAirportList()
        {
            List<string> result = new List<string>();
            DataTable airports = GetAirports();

            foreach (DataRow row in airports.Rows)
            {
                string formatted = $"{row["MaSanBay"]} - {row["TenSanBay"]}";
                result.Add(formatted);
            }

            return result;
        }

        /// <summary>
        /// Lấy danh sách hạng vé từ database
        /// </summary>
        public List<HangVeDTO> GetServiceClasses()
        {
            return ChuyenBayDAO.Instance.GetServiceClasses();
        }

        /// <summary>
        /// Format danh sách hạng vé cho ComboBox (trả về List<HangVeDTO>)
        /// </summary>
        public List<HangVeDTO> GetFormattedServiceClassList()
        {
            return GetServiceClasses();
        }

        /// <summary>
        /// Lấy mã hạng vé từ tên hạng vé
        /// </summary>
        public string GetMaHangVe(string tenHangVe)
        {
            if (string.IsNullOrEmpty(tenHangVe))
                return null;

            List<HangVeDTO> hangVeList = GetServiceClasses();
            var hangVe = hangVeList.FirstOrDefault(hv => hv.TenHangVe.Equals(tenHangVe, StringComparison.OrdinalIgnoreCase));
            
            return hangVe?.MaHangVe;
        }

        /// <summary>
        /// Lấy tỉ lệ giá của hạng vé
        /// </summary>
        public decimal GetTiLeGiaHangVe(string tenHangVe)
        {
            if (string.IsNullOrEmpty(tenHangVe))
                return 1.0m;

            List<HangVeDTO> hangVeList = GetServiceClasses();
            var hangVe = hangVeList.FirstOrDefault(hv => hv.TenHangVe.Equals(tenHangVe, StringComparison.OrdinalIgnoreCase));
            
            return hangVe?.TiLeGiaHangVe ?? 1.0m;
        }

        /// <summary>
        /// Trích xuất mã sân bay từ chuỗi format (HAN - Noi Bai - Ha Noi)
        /// </summary>
        public string ExtractAirportCode(string formattedString)
        {
            if (string.IsNullOrEmpty(formattedString))
                return null;

            int dashIndex = formattedString.IndexOf(" - ");
            if (dashIndex > 0)
                return formattedString.Substring(0, dashIndex).Trim();

            return formattedString.Trim();
        }

        /// <summary>
        /// Format thời gian bay (phút -> giờ phút)
        /// </summary>
        public string FormatFlightDuration(int minutes)
        {
            int hours = minutes / 60;
            int mins = minutes % 60;

            if (hours > 0)
                return $"{hours}h {mins}m";
            else
                return $"{mins}m";
        }

        /// <summary>
        /// Tính giá vé theo hạng và số lượng hành khách
        /// </summary>
        public decimal CalculateTotalPrice(ChuyenBayDTO flight, string hangVe, int soNguoiLon, int soTreEm, int soEmBe)
        {
            decimal giaVe = 0;

            switch (hangVe.ToLower())
            {
                case "economy":
                    giaVe = flight.GiaEconomy ?? flight.GiaCoBan;
                    break;
                case "premium":
                    giaVe = flight.GiaPremium ?? flight.GiaCoBan * 1.5m;
                    break;
                case "business":
                    giaVe = flight.GiaBusiness ?? flight.GiaCoBan * 2m;
                    break;
                case "first":
                    giaVe = flight.GiaFirst ?? flight.GiaCoBan * 3m;
                    break;
                default:
                    giaVe = flight.GiaCoBan;
                    break;
            }

            // Tính giá theo loại hành khách
            decimal tongGia = (soNguoiLon * giaVe) + 
                             (soTreEm * giaVe * 0.75m) +  // Trẻ em 75% giá vé
                             (soEmBe * giaVe * 0.1m);     // Em bé 10% giá vé

            return tongGia;
        }
    }
}



