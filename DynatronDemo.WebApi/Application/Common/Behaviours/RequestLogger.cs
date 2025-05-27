using DynatronDemo.WebApi.Application.Common.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DynatronDemo.WebApi.Application.Common.Behaviours
{
	public class RequestLogger<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly ILogger _logger;

		public RequestLogger(ILogger<TRequest> logger)
		{
			_logger = logger;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			_logger.LogInformation("----- Handling command {CommandName} ({@Command})", request?.GetGenericTypeName(), request);
			var response = await next();
			_logger.LogInformation("----- Command {CommandName} handled - response: {@Response}", request?.GetGenericTypeName(), response);

			return response;
		}
	}
}