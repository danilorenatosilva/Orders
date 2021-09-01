using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Dominio.Interfaces;
using System;
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

		public List<UserViewModel> GetUsersByFilter(string userName, string fullDisplayName, 
													string email, string initialDateString, 
													string finalDateString)
		{
			List<AppUser> appUsers = new List<AppUser>();

			DateTime? initialDate = null;
			DateTime? finalDate = null;

			if (!string.IsNullOrWhiteSpace(initialDateString) && !string.IsNullOrWhiteSpace(finalDateString))
			{
				initialDate = DateTime.Parse(initialDateString);
				finalDate = DateTime.Parse(finalDateString);
			}
			
			appUsers = _repository.GetUsers()
							.Where(u => (string.IsNullOrWhiteSpace(userName) || 
							               (!string.IsNullOrWhiteSpace(userName) &&  
											u.UserName.ToLower().Equals(userName.ToLower())))
									&&
									    (string.IsNullOrWhiteSpace(fullDisplayName) ||
										   (!string.IsNullOrWhiteSpace(fullDisplayName) && 
											u.FullDisplayName.ToLower().Contains(fullDisplayName.ToLower())))
									&& (string.IsNullOrWhiteSpace(email) || 
									       (!string.IsNullOrWhiteSpace(email) && 
									        u.Email.ToLower().Equals(email.ToLower())))
									&&	((initialDate == null || finalDate == null) ||
									        ((initialDate != null && finalDate != null) && 
									        (u.CreatedAt >= initialDate && u.CreatedAt <= finalDate)))
									)
							.ToList();

			return _mapper.Map<List<UserViewModel>>(appUsers);
		}
	}
}
