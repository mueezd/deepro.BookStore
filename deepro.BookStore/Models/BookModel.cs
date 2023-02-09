using System;
using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please Enter Title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter author name")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage ="Please enter the total pages")]
        public int? TotalPage { get; set; }
        //public DateTime? CreatedOn { get; set; }
        //public DateTime? UpdatedOn { get; set; }

    }
}
