namespace Application.Core.Abstractions.Notifications;

/// <summary>
/// Represents the email notification service interface.
/// </summary>
public interface IEmailNotificationService
{ 
    Task SendWelcomeEmail();
}
