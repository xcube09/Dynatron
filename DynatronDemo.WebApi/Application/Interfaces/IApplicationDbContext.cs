using DynatronDemo.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DynatronDemo.WebApi.Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Customer> Customers { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
