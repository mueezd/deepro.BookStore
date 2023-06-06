using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm New password does not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
