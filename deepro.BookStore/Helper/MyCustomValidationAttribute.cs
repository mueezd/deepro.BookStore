using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Helper
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string bookName =value.ToString();
                if (bookName.Contains("mvc"))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "The Book Name does not contain the desired valur");
        }


        


    }
}
