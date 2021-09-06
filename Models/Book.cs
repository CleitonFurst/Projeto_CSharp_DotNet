using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string  Nome { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }       
        public string createdById { get; set; }
        public IdentityUser createdBy { get; set; }
        public string updatedById { get; set; }
        public IdentityUser updatedBy { get; set; }
    }
}
