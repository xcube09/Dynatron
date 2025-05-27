namespace DynatronDemo.Application.Queries
{
	public class BasePaginatedQueryResult<T> where T : class
	{
		public BasePaginatedQueryResult(List<T> items, int pageNumber, int pageSize, int totalCount)
		{
			Items = items;
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalCount = totalCount;
		}


		public List<T> Items { get; set; }
		public int TotalCount { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
	}
}
