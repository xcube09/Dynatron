namespace DynatronDemo.WebApi.Application.Queries
{
	public class BasePaginatedQuery<T> : BaseQuery<BasePaginatedQueryResult<T>> where T : class
	{
		public int PageNumber { get; set; } = 1; 
		public int PageSize { get; set; } = 20;
	}
}
