using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interfaces;

public interface IReservaRepositorio
{
    Task<List<reservaModel>> BuscarTodos();
    
    Task<reservaModel> BuscarPorId(int id);

    Task<reservaModel> Adicionar(reservaModel autor);

    Task<reservaModel> Atualizar(reservaModel autor, int id);

    Task<bool> Apagar(int id);
}