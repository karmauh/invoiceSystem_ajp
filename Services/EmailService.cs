using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace InvoiceSystem.Services
{
    public static class EmailService
    {
        public static void SendCode(string toEmail, string code)
        {
            string fromEmail = ConfigurationManager.AppSettings["SmtpEmail"];
            string password = ConfigurationManager.AppSettings["SmtpPassword"];
            string host = ConfigurationManager.AppSettings["SmtpHost"];
            int port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(fromEmail, "Invoice System");
                message.To.Add(toEmail);
                message.Subject = "Kod weryfikacyjny logowania";
                message.SubjectEncoding = Encoding.UTF8;

                message.Body = $@"
<html>
<head><meta charset='UTF-8'></head>
<body style='font-family: Arial;'>
<h2>Logowanie do systemu</h2>
<p>Twój jednorazowy kod weryfikacyjny:</p>
<p style='font-size:20px; font-weight:bold;'>{code}</p>
<p>Kod jest ważny przez 5 minut.</p>
</body>
</html>";

                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(fromEmail, password);
                    client.Send(message);
                }
            }
        }
    }
}
