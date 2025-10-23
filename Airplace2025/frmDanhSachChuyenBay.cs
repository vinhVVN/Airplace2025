using Airplace2025.BLL.DAO;
using Airplace2025.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Airplace2025
{
    public partial class frmDanhSachChuyenBay: Form
    {
        public frmDanhSachChuyenBay()
        {
            InitializeComponent();
            InitializeWebView();
        }

        //  là async để đợi WebView2 sẵn sàng
        async void InitializeWebView()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.OpenDevToolsWindow();

            // Lấy đường dẫn tuyệt đối đến file map.html
            // (File này đã được copy vào thư mục build)
            string htmlPath = Path.Combine(Application.StartupPath, "map.html");

            // Điều hướng WebView2 đến file HTML
            webView.CoreWebView2.Navigate("file:///" + htmlPath.Replace("\\", "/"));
        }

        public void LoadFlightData()
        {
     
            try
            {
                DataTable dt = FlightDAO.Instance.GetFlightList();
                dgvFlight.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK);
            }
        }

        public async void DrawRouteOnMap(string startName, string endName)
        {
            if (webView.CoreWebView2 == null) return;
            if (string.IsNullOrWhiteSpace(startName) || string.IsNullOrWhiteSpace(endName))
            {
                return;
            }
            string script = $"findAndDrawRoute('{startName}', '{endName}');";
            await webView.CoreWebView2.ExecuteScriptAsync(script);

        }

        private void frmDanhSachChuyenBay_Load(object sender, EventArgs e)
        {
            LoadFlightData();
        }

        private void dgvFlight_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvFlight.Columns[e.ColumnIndex].Name == "colBook")
            {
                int SoGheTrong = Convert.ToInt32(dgvFlight.Rows[e.RowIndex].Cells["SoGheTrong"].Value);
                if (SoGheTrong == 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(177, 173, 224); ;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(177, 173, 224);
                    e.CellStyle.SelectionForeColor = Color.White;
                    
                }
                else
                {
                    e.CellStyle.BackColor = Color.SlateBlue;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.SlateBlue;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                e.FormattingApplied = true;
            }

            if (dgvFlight.Columns[e.ColumnIndex].Name == "colDetail")
            {
                e.CellStyle.BackColor = Color.SlateBlue;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.SlateBlue;
                e.FormattingApplied = true;
            }

        }

        private void dgvFlight_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dgvFlight_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFlight.CurrentRow == null) return;
            try
            {
                string startName = dgvFlight.CurrentRow.Cells["TenSanBayDi"].Value.ToString();
                string endName = dgvFlight.CurrentRow.Cells["TenSanBayDen"].Value.ToString();
                DrawRouteOnMap(startName, endName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi chọn dòng: " + ex.Message);
            }
        }

        private void dgvFlight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvFlight.Columns["colDetail"].Index)
            {
                string maChuyenBay = dgvFlight.Rows[e.RowIndex].Cells["MaChuyenBay"].Value.ToString();
                frmThongTinChuyenBay frm = new frmThongTinChuyenBay(maChuyenBay);
                frm.ShowDialog();
            }

            if (e.ColumnIndex == dgvFlight.Columns["colBook"].Index)
            {
                int soGheTrong = Convert.ToInt32(dgvFlight.Rows[e.RowIndex].Cells["SoGheTrong"].Value);

                if (soGheTrong > 0)
                {
                    string maChuyenBay = dgvFlight.Rows[e.RowIndex].Cells["MaChuyenBay"].Value.ToString();
                    // Qua form Đặt vé
                    frmDatVe frm = new frmDatVe();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Chuyến bay này đã hết vé.", "Hết vé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
