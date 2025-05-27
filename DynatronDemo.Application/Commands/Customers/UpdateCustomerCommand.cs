using CoreSync.Api.Application;
using DynatronDemo.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DynatronDemo.Application.Commands.Customers
{
	public class UpdateCustomerCommand : BaseCommand
	{
		public long Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }

		private class Handler : IRequestHandler<UpdateCustomerCommand, CommandResult>
		{
			private readonly IApplicationDbContext _context;
			private readonly ILogger<Handler> _logger;

			public Handler(IApplicationDbContext context, ILogger<Handler> logger)
			{
				_context = context;
				_logger = logger;
			}

			public async Task<CommandResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
			{
				var result = new CommandResult();

				var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
				if (customer == null)
				{
					result.Errors.Add("Customer not found.");
					return result;
				}

				if (!string.IsNullOrWhiteSpace(request.Email) &&
					await _context.Customers.AnyAsync(c => c.Email == request.Email && c.Id != request.Id, cancellationToken))
				{
					result.Errors.Add("Email already exists.");
					return result;
				}

				try
				{
					customer.FirstName = request.FirstName ?? customer.FirstName;
					customer.LastName = request.LastName ?? customer.LastName;
					customer.Email = request.Email ?? customer.Email;

					await _context.SaveChangesAsync(cancellationToken);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error updating customer");
					result.Errors.Add(ErrorMessage.ExceptionErrorMessage);
				}

				return result;
			}
		}

		public class CommandValidation : AbstractValidator<UpdateCustomerCommand>
		{
			public CommandValidation()
			{
				RuleFor(x => x.FirstName).NotEmpty();
				RuleFor(x => x.LastName).NotEmpty();
				RuleFor(x => x.Email).NotEmpty().EmailAddress();
			}
		}
	}
}