using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoreTest.Services
{
    public class LoggerMailService : IMailService
    {
        private readonly ILogger<LoggerMailService> _logger;

        public LoggerMailService(ILogger<LoggerMailService> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To:{to} Subject:{subject} Body{body}");
        }
    }
}
