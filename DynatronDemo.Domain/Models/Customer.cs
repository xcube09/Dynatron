namespace DynatronDemo.Domain.Models
{
	public class Customer : BaseModel
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public string? Email { get; set; }
	}
}
