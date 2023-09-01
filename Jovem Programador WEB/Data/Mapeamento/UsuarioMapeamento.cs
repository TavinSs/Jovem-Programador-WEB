using Jovem_Programador_WEB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jovem_Programador_WEB.Data.Mapeamento
{
	public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
	{
		builder.ToTable("Usuario");

		builder.HasKey(t => t.Id);

		builder.Property(t => t.Email).HasColumnType("varchar(256)");
		builder.Property(t => t.Senha).HasColumnType("varchar(150)");
		}
}

	}

