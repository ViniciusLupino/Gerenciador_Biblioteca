using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class avaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _livroRepositorios;

        public avaliacaoController(IAvaliacaoRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<avaliacaoModel>>> BuscarTodos()
        {
            List<avaliacaoModel> autores = await _livroRepositorios.BuscarTodos();
            return Ok(autores);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<avaliacaoModel>> BuscarPorId(int id)
        {
            avaliacaoModel autor = await _livroRepositorios.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]

        public async Task<ActionResult<avaliacaoModel>> Adicionar([FromBody] avaliacaoModel avaliacaoModel)
        {
            avaliacaoModel autor = await _livroRepositorios.Adicionar(avaliacaoModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<avaliacaoModel>> Atualizar(int id, [FromBody] avaliacaoModel avaliacaoModel)
        {
            avaliacaoModel.Id = id;
           
            avaliacaoModel autor = await _livroRepositorios.Atualizar(avaliacaoModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<avaliacaoModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }