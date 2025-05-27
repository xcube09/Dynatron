using DynatronDemo.WebApi.Application.Interfaces;
using DynatronDemo.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynatronDemo.WebApi.Infrastructure.Data
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