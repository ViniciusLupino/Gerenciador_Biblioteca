using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Repositorio.Interfaces;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly bibliotecaDBContext _dbContext;

    /*---------------------------------*/

    public UsuarioRepositorio(bibliotecaDBContext bibliotecaDbContext)
    {
        _dbContext = bibliotecaDbContext;
    }

    /*---------------------------------*/

    public async Task<usuarioModel> BuscarPorId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }

    /*---------------------------------*/

    public async Task<List<usuarioModel>> BuscarTodos()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }

    /*---------------------------------*/

    public async Task<usuarioModel> Adicionar(usuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }

    /*---------------------------------*/

    public async Task<bool> Apagar(int id)
    {
        usuarioModel usuarioPorId = await BuscarPorId(id);


        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        _dbContext.Usuarios.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return true;
           
    }

    /*---------------------------------*/

    public async Task<usuarioModel> Atualizar(usuarioModel usuario, int id)
    {
        usuarioModel usuarioPorId = await BuscarPorId(id);


        if (usuarioPorId == null)
        {
            throw new Exception($"Usuário de ID: {id} não pôde ser encontrado.");
        }

        usuarioPorId.Senha = usuario.Senha;
        usuarioPorId.Email = usuario.Email;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;
    }
}