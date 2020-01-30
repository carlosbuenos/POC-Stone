using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Infra.AcessoBaseDados.AcessoPostgres
{
	public  class ContextoPostgres : DbContext
	{
		public DbSet<Pagamentos> Pagamentos { get; set; }

		public ContextoPostgres()
		{

		}
		public ContextoPostgres(DbContextOptionsBuilder<ContextoPostgres> opcoes)
		{
			opcoes.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=pocstone;User Id=pocstone;Password=pocstone;");
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pagamentos>()
				.ToTable("Pagamentos")
				.HasKey(x => x.codPagamento);
		}
	}
}
