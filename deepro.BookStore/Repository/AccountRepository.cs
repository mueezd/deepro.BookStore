using deepro.BookStore.Models;
using deepro.BookStore.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace deepro.BookStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUserModel> userManager, 
            SignInManager<ApplicationUserModel> signInManager,
            IUserService userService, 
            IEmailService emailService,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<ApplicationUserModel> GetUserByEmailAsync(string email)
        {
            
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> CreateUserAsync(SIgnUpUserModel userModel)
        {
            var user = new ApplicationUserModel()
            {
                Email= userModel.Email,
                UserName = userModel.Email,
                FristName = userModel.FirstName,
                LastName= userModel.LastName,
                DateOfBirth= userModel.DateOfBirth
            };
            
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await GenerateEmailConfirmationTokenAsync(user);
                }
            }
            return result;
        }
        public async Task GenerateEmailConfirmationTokenAsync(ApplicationUserModel user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }

        public async Task GenerateForgotPasswordTokenAsync(ApplicationUserModel user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password,
                signInModel.RememberMe, true);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.getUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }


        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
           return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }

        private async Task SendEmailConfirmationEmail(ApplicationUserModel user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string>()
                {
                     user.Email
                },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                   new KeyValuePair<string, string>("{{UserName}}", user.FristName),
                   new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token)),

                }
            };
            await _emailService.SendEmailForEmailConfirmation(options);
        }

        private async Task SendForgotPasswordEmail(ApplicationUserModel user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ResetPassword").Value;

            UserEmailOptions options = new UserEmailOptions()
            {
                ToEmails = new List<string>()
                {
                     user.Email
                },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                   new KeyValuePair<string, string>("{{UserName}}", user.FristName),
                   new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token)),

                }
            };
            await _emailService.SendEmailForForgotPassword(options);
        }
    }
}
