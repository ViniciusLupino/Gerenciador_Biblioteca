namespace GerenciamentoBiblioteca.Models;

public class avaliacaoModel
{
    public int Id { get; set; }
    public int Pontuacao { get; set; }
    public string Comentario { get; set; }
    public DateOnly DataAv { get; set; }
    
    public virtual livroModel? Livro { get; set; }
    public int LivroId { get; set; }
    
    public virtual usuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
}