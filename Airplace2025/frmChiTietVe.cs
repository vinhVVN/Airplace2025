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
    public partial class frmChiTietVe : Form
    {
        public frmChiTietVe()
        {
            InitializeComponent();
        }

        public void SetClassType(string classType)
        {
            switch (classType)
            {
                case "Economy":
                    // Giữ nguyên giá trị mặc định (Phổ Thông)
                    commonButton.Text = "Phổ Thông";
                    lblPriceChange.Text = "Phí đổi vé tối đa 860.000 VND mỗi hành khách";
                    lblPriceRefund.Text = "Phí hoàn vé tối đa 860.000 VND mỗi hành khách";
                    lblCheckedBaggage.Text = "1 x 23 kg";
                    lblHandLuggage.Text = "✓ Không quá 10kg";
                    break;
                case "Premium":
                    commonButton.Text = "Phổ Thông Đặc Biệt";
                    lblPriceChange.Text = "Được phép";
                    lblPriceRefund.Text = "Phí hoàn vé tối đa 500.000 VND mỗi hành khách";
                    lblCheckedBaggage.Text = "1 x 32 kg";
                    lblHandLuggage.Text = "✓ Không quá 10kg";
                    break;
                case "Business":
                    commonButton.Text = "Thương Gia";
                    lblPriceChange.Text = "Phí đổi vé tối đa 860.000 VND mỗi hành khách";
                    lblPriceRefund.Text = "Phí hoàn vé tối đa 1.000.000 VND mỗi hành khách";
                    lblCheckedBaggage.Text = "1 x 32 kg";
                    lblHandLuggage.Text = "✓ Không quá 18kg";
                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contentTable_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void closeBottomButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            frmShoppingCart frmShoppingCart = new frmShoppingCart();
            frmShoppingCart.Show();
        }
    }
}
