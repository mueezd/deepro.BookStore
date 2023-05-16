using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace deepro.BookStore.Data
{
    public class language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Books> books { get; set; }
    }
}
