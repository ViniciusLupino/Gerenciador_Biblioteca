using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class reservaController : ControllerBase
    {
        private readonly IReservaRepositorio _livroRepositorios;

        public reservaController(IReservaRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<reservaModel>>> BuscarTodos()
        {
            List<reservaModel> autores = await _livroRepositorios.BuscarTodos();
            return Ok(autores);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<reservaModel>> BuscarPorId(int id)
        {
            reservaModel autor = await _livroRepositorios.BuscarPorId(id);
            return Ok(autor);
        }

        [HttpPost]

        public async Task<ActionResult<reservaModel>> Adicionar([FromBody] reservaModel reservaModel)
        {
            reservaModel autor = await _livroRepositorios.Adicionar(reservaModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<reservaModel>> Atualizar(int id, [FromBody] reservaModel reservaModel)
        {
            reservaModel.Id = id;
           
            reservaModel autor = await _livroRepositorios.Atualizar(reservaModel, id);
            return Ok(autor);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<reservaModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }