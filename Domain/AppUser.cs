namespace Domain
{
	public class AppUser : Entity
	{
		public string UserName { get; set; }
		public string FullDisplayName { get; set; }
		public string Email { get; set; }
	}
}
