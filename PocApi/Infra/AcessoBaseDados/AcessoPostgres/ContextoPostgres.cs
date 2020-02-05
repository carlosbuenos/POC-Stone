using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.AcessoBaseDados.AcessoPostgres
{
	public  class ContextoPostgres : DbContext
	{


		public DbSet<Pagamentos> Pagamentos { get; set; }


		public ContextoPostgres(DbContextOptions<ContextoPostgres> options) : base(options)
		{
			
		}

		public ContextoPostgres() : base()
		{
		}

		//public ContextoPostgres(DbContextOptionsBuilder<ContextoPostgres> opcoes)
		//{
		//	opcoes.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=pocstone;User Id=pocstone;Password=pocstone;");
		//}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pagamentos>()
				.ToTable("Pagamentos")
				.Property<string>(p => p.codPagamento).ValueGeneratedOnAdd();



		}
	}
}
