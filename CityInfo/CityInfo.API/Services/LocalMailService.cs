using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _mailTo;
        private readonly string _mailFrom;

        public LocalMailService(ILogger<LocalMailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _mailTo = _configuration["mailSettings:mailToAddress"];
            _mailFrom = _configuration["mailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            _logger.LogDebug("Mail from {_mailFrom} to {_mailTo}, using {mailService}.", _mailFrom, _mailTo, GetType().Name);
            _logger.LogDebug("Subject: {subject}", subject);
            _logger.LogDebug("Message: {message}", message);
        }
    }
}
