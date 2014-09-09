using System;

namespace oats.server.Models
{
	public class DealTask
	{
		public int Id { get; set; }
		public DateTime DueDate { get; set; }
		public Person ResponsiblePerson { get; set; }
		public string Description { get; set; }
	}
}