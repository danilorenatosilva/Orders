using Domain;
using Dominio.Interfaces;
using Infrastructure.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DatabaseContext _context;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
		}

		public User Create(User user)
		{
			user.CreatedAt = DateTime.Now;
			_context.Users.Add(user);
			return user;
		}

		public User GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<User> GetUsers()
		{
			return _context.Users.ToList();
		}

		public void Update(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
