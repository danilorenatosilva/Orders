using Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserViewModel> GetUsers();
		UserViewModel GetUserById(int id);
		List<UserViewModel> GetUsersByFilter(string userName,
											 string fullDisplayName,
											 string email,
											 string initialDate, string finalDate);
		UserViewModel Create(UserViewModel user);
		void Update(UserViewModel user);
		bool UserExists(string userName);
		bool EmailExists(string email);
	}
}
