using Contracts.Emails;

namespace Application.Core.Abstractions.Email;

/// <summary>
/// Represents the email service interface.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends the email with the content based on the specified email request.
    /// </summary>
    /// <param name="mailRequest">The mail request.</param>
    /// <returns>The completed task.</returns>
    Task SendEmailAsync(MailRequest mailRequest);
}
