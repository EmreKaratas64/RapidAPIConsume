using MailKit.Net.Smtp;
using MimeKit;

namespace RapidAPIConsume_WEBUI.Models
{
    public class MyMailService
    {
        public void SendMail(string mail, string title, string content)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelAPI Admin", "coreblog@ilkportfolio.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = title;

            SmtpClient client = new SmtpClient();
            client.Connect("webmail.ilkportfolio.com", 587, false);
            client.Authenticate("coreblog@ilkportfolio.com", "cr798*BK");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
