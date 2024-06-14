namespace SCORE.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string Email, string subject, string content);
    }
}

