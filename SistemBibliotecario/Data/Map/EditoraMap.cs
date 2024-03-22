using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class EditoraMap : IEntityTypeConfiguration<editoraModel>
    {
        public void Configure(EntityTypeBuilder<editoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Localizacao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.AnoFund).IsRequired();
        }
    }
}
