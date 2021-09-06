using books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;


namespace books.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }
                context.Book.Add(new Book
                    {
                        
                        Nome = "Orgulho e Preconceito - Jane Austen",
                        Price = 30.90,
                        Description = "Se você procura bons livros para ler, os romances de Jane Austen são sempre uma ótima escolha." +
                        " Poucas histórias de amor se comparam ao clássico da literatura inglesa Orgulho e Preconceito." +
                        " Quando Elizabeth Bennett conhece o senhor Darcy, de início eles se odeiam. " +
                        "Mas, através de várias aventuras, cada um vai descobrir o bom carácter do outro. " +
                        "Mesmo assim, será que conseguem largar o orgulho (e o preconceito) para admitir o que sentem?"
                    });
                    context.Book.Add(new Book
                    {
                        
                        Nome = "1984 - George Orwell",
                        Price = 50.20,
                        Description = "Em um país controlado por um regime totalitário, um homem vai se rebelar contra o sistema. " +
                        "Mas cada ação e até cada pensamento dele está sendo vigiado… " +
                        "Escrito em 1948, esse livro é quase profético sobre os perigos modernos da vigilância do Estado, da alteração da História e da criação de fake news. " +
                        "Não tem tempo para livros grandes ? Encontre aqui algo mais à sua medida: os 7 melhores livros para ler em uma sentada."
                    });
                    context.Book.Add(new Book
                    {
                        Nome = "Dom Quixote de la Mancha - Miguel de Cervantes",
                        Price = 70.99,
                        Description = "Um dos maiores clássicos da literatura espanhola, Dom Quixote conta a história de um cavaleiro que leu demasiados romances e enlouqueceu." +
                        " Dom Quixote agora pensa que é um herói, como nos livros que leu, " +
                        "e sai em busca de aventuras com seu leal escudeiro, Sancho Pança. Esse livro cômico inspirou muitas outras sátiras ao longo da História."
                    });
                
                
                context.SaveChanges();
                

                
            }
        }
    }
}
