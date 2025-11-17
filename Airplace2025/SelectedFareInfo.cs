using System;
using Airplace2025.BLL.DTO;

namespace Airplace2025
{
    public class SelectedFareInfo
    {
        public SelectedFareInfo(ChuyenBayDTO flight, string cabinClass, decimal price)
        {
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            CabinClass = cabinClass ?? "Phổ thông";
            FarePrice = price;
        }

        public ChuyenBayDTO Flight { get; }
        public string CabinClass { get; }
        public decimal FarePrice { get; }
    }

    public class SelectedFareEventArgs : EventArgs
    {
        public SelectedFareEventArgs(SelectedFareInfo fareInfo)
        {
            FareInfo = fareInfo;
        }

        public SelectedFareInfo FareInfo { get; }
    }
}

