using deepro.BookStore.Enums;
using deepro.BookStore.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace deepro.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please Enter Title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter author name")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage ="Please enter the total pages")]
        public int? TotalPage { get; set; }
        [Display(Name = "Choose the cover photo of the book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the cover photo of the book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallary { get; set; }

        [Display(Name = "Upload your Book in PDF format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
