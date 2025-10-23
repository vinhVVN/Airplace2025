using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.Controls
{
    public enum TimelineNodeType // Xác định loại nút sẽ được vẽ trên timeline
    {
        // Chỉ vẽ đường chấm, không có chấm tròn
        None,
        // Chấm vàng, đặc (Điển khởi hành)
        Start,
        // Chấm đỏ, rỗng (Điểm dừng)
        Stop,
        // Chấm vàng, đặc (Điểm đích)
        End,
        // Chấm vàng cho cả trên và dưới (với chuyến bay thẳng)
        StartAndEnd
    }
}
