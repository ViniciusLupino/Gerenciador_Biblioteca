using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class AvaliacaoRepositorio : IAvaliacaoRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    /*---------------------------------*/

    public AvaliacaoRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<avaliacaoModel> BuscarPorId(int id)
    {
        return await _dbContext.Avaliacoes.Include(x => x.Usuario).Include(x => x.Livro).FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<avaliacaoModel>> BuscarTodos()
    {
        return await _dbContext.Avaliacoes.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<avaliacaoModel> Adicionar(avaliacaoModel autor)
    {
        await _dbContext.Avaliacoes.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        avaliacaoModel autorPorId = await BuscarPorId(id);

        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Avaliacoes.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    /*---------------------------------*/

    public async Task<avaliacaoModel> Atualizar(avaliacaoModel autor, int id)
    {
        avaliacaoModel autorPorId = await BuscarPorId(id);

        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        autorPorId.Pontuacao = autor.Pontuacao;
        autorPorId.Comentario = autor.Comentario;
        autorPorId.DataAv = autor.DataAv;
        autorPorId.LivroId = autor.LivroId;
        autorPorId.UsuarioId = autor.UsuarioId;
   

        _dbContext.Avaliacoes.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }
}