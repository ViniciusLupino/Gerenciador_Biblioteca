using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class AutorRepositorio : IAutorRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    /*---------------------------------*/

    public AutorRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<autorModel> BuscarPorId(int id)
    {
        return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<autorModel>> BuscarTodos()
    {
        return await _dbContext.Autores.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<autorModel> Adicionar(autorModel autor)
    {
        await _dbContext.Autores.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        autorModel autorPorId = await BuscarPorId(id);

        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Autores.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    /*---------------------------------*/

    public async Task<autorModel> Atualizar(autorModel autor, int id)
    {
        autorModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        autorPorId.Nome = autor.Nome;
        autorPorId.Nacionalidade = autor.Nacionalidade;
        autorPorId.DataNascimento = autor.DataNascimento;
   

        _dbContext.Autores.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }
}

