using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciamentoBiblioteca.Models;

namespace GerenciamentoBiblioteca.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<emprestimoModel>
    {
        public void Configure(EntityTypeBuilder<emprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataEmp).IsRequired();
            builder.Property(x => x.DataDev).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.LivroId).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}
