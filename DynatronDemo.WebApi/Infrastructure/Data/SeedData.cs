using DynatronDemo.WebApi.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DynatronDemo.WebApi.Infrastructure.Data
{
	public static class SeedData
	{
		public static async Task SeedCustomersAsync(IServiceProvider serviceProvider)
		{
			var context = serviceProvider.GetRequiredService<EfApplicationDbContext>();

			if (!context.Customers.Any())
			{
				var now = DateTime.UtcNow;
				var customers = new List<Customer>
				{
					new Customer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", CreatedAt = now },
					new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", CreatedAt = now },
					new Customer { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", CreatedAt = now },
					new Customer { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", CreatedAt = now },
					new Customer { FirstName = "David", LastName = "Brown", Email = "david.brown@example.com", CreatedAt = now },
					new Customer { FirstName = "Sarah", LastName = "Miller", Email = "sarah.miller@example.com", CreatedAt = now },
					new Customer { FirstName = "Matthew", LastName = "Wilson", Email = "matthew.wilson@example.com", CreatedAt = now },
					new Customer { FirstName = "Ashley", LastName = "Moore", Email = "ashley.moore@example.com", CreatedAt = now },
					new Customer { FirstName = "Christopher", LastName = "Taylor", Email = "christopher.taylor@example.com", CreatedAt = now },
					new Customer { FirstName = "Jessica", LastName = "Anderson", Email = "jessica.anderson@example.com", CreatedAt = now },
					new Customer { FirstName = "Daniel", LastName = "Thomas", Email = "daniel.thomas@example.com", CreatedAt = now },
					new Customer { FirstName = "Amanda", LastName = "Jackson", Email = "amanda.jackson@example.com", CreatedAt = now },
					new Customer { FirstName = "Joshua", LastName = "White", Email = "joshua.white@example.com", CreatedAt = now },
					new Customer { FirstName = "Megan", LastName = "Harris", Email = "megan.harris@example.com", CreatedAt = now },
					new Customer { FirstName = "Andrew", LastName = "Martin", Email = "andrew.martin@example.com", CreatedAt = now },
					new Customer { FirstName = "Lauren", LastName = "Thompson", Email = "lauren.thompson@example.com", CreatedAt = now },
					new Customer { FirstName = "Ryan", LastName = "Garcia", Email = "ryan.garcia@example.com", CreatedAt = now },
					new Customer { FirstName = "Brittany", LastName = "Martinez", Email = "brittany.martinez@example.com", CreatedAt = now },
					new Customer { FirstName = "Nicholas", LastName = "Robinson", Email = "nicholas.robinson@example.com", CreatedAt = now },
					new Customer { FirstName = "Samantha", LastName = "Clark", Email = "samantha.clark@example.com", CreatedAt = now }
				};

				context.Customers.AddRange(customers);
				await context.SaveChangesAsync();
			}
		}
	}
}
