using Microsoft.AspNetCore.Identity;
using System;

namespace deepro.BookStore.Models
{
    public class ApplicationUserModel: IdentityUser
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
