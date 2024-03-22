using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interfaces;

public interface IAutorRepositorio
{
    Task<List<autorModel>> BuscarTodos();
    
    Task<autorModel> BuscarPorId(int id);

    Task<autorModel> Adicionar(autorModel autor);

    Task<autorModel> Atualizar(autorModel autor, int id);

    Task<bool> Apagar(int id);
}