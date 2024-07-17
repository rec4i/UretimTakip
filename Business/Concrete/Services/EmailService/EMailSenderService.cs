using Business.Abstract.EmailService;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Authentication;

namespace Business.Concrate.EmailService
{
    public class EMailSenderService : IEMailSenderService
    {
        private readonly EmailConfiguration _emailConfig;
        public EMailSenderService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmailRegister(Message message)
        {
            var emailMessage = CreateEmailMessageRegister(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessageRegister(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Nagis Informatics", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<div style='height:auto; width:95%;border:solid;background-color:white;border-width:1px;border-radius:5px;'><div style='border-bottom:solid;border-width:1px;text-align:center;'>" +
                                     "<h2 style='padding:8px;'>Nagis Informatics Membership Information</h2></div><div style='padding:15px;'><h3>Hello;</h3><p>Your Nagis informatics user registration process has been completed successfully. " +
                                     "Your membership information is listed below.<br>{0}</p>", message.Content)
            };
            return emailMessage;
        }


        public void SendEmailForgotPassword(Message message)
        {
            var emailMessage = CreateEmailMessageForgotPassword(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessageForgotPassword(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Nagis Informatics", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<div style='height:auto; width:95%;border:solid;background-color:white;border-width:1px;border-radius:5px;'><div style='border-bottom:solid;border-width:1px;text-align:center;'>" +
                                     "<h2 style='padding:8px;'>Confirming Nagis Informatics email address</h2></div><div style='padding:15px;'><h3>Hello;</h3><p>Before you can use your account on Nagis Informatics, you must confirm your e-mail address. You can confirm your e-mail by clicking the link below.</p>" +
                                     "<a href='{0}'>{0}</a>", message.Content)
            };
            return emailMessage;
        }


        public void SendContact(Message message)
        {
            var emailMessage = CreateEmailContact(message);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailContact(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Nagis Informatics", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<div style='height:auto; width:95%;border:solid;background-color:white;border-width:1px;border-radius:5px;'><div style='border-bottom:solid;border-width:1px;text-align:center;'>" +
                                     "<h2 style='padding:8px;'>Nagis Informatics Conctac Email</h2></div><div style='padding:15px;'>{0}", message.Content)
            };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {

            using (var client = new SmtpClient())
            {
                client.SslProtocols = SslProtocols.Tls12;
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
