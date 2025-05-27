using MediatR;

namespace DynatronDemo.WebApi.Application.Commands
{
	public class BaseCommand : IRequest<CommandResult>
	{
	}
}
