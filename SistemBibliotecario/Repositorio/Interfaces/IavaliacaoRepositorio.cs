using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interfaces;

public interface IAvaliacaoRepositorio
{
    Task<List<avaliacaoModel>> BuscarTodos();
    
    Task<avaliacaoModel> BuscarPorId(int id);

    Task<avaliacaoModel> Adicionar(avaliacaoModel autor);

    Task<avaliacaoModel> Atualizar(avaliacaoModel autor, int id);

    Task<bool> Apagar(int id);
}