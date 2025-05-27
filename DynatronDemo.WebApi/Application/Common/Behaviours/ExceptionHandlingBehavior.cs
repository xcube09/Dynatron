using DynatronDemo.WebApi.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DynatronDemo.WebApi.Application.Common.Behaviours
{
	public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var response = await next();

			if (response is CommandResult res)
			{
				res.TraceId = Guid.NewGuid().ToString();
			}

			return response;
		}
	}
}
