using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class editoraController : ControllerBase
    {
        private readonly IEditoraRepositorio _livroRepositorios;

        public editoraController(IEditoraRepositorio livroRepositorios)
        {
            _livroRepositorios = livroRepositorios;
        }

        [HttpGet]
        public async Task<ActionResult<List<editoraModel>>> BuscarTodos()
        {
            List<editoraModel> editores = await _livroRepositorios.BuscarTodos();
            return Ok(editores);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<editoraModel>> BuscarPorId(int id)
        {
            editoraModel editora = await _livroRepositorios.BuscarPorId(id);
            return Ok(editora);
        }

        [HttpPost]

        public async Task<ActionResult<editoraModel>> Adicionar([FromBody] editoraModel editoraModel)
        {
            editoraModel editora = await _livroRepositorios.Adicionar(editoraModel);
            return Ok(editora);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<editoraModel>> Atualizar(int id, [FromBody] editoraModel editoraModel)
        {
            editoraModel.Id = id;
           
            editoraModel editora = await _livroRepositorios.Atualizar(editoraModel, id);
            return Ok(editora);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<editoraModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorios.Apagar(id);
            return Ok(apagado);
        }
    }