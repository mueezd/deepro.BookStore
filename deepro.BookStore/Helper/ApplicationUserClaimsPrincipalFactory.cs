using deepro.BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace deepro.BookStore.Helper
{
    public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUserModel, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUserModel> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.FristName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));

            return identity;
        }

    }
}
