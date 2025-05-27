﻿namespace DynatronDemo.Domain.Models
{
	public abstract class BaseModel
	{
		public long Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastUpdated { get; set; }
	}
}
