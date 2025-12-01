using Airplace2025.BLL.DTO;
using Airplace2025.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

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

            // Separate Passengers with Seats vs Infants
            var passengersWithSeats = new List<KhachHangDTO>();
            var infants = new List<KhachHangDTO>();

            foreach (var cust in customers)
            {
                if (IsInfant(cust))
                    infants.Add(cust);
                else
                    passengersWithSeats.Add(cust);
            }

            // Map Infant to Adult (Simple logic: 1st Infant -> 1st Adult/PassengerWithSeat)
            // Note: In reality, we should allow user to choose, but here we auto-assign sequentially.
            
            // Process all customers
            // We iterate through the main list to maintain order or process separately? 
            // Let's iterate original list but handle logic based on type.
            
            // Helper to find guardian's seat
            // Assume infants are assigned to passengersWithSeats in order
            int infantIndex = 0;
            
            foreach (var cust in customers)
            {
                bool isInfant = IsInfant(cust);
                string seatCodeDep = cust.MaGheDi;
                string seatCodeRet = cust.MaGheVe;

                if (isInfant)
                {
                    // Find guardian (a passenger with a seat)
                    // Logic: Assign infant to the next available adult/child sequentially
                    // If more infants than seat-holders (unlikely due to rules), fallback to first.
                    
                    if (passengersWithSeats.Count > 0)
                    {
                        int guardianIndex = infantIndex % passengersWithSeats.Count;
                        var guardian = passengersWithSeats[guardianIndex];
                        seatCodeDep = guardian.MaGheDi; // Share seat
                        seatCodeRet = guardian.MaGheVe; // Share seat
                        infantIndex++;
                    }
                    else
                    {
                        seatCodeDep = "INF"; // Fallback if no guardian found (should validation prevent this)
                        seatCodeRet = "INF";
                    }
                }

                // 1. Departure Flight
                if (depFare != null)
                {
                    string maVe = DatVeDAO.Instance.CreateVe(
                        depFare.Flight.MaChuyenBay, 
                        depClassCode, 
                        depFare.FarePrice
                    );

                    string maDatVe = DatVeDAO.Instance.CreateChiTietDatVe(maVe, cust.MaKhachHang, 
                        string.IsNullOrEmpty(seatCodeDep) ? "ANY" : seatCodeDep);
                    ticketIds.Add(maDatVe);

                    // Only decrease capacity if NOT infant (or if policy requires it, usually infants don't take seats)
                    if (!isInfant)
                    {
                        DatVeDAO.Instance.DecreaseSeatCount(depFare.Flight.MaChuyenBay, depClassCode);
                    }
                }

                // 2. Return Flight (if exists)
                if (retFare != null && retFare.Flight != null)
                {
                    string maVe = DatVeDAO.Instance.CreateVe(
                        retFare.Flight.MaChuyenBay, 
                        retClassCode, 
                        retFare.FarePrice
                    );

                    string maDatVe = DatVeDAO.Instance.CreateChiTietDatVe(maVe, cust.MaKhachHang, 
                        string.IsNullOrEmpty(seatCodeRet) ? "ANY" : seatCodeRet);
                    ticketIds.Add(maDatVe);

                    if (!isInfant)
                    {
                        DatVeDAO.Instance.DecreaseSeatCount(retFare.Flight.MaChuyenBay, retClassCode);
                    }
                }
            }

            return ticketIds;
        }

        private bool IsInfant(KhachHangDTO cust)
        {
            if (!cust.NgaySinh.HasValue) return false;
            // Calculate age strictly
            // Assuming booking is for NOW. Ideally compare with Flight Date.
            // BLL usually shouldn't rely on DateTime.Now if flight is next year, but for simplicity:
            int age = DateTime.Now.Year - cust.NgaySinh.Value.Year;
            if (DateTime.Now < cust.NgaySinh.Value.AddYears(age)) age--;
            return age < 2;
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
