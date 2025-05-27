using MediatR;

namespace DynatronDemo.Application.Commands
{
	public class BaseCommand : IRequest<CommandResult>
	{
	}
}
