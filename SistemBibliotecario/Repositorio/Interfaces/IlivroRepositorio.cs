using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Repositorio.Interfaces;

public interface ILivroRepositorio
{
    Task<List<livroModel>> BuscarTodos();
    
    Task<livroModel> BuscarPorId(int id);

    Task<livroModel> Adicionar(livroModel livro);

    Task<livroModel> Atualizar(livroModel livro, int id);

    Task<bool> Apagar(int id);
}