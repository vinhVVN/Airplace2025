using Airplace2025.DAL;
using System;
using System.Collections.Generic;

namespace Airplace2025.BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL _instance;
        public static HoaDonBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HoaDonBLL();
                return _instance;
            }
        }

        private HoaDonBLL() { }

        public string ThanhToan(decimal tongTien, string phuongThuc, List<string> danhSachMaDatVe, out string maHoaDon)
        {
            try
            {
                maHoaDon = HoaDonDAO.Instance.GenerateNewMaHoaDon();
                return HoaDonDAO.Instance.ThanhToanVaXuatVe(maHoaDon, phuongThuc, tongTien, danhSachMaDatVe);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thanh toán: " + ex.Message);
            }
        }
    }
}

