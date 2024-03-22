using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class emprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepositorio _livroRepositorios;

        public emprestimoController(IEmprestimoRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<emprestimoModel>>> BuscarTodos()
        {
            List<emprestimoModel> autores = await _livroRepositorios.BuscarTodos();
            return Ok(autores);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<emprestimoModel>> BuscarPorId(int id)
        {
            emprestimoModel autor = await _livroRepositorios.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]

        public async Task<ActionResult<emprestimoModel>> Adicionar([FromBody] emprestimoModel emprestimoModel)
        {
            emprestimoModel autor = await _livroRepositorios.Adicionar(emprestimoModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<emprestimoModel>> Atualizar(int id, [FromBody] emprestimoModel emprestimoModel)
        {
            emprestimoModel.Id = id;
           
            emprestimoModel autor = await _livroRepositorios.Atualizar(emprestimoModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<emprestimoModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }