using ApplicationLayer.Config;
using ApplicationLayer.Interface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class MailService : IMailService
    {
        private readonly MailConfig _mailSetting;

        public MailService(IOptions<MailConfig> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        public void SendEmail(string ToEmail , string Subject , string Body)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSetting.Mail);
            email.To.Add(MailboxAddress.Parse(ToEmail));
            email.Subject = Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSetting.Host, _mailSetting.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSetting.Mail, _mailSetting.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
