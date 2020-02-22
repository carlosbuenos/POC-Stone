using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
	public class PagamentosMapping : IEntityTypeConfiguration<Pagamentos>
	{
		public void Configure(EntityTypeBuilder<Pagamentos> builder)
		{
			builder.ToTable("Pagamentos");
			builder.HasIndex(x => x.rastreio);
			builder.Property(x => x.codPagamento)
				.ValueGeneratedOnAdd();
			builder.Property(x => x.dataPagamento).IsRequired();
			builder.Property(x => x.rastreio).HasMaxLength(5).IsRequired();
			builder.Property(x => x.statusPagamento).IsRequired();
			builder.Property(x => x.tipoDePagamento).IsRequired();
			builder.Property(x => x.valor).IsRequired();
		}
	}
}
