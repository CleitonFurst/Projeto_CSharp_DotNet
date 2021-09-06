using books.Models;
using System;
using System.Collections.Generic;


namespace books.Services
{
    public class BooksStaticService : IBooksService
    {
        public List<Book> All()
        {
            List<Book> lista = new List<Book>();
            lista.Add(new Book() { Id = 1, Nome =  " Orgulho e Preconceito - Jane Austen", Description = "Se você procura bons livros para ler, os romances de Jane Austen são sempre uma ótima escolha." +
                                                    " Poucas histórias de amor se comparam ao clássico da literatura inglesa Orgulho e Preconceito." +
                                                    " Quando Elizabeth Bennett conhece o senhor Darcy, de início eles se odeiam." +
                                                    " Mas, através de várias aventuras, cada um vai descobrir o bom carácter do outro. " +
                                                    "Mesmo assim, será que conseguem largar o orgulho (e o preconceito) para admitir o que sentem?", Price = 30.20 });
            return lista;
        }

        public List<Book> BooksByUserRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool Create(Book b)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Book Get(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
