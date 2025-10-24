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

            // Lọc theo hạng vé và số ghế trống
            flights = flights.Where(f => f.SoGheTrong >= tongHanhKhach).ToList();

            // Enrich thông tin hạng vé
            foreach (var flight in flights)
            {
                try
                {
                    var hangVeInfo = ChuyenBayDAO.Instance.GetHangVeInfo(flight.MaChuyenBay);

                    if (hangVeInfo.ContainsKey("Economy"))
                    {
                        flight.GheEconomy = hangVeInfo["Economy"].SoLuongConLai;
                        flight.GiaEconomy = hangVeInfo["Economy"].Gia;
                    }

                    if (hangVeInfo.ContainsKey("Premium"))
                    {
                        flight.GhePremium = hangVeInfo["Premium"].SoLuongConLai;
                        flight.GiaPremium = hangVeInfo["Premium"].Gia;
                    }

                    if (hangVeInfo.ContainsKey("Business"))
                    {
                        flight.GheBusiness = hangVeInfo["Business"].SoLuongConLai;
                        flight.GiaBusiness = hangVeInfo["Business"].Gia;
                    }
                }
                catch
                {
                    // Nếu lỗi khi lấy thông tin hạng vé, bỏ qua
                }
            }

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
        public DataTable GetServiceClasses()
        {
            return ChuyenBayDAO.Instance.GetServiceClasses();
        }

        /// <summary>
        /// Format danh sách hạng vé cho ComboBox
        /// </summary>
        public List<string> GetFormattedServiceClassList()
        {
            List<string> result = new List<string>();
            DataTable serviceClasses = GetServiceClasses();

            foreach (DataRow row in serviceClasses.Rows)
            {
                result.Add(row["TenHangVe"].ToString());
            }

            return result;
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



