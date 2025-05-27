using MediatR;

namespace DynatronDemo.Application.Queries
{
	public class BaseQuery<T> : IRequest<T> where T : class
	{
	}
}
