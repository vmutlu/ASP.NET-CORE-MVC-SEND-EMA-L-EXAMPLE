using System.Net;
using System.Net.Mail;

namespace ExampleEmail.Models
{
    public static class Mail
    {
        public static void SendMail(string body)
        {
            var from = new MailAddress("Mail adresiniz", "Deneme");
            var response = new MailAddress("Kime Mail Atılacağı Bilgisi");
            const string submit = "Konu";
            using (var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port=587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from.Address, "from'a yazılan epostanın şifresi") //froma yazılan email, response değişkenine atanan email adresine formdan alınan bilgileri mail atar
            })
            {
                using (var message = new MailMessage(from, response) { Subject = submit, Body = body })
                {
                    smtpClient.Send(message);
                }
            }
        }
    }
}
