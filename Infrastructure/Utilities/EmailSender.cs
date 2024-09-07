using Microsoft.AspNetCore.Identity.UI.Services;

namespace Infrastructure.Utilities;

public class EmailSender :IEmailSender
{
    public  Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //just dont send mail and ignore email sender's error
        return Task.CompletedTask;
    }
}