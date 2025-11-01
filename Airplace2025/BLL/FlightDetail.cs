using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.BLL
{
    public class FlightDetail
    {
        public string MaChuyenBay { get; set; }
        public string MaSanBayDi { get; set; }
        public string TenSanBayDi { get; set; }
        public string MaSanBayDen { get; set; }
        public string TenSanBayDen { get; set; }
        public DateTime NgayGioBay { get; set; }
        public DateTime NgayGioDen { get; set; }
        public int ThoiGianBay { get; set; }
        public int TongThoiGianDung { get; set; }
        public int TongThoiGianHanhTrinh { get; set; }
        public int SoDiemDung { get; set; }
        public string TenMayBay { get; set; }

        public string TenHangBay { get; set; }
        public Image Logo { get; set; }

        public static Image ConvertByteArraytoImage(object data)
        {
            if (data == null || data == DBNull.Value) {
                return null;
            }
            try
            {
                byte[] byteArray = (byte[])data;
                if (byteArray.Length == 0)
                {
                    return null;
                }
                using (var ms = new MemoryStream(byteArray, 0, byteArray.Length))
                {
                    return Image.FromStream(ms, true);
                }
            }
            catch
            {
                return null;
            }
        }
    }

    public class TrungGianChiTiet
    {
        public int ThuTu { get; set; }
        public string MaSanBay { get; set; }
        public string TenSanBay { get; set; }

        public int ThoiGianDung { get; set; }
        public string GhiChu { get; set; }
        public string TenHangBay { get; set; }
        public Image Logo { get; set; }
        public int ThoiGianChuyen { get; set; }
    }

    public class FlightResult
    {
        public FlightResult()
        {
            dsTrungGian = new List<TrungGianChiTiet>();
        }
        public FlightDetail ThongTin { get; set; }
        public List<TrungGianChiTiet> dsTrungGian { get; set; }

    }

}
