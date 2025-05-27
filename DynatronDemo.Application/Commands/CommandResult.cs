namespace DynatronDemo.Application.Commands
{
	public class CommandResult
	{
		public bool Success => Errors.Count == 0;
		public List<string> Errors { get; set; } = [];
		public string? TraceId { get; set; }
	}
}
