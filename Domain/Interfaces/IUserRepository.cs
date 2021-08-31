using Domain;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<AppUser> GetUsers();
		AppUser GetUserById(int id);
		AppUser Create(AppUser user);
		void Update(AppUser user);
	}
}
