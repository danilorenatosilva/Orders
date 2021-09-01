using Domain;
using Dominio.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly OrdersDbContext _context;

		public UserRepository(OrdersDbContext context)
		{
			_context = context;
		}

		public AppUser Create(AppUser user)
		{
			user.CreatedAt = DateTime.Now;
			_context.AppUsers.Add(user);
			_context.SaveChanges();
			return user;
		}

		public AppUser GetUserById(int id)
		{
			return _context.AppUsers.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<AppUser> GetUsers()
		{
			return _context.AppUsers.ToList();
		}

		public void Update(AppUser user)
		{
			_context.Entry(user).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
