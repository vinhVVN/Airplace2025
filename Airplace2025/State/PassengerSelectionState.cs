using System;

namespace Airplace2025.State
{
    internal static class PassengerSelectionState
    {
        // Constraints aligned with frmDatVe
        private const int ADULT_MIN = 1;
        private const int ADULT_MAX = 9;
        private const int CHILD_MIN = 0;
        private const int CHILD_MAX = 8;
        private const int INFANT_MIN = 0;
        private const int TOTAL_PASSENGER_MAX = 9;

        public static int Adult { get; private set; } = ADULT_MIN;
        public static int Child { get; private set; } = CHILD_MIN;
        public static int Infant { get; private set; } = INFANT_MIN;

        public static int Total => Adult + Child + Infant;

        public static void SetAdult(int value)
        {
            value = Math.Max(ADULT_MIN, Math.Min(ADULT_MAX, value));

            // Ensure Adult + Child ≤ 9
            if (value + Child > TOTAL_PASSENGER_MAX)
            {
                Child = TOTAL_PASSENGER_MAX - value;
            }

            // Ensure Infant ≤ Adult
            if (Infant > value)
            {
                Infant = value;
            }

            Adult = value;
        }

        public static void SetChild(int value)
        {
            value = Math.Max(CHILD_MIN, Math.Min(CHILD_MAX, value));

            // Ensure Adult + Child ≤ 9
            int maxChild = TOTAL_PASSENGER_MAX - Adult;
            if (value > maxChild) value = maxChild;

            Child = value;
        }

        public static void SetInfant(int value)
        {
            value = Math.Max(INFANT_MIN, value);

            // Ensure Infant ≤ Adult
            if (value > Adult) value = Adult;

            Infant = value;
        }
    }
}


