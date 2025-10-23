using Airplace2025.BLL;
using Airplace2025.BLL.DAO;
using Airplace2025.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmThongTinChuyenBay: Form
    {
        public frmThongTinChuyenBay(string maChuyenBay)
        {
            InitializeComponent();
            _maChuyenBay = maChuyenBay;
        }

        private string _maChuyenBay;

        private string FormatDuration(int totalMinutes)
        {
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            if (hours > 0)
            {
                return $"{hours}h {minutes}m";
            }
            else
            {
                return $"{minutes}m";
            }
        }

        private void LoadFlightData()
        {
            if (string.IsNullOrEmpty(_maChuyenBay)){
                MessageBox.Show("Không có mã chuyến bay");
                return;
            }
            FlightResult data;
            try
            {
                data = FlightDAO.Instance.GetFlightDetail(_maChuyenBay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var ThongTin = data.ThongTin;
            var dsTrungGian = data.dsTrungGian;
            
            lbDestination.Text = ThongTin.MaSanBayDi;
            lbOrigin.Text = ThongTin.MaSanBayDen;
            lbDepartureTime.Text = ThongTin.NgayGioBay.ToString("HH:mm");
            lbTotalDuration.Text = FormatDuration(ThongTin.TongThoiGianHanhTrinh);
            lbArrivalTime.Text = ThongTin.NgayGioDen.ToString("HH:mm");
            lbStops.Text = ThongTin.SoDiemDung.ToString() + " stops";

            // Giao diện động
            pnlItinerary.Controls.Clear();
            string currentOrigin = ThongTin.MaSanBayDi;
            string currentOriginName = ThongTin.TenSanBayDi;
            DateTime currentOriginTime = ThongTin.NgayGioBay;
            


            foreach (var stop in dsTrungGian)
            {
                var legControl = new FlightLegControl();

                TimelineNodeType legType = (currentOrigin ==ThongTin.MaSanBayDi)? TimelineNodeType.Start : TimelineNodeType.None;

                legControl.SetData(
                    ThongTin.MaChuyenBay,
                    stop.TenHangBay,
                    ThongTin.TenMayBay,
                    currentOrigin,
                    stop.MaSanBay,
                    currentOriginName,
                    stop.TenSanBay,
                    currentOriginTime.ToString("HH:mm"),
                    currentOriginTime.AddMinutes(stop.ThoiGianChuyen).ToString("HH:mm"),
                    currentOriginTime.ToString("dd/MM/yyyy"),
                    currentOriginTime.AddMinutes(stop.ThoiGianChuyen).ToString("dd/MM/yyyy"),
                    FormatDuration(stop.ThoiGianChuyen),
                    stop.Logo,
                    legType

                );
                pnlItinerary.Controls.Add(legControl);
                var stopControl = new StopControl();
                stopControl.SetData(
                    stop.ThoiGianDung
                );
                pnlItinerary.Controls.Add(stopControl);
                // Cập nhật cho điểm xuất phát tiếp theo
                currentOrigin = stop.MaSanBay;
                currentOriginName = stop.TenSanBay;
                currentOriginTime = currentOriginTime.AddMinutes(stop.ThoiGianDung + stop.ThoiGianChuyen);

            }
            // Thêm đoạn bay cuối cùng (Từ điểm dừng cuối cùng ĐẾN sân bay đích) (Hoặc chặng duy nhất nếu không có điểm dừng)
            var finalLegControl = new FlightLegControl();
            finalLegControl.SetData(
                ThongTin.MaChuyenBay,
                ThongTin.TenHangBay,
                ThongTin.TenMayBay,
                currentOrigin,
                ThongTin.MaSanBayDen,
                currentOriginName,
                ThongTin.TenSanBayDen,
                currentOriginTime.ToString("HH:mm"),
                ThongTin.NgayGioDen.ToString("HH:mm"),
                currentOriginTime.ToString("dd/MM/yyyy"),
                ThongTin.NgayGioDen.ToString("dd/MM/yyyy"),
                FormatDuration((int)(ThongTin.NgayGioBay.AddMinutes(ThongTin.TongThoiGianHanhTrinh) - currentOriginTime).TotalMinutes),
                ThongTin.Logo,
                (dsTrungGian.Count == 0) ? TimelineNodeType.StartAndEnd : TimelineNodeType.End
            );
            pnlItinerary.Controls.Add(finalLegControl);

        }

        private void frmThongTinChuyenBay_Load(object sender, EventArgs e)
        {
            LoadFlightData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
