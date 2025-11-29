using Airplace2025.BLL.DTO;
using Airplace2025.DAL;
using System;
using System.Collections.Generic;

namespace Airplace2025.BLL
{
    public class DatVeBLL
    {
        private static DatVeBLL _instance;
        public static DatVeBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatVeBLL();
                return _instance;
            }
        }

        private DatVeBLL() { }

        public List<string> ProcessBooking(List<KhachHangDTO> customers, SelectedFareInfo depFare, SelectedFareInfo retFare)
        {
            List<string> ticketIds = new List<string>();

            // Map Cabin Name to Code (simplified logic, should match DB)
            string depClassCode = GetClassCode(depFare?.CabinClass);
            string retClassCode = GetClassCode(retFare?.CabinClass);

            foreach (var cust in customers)
            {
                // 1. Departure Flight
                if (depFare != null)
                {
                    // Create Ve
                    string maVe = DatVeDAO.Instance.CreateVe(
                        depFare.Flight.MaChuyenBay, 
                        depClassCode, 
                        depFare.FarePrice
                    );

                    // Create ChiTietDatVe
                    // Note: MaGhe is mocked as "A1" because seat selection is skipped
                    string maDatVe = DatVeDAO.Instance.CreateChiTietDatVe(maVe, cust.MaKhachHang, "A1");
                    ticketIds.Add(maDatVe);

                    // Update Capacity
                    DatVeDAO.Instance.DecreaseSeatCount(depFare.Flight.MaChuyenBay, depClassCode);
                }

                // 2. Return Flight (if exists)
                if (retFare != null && retFare.Flight != null)
                {
                    string maVe = DatVeDAO.Instance.CreateVe(
                        retFare.Flight.MaChuyenBay, 
                        retClassCode, 
                        retFare.FarePrice
                    );

                    string maDatVe = DatVeDAO.Instance.CreateChiTietDatVe(maVe, cust.MaKhachHang, "A1");
                    ticketIds.Add(maDatVe);

                    DatVeDAO.Instance.DecreaseSeatCount(retFare.Flight.MaChuyenBay, retClassCode);
                }
            }

            return ticketIds;
        }

        private string GetClassCode(string className)
        {
            if (string.IsNullOrEmpty(className)) return "ECO";
            string lower = className.ToLower();
            if (lower.Contains("thương gia") || lower.Contains("business")) return "BUS";
            if (lower.Contains("đặc biệt") || lower.Contains("premium")) return "PRE";
            if (lower.Contains("nhất") || lower.Contains("first")) return "FIR";
            return "ECO";
        }
    }
}
