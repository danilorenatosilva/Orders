using Application.ViewModels;
using Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IAccountService
	{
		Task<UserViewModel> Register(RegisterUserViewModel userViewModel);
		Task<UserViewModel> Login(LoginUserViewModel loginUserViewModel);
		Task<string> CreateToken(IdentityUser user);
	}
}
