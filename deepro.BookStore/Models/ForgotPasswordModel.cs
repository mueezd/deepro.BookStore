using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name ="Registerd Email Address:")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
