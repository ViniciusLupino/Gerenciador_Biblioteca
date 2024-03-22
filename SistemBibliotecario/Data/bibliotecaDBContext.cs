using Microsoft.EntityFrameworkCore;
using GerenciamentoBiblioteca.Data.Map;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data;

public class bibliotecaDBContext : DbContext
{
    public bibliotecaDBContext(DbContextOptions<bibliotecaDBContext> options) : base(options) { }

    public DbSet<usuarioModel> Usuarios { get; set; }
    public DbSet<livroModel> Livros { get; set; }
    public DbSet<autorModel> Autores { get; set; }
    public DbSet<editoraModel> Editores { get; set; }
    public DbSet<emprestimoModel> Emprestimos { get; set; }
    public DbSet<reservaModel> Reservas { get; set; }
    public DbSet<avaliacaoModel> Avaliacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new LivroMap());
        modelBuilder.ApplyConfiguration(new AutorMap());
        modelBuilder.ApplyConfiguration(new EditoraMap());
        modelBuilder.ApplyConfiguration(new EmprestimoMap());
        modelBuilder.ApplyConfiguration(new ReservaMap());
        modelBuilder.ApplyConfiguration(new AvaliacaoMap());

        base.OnModelCreating(modelBuilder);
    }
}