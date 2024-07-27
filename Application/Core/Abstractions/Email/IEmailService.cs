namespace Application.Core.Abstractions.Email;

public interface IEmailService
{
    Task SendEmailAsync(string from, string to, string message);
}
