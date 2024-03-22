using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class ReservaRepositorio : IReservaRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    public ReservaRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<reservaModel> BuscarPorId(int id)
    {
        return await _dbContext.Reservas.Include(x => x.Livro).Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<reservaModel>> BuscarTodos()
    {
        return await _dbContext.Reservas.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<reservaModel> Adicionar(reservaModel autor)
    {
        await _dbContext.Reservas.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        reservaModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Reservas.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    /*---------------------------------*/

    public async Task<reservaModel> Atualizar(reservaModel autor, int id)
    {
        reservaModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        autorPorId.DataRes = autor.DataRes;
        autorPorId.Status = autor.Status;
        autorPorId.LivroId = autor.LivroId;
        autorPorId.UsuarioId = autor.UsuarioId;
   

        _dbContext.Reservas.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }
}