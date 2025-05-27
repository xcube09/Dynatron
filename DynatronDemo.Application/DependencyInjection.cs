using DynatronDemo.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DynatronDemo.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainBadRequestHandlerBehaviour<,>));

			return services;
		}
	}
}

