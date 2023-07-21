using MailKit.Net.Smtp;
using MimeKit;

namespace RapidAPIConsume_WEBUI.Models
{
    public class MyMailService
    {
        public void SendMail(string mail)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelAPI Admin", "coreblog@ilkportfolio.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = "Hesabınız başarıyla oluşturuldu\n\nHesabınız için doğrulama kodu: buraya sayı gelecek. App user tablosuna confirm code kolonu ekle!!";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "HotelAPI Hesap Onay Kodu";

            SmtpClient client = new SmtpClient();
            client.Connect("webmail.ilkportfolio.com", 587, false);
            client.Authenticate("coreblog@ilkportfolio.com", "cr798*BK");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
