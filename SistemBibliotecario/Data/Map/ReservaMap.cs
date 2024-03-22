using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<reservaModel>
    {
        public void Configure(EntityTypeBuilder<reservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataRes).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.LivroId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
