﻿using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TextStory.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713

    
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
    public class AuthMessageSender: IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }  // set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(Options.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("michael.weeder@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Your Account SID from twilio.com/console
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
              to: new PhoneNumber(number),
              from: new PhoneNumber(Options.SMSAccountFrom),
              body: message);
        }
    }
}
