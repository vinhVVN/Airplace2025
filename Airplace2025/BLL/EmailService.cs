using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.BLL
{
    public class EmailService
    {
        private const string SENDER_EMAIL = "duongminhduy1592005@gmail.com";
        private const string SENDER_PASSWORD = "zgsj fcsj dshe afmc";

        // Hàm gửi mail nâng cao: Nhận vào nội dung HTML và danh sách ảnh cần nhúng
        public static bool SendMailWithImages(string toEmail, string subject, string htmlBody, Dictionary<string, Stream> images)
        {
            try
            {
                if (string.IsNullOrEmpty(toEmail)) return false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SENDER_EMAIL, "Đại Lý Bán Vé Máy Bay Anh Ba");
                mail.To.Add(toEmail);
                mail.Subject = subject;

                // 1. Tạo AlternateView cho nội dung HTML
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.UTF8, MediaTypeNames.Text.Html);

                // 2. Nhúng hình ảnh vào HTML (Linked Resources)
                if (images != null)
                {
                    foreach (var img in images)
                    {
                        // img.Key là ContentId (ví dụ: "AgencyLogo"), img.Value là Stream ảnh
                        if (img.Value != null)
                        {
                            img.Value.Position = 0; // Reset stream về đầu
                            LinkedResource resource = new LinkedResource(img.Value, "image/png"); // Giả định là png/jpg
                            resource.ContentId = img.Key; // Quan trọng: ID này phải khớp với src="cid:..." trong HTML
                            resource.TransferEncoding = TransferEncoding.Base64;

                            htmlView.LinkedResources.Add(resource);
                        }
                    }
                }

                mail.AlternateViews.Add(htmlView);

                // 3. Cấu hình SMTP
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
