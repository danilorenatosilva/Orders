using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Servicos
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository repositorio, IMapper mapper)
		{
			_repository = repositorio;
			_mapper = mapper;
		}

		public UserViewModel Create(UserViewModel userViewModel)
		{
			AppUser user = _mapper.Map<AppUser>(userViewModel);
			user = _repository.Create(user);
			return _mapper.Map<UserViewModel>(user);
		}		

		public UserViewModel GetUserById(int id)
		{
			return _mapper.Map<UserViewModel>(_repository.GetUserById(id));
		}

		public IEnumerable<UserViewModel> GetUsers()
		{
			var users = _repository.GetUsers().ToList();
			return _mapper.Map<List<UserViewModel>>(users);
		}

		public void Update(UserViewModel userViewModel)
		{
			AppUser user = _mapper.Map<AppUser>(userViewModel);
			_repository.Update(user);
		}

		public bool UserExists(string userName)
		{
			return _repository.GetUsers()
						.FirstOrDefault(u => u.UserName.ToLower().Equals(userName)) != null;
		}

		public bool EmailExists(string email)
		{
			return _repository.GetUsers()
						.FirstOrDefault(u => u.Email.Equals(email)) != null;
		}
	}
}
