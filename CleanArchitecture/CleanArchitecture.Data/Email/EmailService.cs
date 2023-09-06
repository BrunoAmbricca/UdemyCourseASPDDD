using Azure;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace CleanArchitecture.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendMail(Application.Models.Email email)
        {
            var cliente = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridName = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);

            var response = await cliente.SendEmailAsync(sendGridName);

            if(response.StatusCode == HttpStatusCode.Accepted ||
               response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            _logger.LogError("El email no pudo enviarse");

            return false;
        }
    }
}
