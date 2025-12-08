using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

public static class TicketRenderer
{
    public static Bitmap RenderTicket(Form veForm)
    {
        // Tăng độ phân giải lên để nét
        Bitmap bmp = new Bitmap(veForm.Width, veForm.Height);
        bmp.SetResolution(300, 300);

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Vẽ nền
            using (Brush b = new SolidBrush(veForm.BackColor))
            {
                g.FillRectangle(b, 0, 0, veForm.Width, veForm.Height);
            }

            // Vẽ control (Duyệt ngược để đúng thứ tự đè)
            for (int i = veForm.Controls.Count - 1; i >= 0; i--)
            {
                DrawControl(g, veForm.Controls[i], Point.Empty);
            }
        }
        return bmp;
    }

    private static void DrawControl(Graphics g, Control c, Point parentPos)
    {
        // QUAN TRỌNG: Nếu form chưa hiện, c.Visible sẽ trả về false.
        // Ta bỏ qua check Visible ở đây hoặc đảm bảo form cha đã Show().
        if (!c.Visible) return;

        Point currentPos = new Point(parentPos.X + c.Left, parentPos.Y + c.Top);
        Rectangle bounds = new Rectangle(currentPos.X, currentPos.Y, c.Width, c.Height);

        // 1. Vẽ Panel (Nền màu)
        if (c is Panel || c is Guna2Panel)
        {
            Color fillColor = c.BackColor;
            if (c is Guna2Panel gp) fillColor = gp.FillColor;

            if (fillColor != Color.Transparent)
            {
                using (Brush b = new SolidBrush(fillColor)) g.FillRectangle(b, bounds);
            }
        }

        // 2. Vẽ TextBox / Label (Chữ)
        if (c is Guna2TextBox || c is Label || c is TextBox)
        {
            // Lấy thuộc tính chuẩn
            string text = c.Text;
            Font font = c.Font;
            Color foreColor = c.ForeColor;
            HorizontalAlignment hAlign = HorizontalAlignment.Left;
            bool isMultiline = false;

            if (c is Guna2TextBox gt)
            {
                if (gt.FillColor != Color.Transparent)
                {
                    using (Brush b = new SolidBrush(gt.FillColor)) g.FillRectangle(b, bounds);
                }
                hAlign = gt.TextAlign;
                isMultiline = gt.Multiline;
            }
            else if (c is TextBox t)
            {
                hAlign = t.TextAlign;
                isMultiline = t.Multiline;
            }

            // Vẽ chữ
            if (!string.IsNullOrEmpty(text))
            {
                // Ép màu chữ đen nếu nền trắng để tránh in ra giấy trắng chữ trắng
                if (foreColor.R > 240 && foreColor.G > 240 && foreColor.B > 240) foreColor = Color.Black;

                DrawText(g, text, font, foreColor, bounds, hAlign, isMultiline);
            }
        }

        // 3. Vẽ Ảnh (Logo)
        if (c is PictureBox pb && pb.Image != null)
        {
            Rectangle imgRect = GetImageRectangle(pb.Image, bounds, pb.SizeMode);
            g.DrawImage(pb.Image, imgRect);
        }
        else if (c is Guna2PictureBox gpb && gpb.Image != null)
        {
            Rectangle imgRect = GetImageRectangle(gpb.Image, bounds, gpb.SizeMode);
            g.DrawImage(gpb.Image, imgRect);
        }

        // 4. Vẽ Đường kẻ (Separator)
        if (c is Guna2Separator sep)
        {
            using (Pen pen = new Pen(sep.FillColor, sep.FillThickness))
            {
                int y = currentPos.Y + (c.Height / 2);
                g.DrawLine(pen, currentPos.X, y, currentPos.X + c.Width, y);
            }
        }

        // Đệ quy vẽ con bên trong (cho Panel)
        if (c.HasChildren)
        {
            for (int i = c.Controls.Count - 1; i >= 0; i--)
            {
                DrawControl(g, c.Controls[i], currentPos);
            }
        }
    }

    private static void DrawText(Graphics g, string text, Font font, Color color, Rectangle bounds, HorizontalAlignment align, bool isMultiline)
    {
        Rectangle textBounds = bounds;
        textBounds.Inflate(-5, 0); // Padding trái phải 5px

        StringFormat sf = new StringFormat();

        // Căn dọc: Nếu Multiline -> Căn trên (Top), Ngược lại -> Căn giữa (Center)
        sf.LineAlignment = isMultiline ? StringAlignment.Near : StringAlignment.Center;

        // Căn ngang
        switch (align)
        {
            case HorizontalAlignment.Center: sf.Alignment = StringAlignment.Center; break;
            case HorizontalAlignment.Right: sf.Alignment = StringAlignment.Far; break;
            case HorizontalAlignment.Left: default: sf.Alignment = StringAlignment.Near; break;
        }

        using (Brush b = new SolidBrush(color))
        {
            g.DrawString(text, font, b, textBounds, sf);
        }
    }

    private static Rectangle GetImageRectangle(Image img, Rectangle container, PictureBoxSizeMode mode)
    {
        if (mode == PictureBoxSizeMode.Zoom)
        {
            float ratio = Math.Min((float)container.Width / img.Width, (float)container.Height / img.Height);
            int w = (int)(img.Width * ratio);
            int h = (int)(img.Height * ratio);
            return new Rectangle(container.X + (container.Width - w) / 2, container.Y + (container.Height - h) / 2, w, h);
        }
        return container;
    }
}