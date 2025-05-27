using DynatronDemo.Application.Interfaces;
using DynatronDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynatronDemo.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInstructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IApplicationDbContext, EfApplicationDbContext>();
			services.AddTransient<IDateTimeAdaptor, SystemDateTimeAdaptor>();

			services.AddDbContext<EfApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
