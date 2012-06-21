using System;
using System.Collections.Generic;
using System.Text;
using PoPs.Infrasctructure.Email;
using PoPs.Domain;
using System.Net.Mail;
using System.Net;

namespace PoPs.Infrasctructure
{
    public class EmailSender : IEmailSender
    {
        EmailSettings emailSettings;

        public EmailSender(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void SendNewPassword(string email, string newPassword)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                     = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder();
                body.AppendLine(string.Format("Sua nova senha é: {0}", newPassword));

                MailMessage mailMessage = new MailMessage(
                                 emailSettings.MailFromAddress,   // From 
                                 email,     // To 
                                 "[PoPs] Recuperar Senha",          // Subject
                                 body.ToString());                // Body 
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}
