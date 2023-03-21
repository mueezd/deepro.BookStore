using deepro.BookStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class BookModel
    {
        [DataType(DataType.Date)]
        [Display(Name ="Choose Date")]
        public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please Enter Title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter author name")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]
        public int LanguageId { get; set; }

        [Required(ErrorMessage ="Please enter the total pages")]
        public int? TotalPage { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }

    }
}
