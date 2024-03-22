namespace GerenciamentoBiblioteca.Models;

public class editoraModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Localizacao { get; set; }
    public int AnoFund { get; set; }
    public ICollection<livroModel>? Livros { get; set; }

}