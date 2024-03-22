using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<autorModel>
    {
        public void Configure(EntityTypeBuilder<autorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nacionalidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataNascimento).IsRequired();
        }
    }
}
