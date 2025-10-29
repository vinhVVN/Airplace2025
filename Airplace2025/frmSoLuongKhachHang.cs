using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.State; // for PassengerSelectionState

namespace Airplace2025
{
    public partial class frmSoLuongKhachHang : Form
    {
        public frmSoLuongKhachHang()
        {
            InitializeComponent();
            // Wire events that are not set in Designer
            this.Load += FrmSoLuongKhachHang_Load;
            btnPlusAdult.Click += BtnPlusAdult_Click;
            btnMinusAdult.Click += BtnMinusAdult_Click;
            btnPlusChild.Click += BtnPlusChild_Click;
            btnMinusChild.Click += BtnMinusChild_Click;
            btnPlusInfant.Click += BtnPlusInfant_Click;
            btnMinusInfant.Click += BtnMinusInfant_Click;
            btnConfirm.Click += BtnConfirm_Click;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSoLuongKhachHang_Load(object sender, EventArgs e)
        {
            // Initialize labels from shared state
            lblTotalAdult.Text = PassengerSelectionState.Adult.ToString();
            lblTotalChild.Text = PassengerSelectionState.Child.ToString();
            lblTotalInfant.Text = PassengerSelectionState.Infant.ToString();

            UpdateAllButtons();
        }

        private void BtnPlusAdult_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionState.Adult + 1);
            SyncLabelsFromState();
        }

        private void BtnMinusAdult_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionState.Adult - 1);
            SyncLabelsFromState();
        }

        private void BtnPlusChild_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetChild(PassengerSelectionState.Child + 1);
            SyncLabelsFromState();
        }

        private void BtnMinusChild_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetChild(PassengerSelectionState.Child - 1);
            SyncLabelsFromState();
        }

        private void BtnPlusInfant_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetInfant(PassengerSelectionState.Infant + 1);
            SyncLabelsFromState();
        }

        private void BtnMinusInfant_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetInfant(PassengerSelectionState.Infant - 1);
            SyncLabelsFromState();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // State already updated on each click; just close
            this.Close();
        }

        private void SyncLabelsFromState()
        {
            lblTotalAdult.Text = PassengerSelectionState.Adult.ToString();
            lblTotalChild.Text = PassengerSelectionState.Child.ToString();
            lblTotalInfant.Text = PassengerSelectionState.Infant.ToString();
            UpdateAllButtons();
        }

        private void UpdateAllButtons()
        {
            int adult = PassengerSelectionState.Adult;
            int child = PassengerSelectionState.Child;
            int infant = PassengerSelectionState.Infant;

            // Adult buttons
            btnMinusAdult.Enabled = adult > 1;
            btnPlusAdult.Enabled = adult < 9 && (adult + child) < 9;

            // Child buttons
            btnMinusChild.Enabled = child > 0;
            btnPlusChild.Enabled = child < 8 && (adult + child) < 9;

            // Infant buttons
            btnMinusInfant.Enabled = infant > 0;
            btnPlusInfant.Enabled = infant < adult;
        }
    }
}
