using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SCORE.Controllers
{
    public class EmailTestController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<EmailTestController> _logger;

        public EmailTestController(IEmailSender emailSender, ILogger<EmailTestController> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task<IActionResult> SendTestEmail()
        {
            _logger.LogInformation("Sending test email...");
            try
            {
                await _emailSender.SendEmailAsync("kikana1717@gmail.com", "Test Email", "This is a test email from the SCORE application.");
                _logger.LogInformation("Email sent successfully!");
                return Content("Email sent successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email: {ex.Message}");
                return Content($"Error sending email: {ex.Message}");
            }
        }
    }
}
