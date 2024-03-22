using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class EditorarRepositorio : IEditoraRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    /*---------------------------------*/

    public EditorarRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<editoraModel> BuscarPorId(int id)
    {
        return await _dbContext.Editores.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<editoraModel>> BuscarTodos()
    {
        return await _dbContext.Editores.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<editoraModel> Adicionar(editoraModel editora)
    {
        await _dbContext.Editores.AddAsync(editora);
        await _dbContext.SaveChangesAsync();

        return editora;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        editoraModel editoraPorId = await BuscarPorId(id);

        if (editoraPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Editores.Remove(editoraPorId);
        await _dbContext.SaveChangesAsync();

        return true;  
    }

    /*---------------------------------*/

    public async Task<editoraModel> Atualizar(editoraModel editora, int id)
    {
        editoraModel editoraPorId = await BuscarPorId(id);

        if (editoraPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        editoraPorId.Nome = editora.Nome;
        editoraPorId.Localizacao = editora.Localizacao;
        editoraPorId.AnoFund = editora.AnoFund;
        editoraPorId.Livros = editora.Livros;
   

        _dbContext.Editores.Update(editoraPorId);
        await _dbContext.SaveChangesAsync();

        return editoraPorId;
    }
}