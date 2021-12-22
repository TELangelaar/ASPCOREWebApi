using Microsoft.Extensions.Logging;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> _logger;
        private string _mailTo = "admin@mycompany.com";
        private string _mailFrom = "noreply@mycompany.com";

        public LocalMailService(ILogger<LocalMailService> logger)
        {
            _logger = logger;
        }

        public void Send(string subject, string message)
        {
            _logger.LogDebug("Mail from {_mailFrom} to {_mailTo}, using {mailService}.", _mailFrom, _mailTo, GetType().Name);
            _logger.LogDebug("Subject: {subject}", subject);
            _logger.LogDebug("Message: {message}", message);
        }
    }
}
