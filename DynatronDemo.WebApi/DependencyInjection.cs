using Microsoft.EntityFrameworkCore;
using DynatronDemo.WebApi.Application.Interfaces;
using DynatronDemo.WebApi.Infrastructure.Data;
using DynatronDemo.WebApi.Infrastructure;
using DynatronDemo.WebApi.Application.Common.Behaviours;
using MediatR;
using System.Reflection;

namespace DynatronDemo.WebApi
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInstructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainBadRequestHandlerBehaviour<,>));



			services.AddScoped<IApplicationDbContext, EfApplicationDbContext>();
			services.AddTransient<IDateTimeAdaptor, SystemDateTimeAdaptor>();

			services.AddDbContext<EfApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
