using DynatronDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DynatronDemo.Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Customer> Customers { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
