using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<livroModel>
    {
        public void Configure(EntityTypeBuilder<livroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnoPubli).IsRequired();
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(13);
            builder.Property(x => x.Sinopse).IsRequired().HasMaxLength(5000);
        }
    }
    
}
