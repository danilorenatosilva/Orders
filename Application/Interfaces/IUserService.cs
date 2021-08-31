using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserViewModel> GetUsers();
		UserViewModel GetUserById(int id);
		UserViewModel Create(RegisterUserViewModel user);
		void Update(UserViewModel user);
		bool UserExists(string userName);
		bool EmailExists(string email);
	}
}
