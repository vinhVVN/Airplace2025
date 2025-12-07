using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.BLL
{
    public static class TicketHelper
    {
        // 1. Hàm bỏ dấu Tiếng Việt (Ví dụ: "Đà Nẵng" -> "Da Nang")
        public static string RemoveSign(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder result = new StringBuilder();

            foreach (char c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }
            // Thay thế Đ/đ
            return result.ToString().Normalize(NormalizationForm.FormC).Replace("Đ", "D").Replace("đ", "d");
        }

        // 2. Hàm dịch Hạng vé sang Tiếng Anh (Dùng Dictionary cho nhanh)
        private static readonly Dictionary<string, string> _ticketClassMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Phổ thông", "Economy" },
            { "Thương gia", "Business" },
            { "Phổ thông đặc biệt", "Premium Eco" },
            { "Hạng nhất", "First Class" }
        };

        public static string TranslateTicketClass(string vietnameseClass)
        {
            if (_ticketClassMap.ContainsKey(vietnameseClass))
                return _ticketClassMap[vietnameseClass];
            return vietnameseClass; // Nếu không tìm thấy thì giữ nguyên
        }

        // 3. Hàm định dạng thời gian bay (phút -> giờ phút)
        public static string FormatDuration(int minutes)
        {
            int h = minutes / 60;
            int m = minutes % 60;
            return $"{h}h {m}m";
        }
    }
}
