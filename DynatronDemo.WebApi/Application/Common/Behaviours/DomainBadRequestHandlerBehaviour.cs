using DynatronDemo.WebApi.Application.Commands;
using FluentValidation.Results;
using MediatR;
using ValidationException = DynatronDemo.WebApi.Application.Common.Exceptions.ValidationException;

namespace DynatronDemo.WebApi.Application.Common.Behaviours
{
	public class DomainBadRequestHandlerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var response = await next();

			if (response is CommandResult)
			{
				var r = response as CommandResult;

				if (!r.Success)
				{
					var failures = r.Errors.ConvertAll(x => new ValidationFailure("", x));
					throw new ValidationException(failures);
				}
			}
			return response;
		}
	}
}