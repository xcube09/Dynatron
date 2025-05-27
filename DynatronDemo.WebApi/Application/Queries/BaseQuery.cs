using MediatR;

namespace DynatronDemo.WebApi.Application.Queries
{
	public class BaseQuery<T> : IRequest<T> where T : class
	{
	}
}
