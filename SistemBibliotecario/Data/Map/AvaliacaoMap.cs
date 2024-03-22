using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<avaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<avaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Pontuacao).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.DataAv).IsRequired();
            builder.Property(x => x.LivroId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
