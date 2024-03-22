using statusReserva.Enums;

namespace GerenciamentoBiblioteca.Models;

public class reservaModel
{
    public int Id { get; set; }
    public DateOnly DataRes { get; set; }
    
    public StatusReserva Status { get; set; }

    public virtual livroModel? Livro { get; set; }
    public int LivroId { get; set; }
    
    public virtual usuarioModel? Usuario { get; set; }
    public int UsuarioId { get; set; }
}