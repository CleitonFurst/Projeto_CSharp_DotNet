using books.Models;

using System.Collections.Generic;


namespace books.Services
{
    public interface IBooksService
    {
        List<Book> All();
        Book Get(int? id);
        bool Create(Book b);
        bool Update(Book b);
        bool Delete(int? id);
        List<Book> BooksByUserRole(string role);
       
    }
}
