using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class autorController : ControllerBase
    {
        private readonly IAutorRepositorio _livroRepositorios;

        public autorController(IAutorRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<autorModel>>> BuscarTodos()
        {
            List<autorModel> autores = await _livroRepositorios.BuscarTodos();
            return Ok(autores);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<autorModel>> BuscarPorId(int id)
        {
            autorModel autor = await _livroRepositorios.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]

        public async Task<ActionResult<autorModel>> Adicionar([FromBody] autorModel autorModel)
        {
            autorModel autor = await _livroRepositorios.Adicionar(autorModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<autorModel>> Atualizar(int id, [FromBody] autorModel autorModel)
        {
            autorModel.Id = id;
           
            autorModel autor = await _livroRepositorios.Atualizar(autorModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<autorModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }