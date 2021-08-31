namespace Domain
{
	public class User : Entity
	{
		public string UserName { get; set; }
		public string FullDisplayName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
