using DynatronDemo.Application.Interfaces;
using DynatronDemo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynatronDemo.Infrastructure.Data
{
	public class EfApplicationDbContext : DbContext, IApplicationDbContext
	{
		public EfApplicationDbContext(DbContextOptions<EfApplicationDbContext> options) : base(options) { }

		public DbSet<Customer> Customers { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(typeof(EfApplicationDbContext).Assembly);


		}
	}
}