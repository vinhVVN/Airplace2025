using System;

namespace Airplace2025.BLL.DTO
{
    /// <summary>
    /// Data Transfer Object cho thông tin hạng vé
    /// </summary>
    public class HangVeDTO
    {
        public string MaHangVe { get; set; }
        public string TenHangVe { get; set; }
        public decimal TiLeGiaHangVe { get; set; }

        /// <summary>
        /// Format hiển thị cho ComboBox
        /// </summary>
        public override string ToString()
        {
            return TenHangVe;
        }
    }
}

