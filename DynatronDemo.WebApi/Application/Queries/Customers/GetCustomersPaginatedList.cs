using DynatronDemo.WebApi.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DynatronDemo.WebApi.Application.Queries.Customers
{
	public static class GetCustomersPaginatedList
	{
		public class Query : BasePaginatedQuery<CustomerDto>
		{
			public string? SearchTerm { get; private set; }

			private class Handler : IRequestHandler<Query, BasePaginatedQueryResult<CustomerDto>>
			{
				private readonly IApplicationDbContext _context;
				public Handler(IApplicationDbContext context)
				{
					_context = context;
				}
				public async Task<BasePaginatedQueryResult<CustomerDto>> Handle(Query request, CancellationToken cancellationToken)
				{
					var query = _context.Customers.AsQueryable();

					if (!string.IsNullOrWhiteSpace(request.SearchTerm))
					{
						query = query.Where(c => c.FirstName.Contains(request.SearchTerm) ||
												 c.LastName.Contains(request.SearchTerm) ||
												 c.Email.Contains(request.SearchTerm));
					}

					var totalCount = await query.CountAsync(cancellationToken);

					var items = await query
						.OrderBy(c => c.LastName)
						.Skip((request.PageNumber - 1) * request.PageSize)
						.Take(request.PageSize)
						.Select(c => new CustomerDto
						{
							Id = c.Id,
							FirstName = c.FirstName,
							LastName = c.LastName,
							Email = c.Email,
							CreatedAt = c.CreatedAt,
							LastUpdated = c.LastUpdated
						})
						.ToListAsync(cancellationToken);

					return new BasePaginatedQueryResult<CustomerDto>(items, request.PageNumber, request.PageSize, totalCount);
				}
			}
		}


		public class CustomerDto
		{
			public long Id { get; set; }
			public string? FirstName { get; set; }
			public string? LastName { get; set; }
			public string? Email { get; set; }
			public DateTime CreatedAt { get; set; }
			public DateTime? LastUpdated { get; set; }
		}
	}
}
