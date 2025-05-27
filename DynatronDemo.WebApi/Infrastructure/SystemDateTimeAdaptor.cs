using DynatronDemo.WebApi.Application.Interfaces;

namespace DynatronDemo.WebApi.Infrastructure
{
	public class SystemDateTimeAdaptor : IDateTimeAdaptor
	{
		public DateTime Now => DateTime.UtcNow;
	}
}
