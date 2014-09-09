namespace oats.server.Models
{
	public class Person
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public Role Role { get; set; }
		public Agency Agency { get; set; }
	}

	public enum Role
	{
		Agent, Lender, Client, Inspector
	}

	public enum Agency
	{
		Buyer, Seller, Dual
	}
}