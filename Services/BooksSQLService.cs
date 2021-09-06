using books.Data;
using books.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace books.Services
{
    public class BooksSQLService : IBooksService
    {
        BookContext _context;
        public BooksSQLService(BookContext context)
        {
            _context = context;
        }
        public List<Book> All()
        {
            return _context.Book.ToList();//retorna uma lista com todos os registros 
        }

        public List<Book> BooksByUserRole(string getRole)// função que que retorna uma lista com todos os livros pertencentes ao tipo de usúario (Admin/Commun)
        {
            //modo como fica o select no dotnet 
            var lquery1 = from book in _context.Set<Book>()
                          join user in _context.Set<IdentityUser>()
                            on book.createdById equals user.Id
                          join userRoles in _context.Set<IdentityUserRole<string>>()
                            on user.Id equals userRoles.UserId
                          join role in _context.Set<IdentityRole>()
                            on userRoles.RoleId equals role.Id
                          where role.Name.ToUpper() == getRole
                          select new Book()
                          {

                              Id = book.Id,
                              Nome = book.Nome,
                              Price = book.Price,
                              Description = book.Description,
                              created = book.created,
                              updated = book.updated,
                              createdBy = book.createdBy,
                              updatedBy = book.updatedBy
                          };
            return lquery1.ToList();// retorna uma lista como resultado do select 

        }

        public bool Create(Book b)
        {
            try
            {
                b.created = DateTime.Now;
                _context.Book.Add(b);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            if (!_context.Book.Any(book => book.Id == id))
                throw new Exception("Livro não existe!");

            try
            {
                _context.Remove(this.Get(id));//chama o contexto e passa o id para o metodo get pra buscar o livro e depois remoivelo
                _context.SaveChanges();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public Book Get(int? id)
        {
            return _context.Book.FirstOrDefault(l => l.Id == id);
        }

        public bool Update(Book b)
        {
            try
            {
                if (!_context.Book.Any(p => p.Id == b.Id)) throw new Exception("Produto não existe!");

                b.updated = DateTime.Now;                
                _context.Update(b);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }
    }
}
