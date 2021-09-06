using books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace books.Data
{
    public class BookContext : IdentityDbContext
    {
        public BookContext(DbContextOptions<BookContext> options) 
            : base(options) { }//construtor da classe context 

        public DbSet<Book> Book { get; set; }
        


    }
}
