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

		public UserViewModel Create(UserViewModel categoriaViewModel)
		{
			User categoria = _mapper.Map<User>(categoriaViewModel);
			categoria = _repository.Create(categoria);
			return _mapper.Map<UserViewModel>(categoria);
		}

		public UserViewModel GetUserById(int id)
		{
			return _mapper.Map<UserViewModel>(_repository.GetUserById(id));
		}

		public IEnumerable<UserViewModel> GetUsers()
		{
			var categorias = _repository.GetUsers().ToList();
			return _mapper.Map<List<UserViewModel>>(categorias);
		}

		public void Update(UserViewModel categoriaViewModel)
		{
			User categoria = _mapper.Map<User>(categoriaViewModel);
			_repository.Update(categoria);
		}
	}
}
