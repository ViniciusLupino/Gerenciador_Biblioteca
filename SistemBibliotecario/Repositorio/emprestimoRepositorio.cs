using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class EmprestimoRepositorio : IEmprestimoRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    /*---------------------------------*/

    public EmprestimoRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<emprestimoModel> BuscarPorId(int id)
    {
        return await _dbContext.Emprestimos.Include(x => x.Livro).Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<emprestimoModel>> BuscarTodos()
    {
        return await _dbContext.Emprestimos.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<emprestimoModel> Adicionar(emprestimoModel autor)
    {
        await _dbContext.Emprestimos.AddAsync(autor);
        await _dbContext.SaveChangesAsync();

        return autor;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        emprestimoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Emprestimos.Remove(autorPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    /*---------------------------------*/

    public async Task<emprestimoModel> Atualizar(emprestimoModel autor, int id)
    {
        emprestimoModel autorPorId = await BuscarPorId(id);


        if (autorPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        autorPorId.DataEmp = autor.DataEmp;
        autorPorId.DataDev = autor.DataDev;
        autorPorId.Status = autor.Status;
        autorPorId.LivroId = autor.LivroId;
        autorPorId.UsuarioId = autor.UsuarioId;
   

        _dbContext.Emprestimos.Update(autorPorId);
        await _dbContext.SaveChangesAsync();

        return autorPorId;
    }
}