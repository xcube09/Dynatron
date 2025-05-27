using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DynatronDemo.WebApi.Infrastructure.Data
{
	public class EfApplicationDbContextFactory : IDesignTimeDbContextFactory<EfApplicationDbContext>
	{
		public EfApplicationDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<EfApplicationDbContext>();

			var connectionString = configuration.GetConnectionString("DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);

			return new EfApplicationDbContext(optionsBuilder.Options);
		}
	}
}
