using DynatronDemo.Application.Interfaces;

namespace DynatronDemo.Infrastructure
{
	public class SystemDateTimeAdaptor : IDateTimeAdaptor
	{
		public DateTime Now => DateTime.UtcNow;
	}
}
