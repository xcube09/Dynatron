using CoreSync.Api.Application;
using DynatronDemo.Application.Interfaces;
using DynatronDemo.Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DynatronDemo.Application.Commands.Customers
{
	public class CreateCustomerCommand : BaseCommand
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }

		private class Handler : IRequestHandler<CreateCustomerCommand, CommandResult>
		{
			private readonly IApplicationDbContext _context;
			private readonly IDateTimeAdaptor _dateTime;
			private readonly ILogger<Handler> _logger;

			public Handler(IApplicationDbContext context, IDateTimeAdaptor dateTime, ILogger<Handler> logger)
			{
				_context = context;
				_dateTime = dateTime;
				_logger = logger;
			}

			public async Task<CommandResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
			{
				var result = new CommandResult();

				if (await _context.Customers.AnyAsync(c => c.Email == request.Email, cancellationToken))
				{
					result.Errors.Add("Email already exists.");
					return result;
				}

				try
				{
					var customer = new Customer
					{
						FirstName = request.FirstName!,
						LastName = request.LastName!,
						Email = request.Email,
						CreatedAt = _dateTime.Now
					};

					_context.Customers.Add(customer);

					await _context.SaveChangesAsync(cancellationToken);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error creating customer");
					result.Errors.Add(ErrorMessage.ExceptionErrorMessage);
				}

				return result;
			}
		}

		public class CommandValidation : AbstractValidator<CreateCustomerCommand>
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
