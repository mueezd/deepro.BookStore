using System;
using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class SIgnUpUserModel
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "please enter your email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password Dosenot match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
