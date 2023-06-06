using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;

namespace deepro.BookStore.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string getUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthinticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
