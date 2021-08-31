using Domain;
using System.Collections.Generic;

namespace Dominio.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<User> GetUsers();
		User GetUserById(int id);
		User Create(User user);
		void Update(User user);
	}
}
