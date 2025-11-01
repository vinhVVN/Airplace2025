using Airplace2025.State; // for PassengerSelectionState
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Airplace2025
{
    public partial class frmSoLuongKhachHang : Form
    {
        private const int ADULT_MIN = 1;
        private const int ADULT_MAX = 9;
        private const int CHILD_MIN = 0;
        private const int CHILD_MAX = 8;
        private const int INFANT_MIN = 0;
        private const int TOTAL_PASSENGER_MAX = 9;
        public frmSoLuongKhachHang()
        {
            InitializeComponent();
            // Wire events that are not set in Designer
            this.Load += FrmSoLuongKhachHang_Load;
        }

        private void FrmSoLuongKhachHang_Load(object sender, EventArgs e)
        {
            // Initialize labels from shared state
            lblTotalAdult.Text = PassengerSelectionStateTemp.Adult.ToString();
            lblTotalChild.Text = PassengerSelectionStateTemp.Child.ToString();
            lblTotalInfant.Text = PassengerSelectionStateTemp.Infant.ToString();

            UpdateAllButtons();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // State already updated on each click; just close
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ============ ADULT ============
        private void SetAdultCount(int value)
        {
            // Clamp adult
            if (value < ADULT_MIN) value = ADULT_MIN;
            if (value > ADULT_MAX) value = ADULT_MAX;

            int currentChild = GetChildCount();
            int currentInfant = GetInfantCount();

            // Đảm bảo Adult + Child ≤ 9
            if (value + currentChild > TOTAL_PASSENGER_MAX)
            {
                currentChild = TOTAL_PASSENGER_MAX - value;
                SetChildCount(currentChild);
            }

            // Đảm bảo Infant ≤ Adult (em bé không thể nhiều hơn người lớn)
            if (currentInfant > value)
            {
                SetInfantCount(value);
            }

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalAdult.Text != normalized)
                lblTotalAdult.Text = normalized;

            UpdateAdultButtons();
        }

        private void UpdateAdultButtons()
        {
            int adult = GetAdultCount();
            int child = GetChildCount();

            btnMinusAdult.Enabled = adult > ADULT_MIN;
            btnPlusAdult.Enabled = adult < ADULT_MAX && (adult + child) < TOTAL_PASSENGER_MAX;

            btnMinusAdult.Invalidate();
            btnPlusAdult.Invalidate();
        }

        private int GetAdultCount()
        {
            return int.TryParse(lblTotalAdult.Text, out int v) ? v : ADULT_MIN;
        }

        private void btnPlusAdult_Click(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount() + 1);
            PassengerSelectionStateTemp.SetAdult(GetAdultCount() + 1);
            UpdateAllButtons();
        }

        private void btnMinusAdult_Click(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount() - 1);
            PassengerSelectionStateTemp.SetAdult(GetAdultCount() - 1);
            UpdateAllButtons();
        }

        private void lblTotalAdult_TextChanged(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount());
        }

        // ============ CHILD ============
        private void SetChildCount(int value)
        {
            int currentAdult = GetAdultCount();

            // Clamp child
            if (value < CHILD_MIN) value = CHILD_MIN;
            if (value > CHILD_MAX) value = CHILD_MAX;

            // Đảm bảo Adult + Child ≤ 9
            int maxChild = TOTAL_PASSENGER_MAX - currentAdult;
            if (value > maxChild) value = maxChild;

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalChild.Text != normalized)
                lblTotalChild.Text = normalized;

            UpdateChildButtons();
        }

        private void UpdateChildButtons()
        {
            int adult = GetAdultCount();
            int child = GetChildCount();

            btnMinusChild.Enabled = child > CHILD_MIN;
            btnPlusChild.Enabled = child < CHILD_MAX && (adult + child) < TOTAL_PASSENGER_MAX;

            btnMinusChild.Invalidate();
            btnPlusChild.Invalidate();
        }

        private int GetChildCount()
        {
            return int.TryParse(lblTotalChild.Text, out int v) ? v : CHILD_MIN;
        }

        private void btnPlusChild_Click(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount() + 1);
            PassengerSelectionStateTemp.SetChild(GetChildCount());
            UpdateAllButtons();
        }

        private void btnMinusChild_Click(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount() - 1);
            PassengerSelectionStateTemp.SetChild(GetChildCount());
            UpdateAllButtons();
        }

        private void lblTotalChild_TextChanged(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount());
        }

        // ============ INFANT ============
        private void SetInfantCount(int value)
        {
            int currentAdult = GetAdultCount();

            // Clamp infant
            if (value < INFANT_MIN) value = INFANT_MIN;

            // Infant không được vượt quá số người lớn
            if (value > currentAdult) value = currentAdult;

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalInfant.Text != normalized)
                lblTotalInfant.Text = normalized;

            UpdateInfantButtons();
        }

        private void UpdateInfantButtons()
        {
            int adult = GetAdultCount();
            int infant = GetInfantCount();

            btnMinusInfant.Enabled = infant > INFANT_MIN;
            btnPlusInfant.Enabled = infant < adult; // Em bé phải ít hơn hoặc bằng người lớn

            btnMinusInfant.Invalidate();
            btnPlusInfant.Invalidate();
        }

        private int GetInfantCount()
        {
            return int.TryParse(lblTotalInfant.Text, out int v) ? v : INFANT_MIN;
        }

        private void btnPlusInfant_Click(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount() + 1);
            PassengerSelectionStateTemp.SetInfant(GetInfantCount());
            UpdateAllButtons();
        }

        private void btnMinusInfant_Click(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount() - 1);
            PassengerSelectionStateTemp.SetInfant(GetInfantCount());
            UpdateAllButtons();
        }

        private void lblTotalInfant_TextChanged(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount());
        }

        // ============ UPDATE ALL ============
        private void UpdateAllButtons()
        {
            UpdateAdultButtons();
            UpdateChildButtons();
            UpdateInfantButtons();
            int currentAdult = GetAdultCount();
            int currentInfant = GetInfantCount();
            int currentChild = GetChildCount();
        }
    }
}
