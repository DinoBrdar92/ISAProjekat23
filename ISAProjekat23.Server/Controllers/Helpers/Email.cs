using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using QRCoder;
using System.Drawing;
using System.Text;

namespace ISAProjekat23.Server.Controllers.Helpers
{
    public static class Email
    {
        public static async Task SendVerificationEmail(string title, string body, string receipmentMail)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("andy.mock42@gmail.com", "taiwlvvbvibkncga");       //drugi parametar je password

            using var smtpMessage = new MimeMessage();
            smtpMessage.From.Add(new MailboxAddress("Andy from MESS", "andy.mock42@gmail.com"));

            smtpMessage.To.Add(new MailboxAddress("", receipmentMail));

            smtpMessage.Subject = title;

            using (var multiPart = new Multipart("mixed"))
            {
                var textPart = new TextPart(TextFormat.Html)
                {
                    Text = body,
                    ContentTransferEncoding = ContentEncoding.Base64
                };

                multiPart.Add(textPart);
                smtpMessage.Body = multiPart;
                await client.SendAsync(smtpMessage);
            }
        }

        public static async Task SendQRCodeEmail(string title, string body, string receipmentMail)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("andy.mock42@gmail.com", "taiwlvvbvibkncga");       //drugi parametar je password

            using var smtpMessage = new MimeMessage();
            smtpMessage.From.Add(new MailboxAddress("Andy from MESS", "andy.mock42@gmail.com"));

            smtpMessage.To.Add(new MailboxAddress("", receipmentMail));

            smtpMessage.Subject = title;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Encoding.ASCII.GetBytes("The text which should be encoded."), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            string result;

            using (var stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                result = Convert.ToBase64String(stream.ToArray());
            }


            var image = $"<p>Scan this QR code for joy<p><img style='width:100px' src='data:image/png;base64,{result}' />";

            using (var multiPart = new Multipart("mixed"))
            {
                var textPart = new TextPart(TextFormat.Html)
                {
                    Text = image,
                    ContentTransferEncoding = ContentEncoding.Base64
                };

                multiPart.Add(textPart);
                smtpMessage.Body = multiPart;
                await client.SendAsync(smtpMessage);
            }
        }
    }
}
