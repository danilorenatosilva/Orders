using Domain;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<AppUser> GetUsers();
		List<AppUser> GetUsersByFilter(string userName, string fullDisplayName,
													string email, string initialDateString,
													string finalDateString);
		AppUser GetUserById(int id);
		AppUser Create(AppUser user);
		void Update(AppUser user);
	}
}
