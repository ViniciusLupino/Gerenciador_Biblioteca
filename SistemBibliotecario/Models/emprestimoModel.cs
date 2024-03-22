using statusEmprestimo.Enums;

namespace GerenciamentoBiblioteca.Models;

public class emprestimoModel
{
    public int Id { get; set; }
    public DateOnly DataEmp { get; set; }
    public DateOnly DataDev { get; set; }
    
    public StatusEmprestimo Status { get; set; }
    
    public virtual livroModel? Livro { get; set; }
    public int LivroId { get; set; }
    
    public virtual usuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
}