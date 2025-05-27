using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DynatronDemo.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseController : ControllerBase
	{
		private IMediator? _mediatorInstance;

		protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
