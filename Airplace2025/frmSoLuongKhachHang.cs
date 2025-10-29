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
        }

        private void FrmSoLuongKhachHang_Load(object sender, EventArgs e)
        {
            // Initialize labels from shared state
            lblTotalAdult.Text = PassengerSelectionState.Adult.ToString();
            lblTotalChild.Text = PassengerSelectionState.Child.ToString();
            lblTotalInfant.Text = PassengerSelectionState.Infant.ToString();

            UpdateAllButtons();
        }

        private void btnPlusAdult_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionState.Adult + 1);
            SyncLabelsFromState();
        }

        private void btnMinusAdult_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionState.Adult - 1);
            SyncLabelsFromState();
        }

        private void btnPlusChild_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetChild(PassengerSelectionState.Child + 1);
            SyncLabelsFromState();
        }

        private void btnMinusChild_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetChild(PassengerSelectionState.Child - 1);
            SyncLabelsFromState();
        }

        private void btnPlusInfant_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetInfant(PassengerSelectionState.Infant + 1);
            SyncLabelsFromState();
        }

        private void btnMinusInfant_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetInfant(PassengerSelectionState.Infant - 1);
            SyncLabelsFromState();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
