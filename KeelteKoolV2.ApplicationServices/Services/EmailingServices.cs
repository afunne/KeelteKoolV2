using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace KeelteKoolV2.ApplicationServices.Services
{
    public class EmailingServices : IEmailingServices
    {
        private readonly IConfiguration _config;

        public EmailingServices
            (
                IConfiguration config
            )
        {
            _config = config;
        }

        public void SendEmail(EmailDTO dto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body
            };

            //failide lisamine
            foreach (var file in dto.Attachment)
            {
                if (file.Length > 0 && file.Length < 10485760) //10MB
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        ms.Position = 0;
                        builder.Attachments.Add(file.FileName, ms.ToArray());
                    }
                }
            }
            email.Body = builder.ToMessageBody();

            Send(email);
        }

        public void SendEmailToken(EmailTokenDTO dto, string token)
        {
            dto.Token = token;
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body,
            };
            email.Body = builder.ToMessageBody();

            Send(email);
        }

        //SMTP ühendus, kasutajanimi ja parool tulevad konfiguratsioonist (user-secrets)
        private void Send(MimeMessage email)
        {
            using var smtp = new SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
