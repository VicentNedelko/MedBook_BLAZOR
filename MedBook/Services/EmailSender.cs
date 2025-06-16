using DAL.Data;
using Microsoft.AspNetCore.Identity;

namespace MedBook.Services
{
    public class EmailSender(EmailManager emailManager) : IEmailSender<ApplicationUser>
    {
        private readonly EmailManager emailManager = emailManager;

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            emailManager.SendMailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
            emailManager.SendMailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            emailManager.SendMailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
    }
}
