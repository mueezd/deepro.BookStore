using deepro.BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace deepro.BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SIgnUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task GenerateEmailConfirmationTokenAsync(ApplicationUserModel user);
        Task<ApplicationUserModel> GetUserByEmailAsync(string email);
        Task GenerateForgotPasswordTokenAsync(ApplicationUserModel user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}