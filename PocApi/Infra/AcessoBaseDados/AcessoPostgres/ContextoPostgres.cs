using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
