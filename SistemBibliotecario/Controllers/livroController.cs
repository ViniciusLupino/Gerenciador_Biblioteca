using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class livroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorios;

        public livroController(ILivroRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<livroModel>>> BuscarTodos()
        {
            List<livroModel> livros = await _livroRepositorios.BuscarTodos();
            return Ok(livros);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<livroModel>> BuscarPorId(int id)
        {
            livroModel livro = await _livroRepositorios.BuscarPorId(id);
            return Ok(livro);
        }

        [HttpPost]

        public async Task<ActionResult<livroModel>> Adicionar([FromBody] livroModel livroModel)
        {
            livroModel livro = await _livroRepositorios.Adicionar(livroModel);
            return Ok(livro);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<livroModel>> Atualizar(int id, [FromBody] livroModel livroModel)
        {
            livroModel.Id = id;
           
            livroModel livro = await _livroRepositorios.Atualizar(livroModel, id);
            return Ok(livro);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<livroModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }