namespace GerenciamentoBiblioteca.Models;

public class livroModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int AnoPubli { get; set; }
    public int ISBN { get; set; }
    public string Sinopse { get; set; }

}