using Anno.EngineData;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anno.Plugs.SerialRuleService
{
    public class MailModule : BaseModule
    {
        string uid = "Anno6295@163.com", pwd = "Anno62958", smtp = "smtp.163.com";
        public ActionResult MimeMessage(string toName, string toAddrMail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MonitoringSystem", uid));
            message.To.Add(new MailboxAddress(toName, toAddrMail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(smtp, 25, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(uid, pwd);

                client.Send(message);
                client.Disconnect(true);
            }
            return new ActionResult(true);
        }
    }
}
