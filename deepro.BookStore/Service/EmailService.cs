using deepro.BookStore.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace deepro.BookStore.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTamplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig;

        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolder("Hello {{UserName}} This is test email subject from book store", userEmailOptions.PlaceHolders);
            userEmailOptions.Body = UpdatePlaceHolder(GetEmailBody("TestEmail"), userEmailOptions.PlaceHolders);

            await SendEmail(userEmailOptions);
        }

        public async Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolder("Hello {{UserName}} Reset tour password", userEmailOptions.PlaceHolders);
            userEmailOptions.Body = UpdatePlaceHolder(GetEmailBody("EmailConfirm"), userEmailOptions.PlaceHolders);

            await SendEmail(userEmailOptions);
        }

        public async Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolder("Hello {{UserName}} Confirm your Email Id", userEmailOptions.PlaceHolders);
            userEmailOptions.Body = UpdatePlaceHolder(GetEmailBody("ForgotPassword"), userEmailOptions.PlaceHolders);

            await SendEmail(userEmailOptions);
        }

        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }
        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mailMessage = new MailMessage()
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mailMessage.To.Add(toEmail);
            }

            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mailMessage.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mailMessage);
        }

        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
        private string UpdatePlaceHolder(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }

            return text;
        }
    }
}
