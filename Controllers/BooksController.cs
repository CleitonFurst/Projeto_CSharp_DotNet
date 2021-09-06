using books.API;
using books.Models;
using books.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace books.Controllers
{ 
    [AuthorizeRoles(RoleType.Common, RoleType.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ApiBaseController
    {
        IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os livros cadastrados 
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public IActionResult Index() =>
            ApiOk(_service.All());

        /// <summary>
        /// A rota recebe um id especifico que retorna um livro correpondente a este id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeRoles(RoleType.Admin)]
        [Route("{id}")]
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Book exists = _service.Get(id);
            return exists == null ?
            ApiNotFound("Não foi encontrado o livro solicitado!") :
            ApiOk(_service.Get(id));
        }

        /// <summary>
        /// Retona um livro aleatório 
        /// </summary>
        /// <returns></returns>
        [Route("Random"), HttpGet]
        public IActionResult Random()
        {
            Random aleatorio = new Random();
            List<Book> lista = _service.All();
            return ApiOk(lista[aleatorio.Next(lista.Count)]);
        }

        /// <summary>
        /// Rota para criação de um novo livro (inserir os parametros necessarios )
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            book.createdById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Create(book) ?
            ApiOk("Livro adicionado com sucesso!") :
            ApiNotFound("Erro ao adicionar o livro!");
        }
        
        /// <summary>
        /// Realiza a atualização de um livro esta rota recebe um id correspondente a um livro ja cadastrado
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            book.updatedById = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return _service.Update(book) ?
            ApiOk("Os dados do livro foram atualizados com sucesso!") :
            ApiNotFound("Erro ao atualizar os dados do livro!");
        }
          
        /// <summary>
        /// Rota para deletar um livro esta rota recebe um id correspondente a um livro cadastrado 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuthorizeRoles(RoleType.Admin)]
        [Authorize]
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int? id) =>
            _service.Delete(id) ?
            ApiOk("O livro foi excluido com sucesso!") :
            ApiNotFound("Erro ao excluir o livro!");

        /// <summary>
        /// esta rota tras os livros cadastrados pelo tipo de permição que o usúario logado tem 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [AllowAnonymous]//permite que todos os usúarios tenham acesso 
        [Route("BooksByRole/{role?}")]// define o nome da rota 
        [HttpGet]//define que vai ser uma requesição do tipo Get
        // a função BooksByRole vai ser a rota que vai receber o tipo de usúario trazendo os livros cadastrados por esse tipo (Admin/Common)

        public IActionResult BooksByRole(string role)// função criada para instanciar o método BooksByUserRole da classe BooksSQLService 
        {
            return ApiOk(_service.BooksByUserRole(role));// instancia o método de BooksSQLService passando como referencia o tipo de usúario (Admin/Common) e retorna usando um ApiOk
        }
        
    }
}
