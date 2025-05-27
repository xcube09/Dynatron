using DynatronDemo.WebApi.Application.Commands.Customers;
using DynatronDemo.WebApi.Application.Queries.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DynatronDemo.WebApi.Controllers
{
	public class CustomersController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetPaginatedAsync([FromQuery] GetCustomersPaginatedList.Query query)
		{
			return Ok(await Mediator.Send(query));
		}


		[HttpPost("create")]
		public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpPut("{id:long}/update")]
		public async Task<IActionResult> UpdateAsync([FromRoute]long id, [FromBody] UpdateCustomerCommand command)
		{
			command.Id = id;
			return Ok(await Mediator.Send(command));
		}
	}
}
