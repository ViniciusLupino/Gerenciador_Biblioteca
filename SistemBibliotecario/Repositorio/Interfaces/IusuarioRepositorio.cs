using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interfaces;

public interface IUsuarioRepositorio
{
    Task<List<usuarioModel>> BuscarTodos();
    Task<usuarioModel> BuscarPorId(int id);

    Task<usuarioModel> Adicionar(usuarioModel usuario);

    Task<usuarioModel> Atualizar(usuarioModel usuario, int id);

    Task<bool> Apagar(int id);
}