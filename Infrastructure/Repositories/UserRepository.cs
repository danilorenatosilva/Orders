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

		public AppUser Create(AppUser user)
		{
			user.CreatedAt = DateTime.Now;
			_context.Users.Add(user);
			return user;
		}

		public AppUser GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<AppUser> GetUsers()
		{
			return _context.Users.ToList();
		}

		public void Update(AppUser user)
		{
			_context.Entry(user).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
