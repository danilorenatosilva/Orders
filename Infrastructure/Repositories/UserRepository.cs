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
			Random random = new Random(DateTime.Today.Millisecond);
			user.CreatedAt = new DateTime(2021, random.Next(1, 12), random.Next(1, 30));//DateTime.Now;
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

		public List<AppUser> GetUsersByFilter(string userName, string fullDisplayName,
													string email, string initialDateString,
													string finalDateString)
		{
			DateTime? initialDate = null;
			DateTime? finalDate = null;

			if (!string.IsNullOrWhiteSpace(initialDateString) && !string.IsNullOrWhiteSpace(finalDateString))
			{
				initialDate = DateTime.Parse(initialDateString);
				finalDate = DateTime.Parse(finalDateString);
			}

			return GetUsers()
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
						&& ((initialDate == null || finalDate == null) ||
								((initialDate != null && finalDate != null) &&
								(u.CreatedAt >= initialDate && u.CreatedAt <= finalDate)))
						)
				.ToList();
		}

		public void Update(AppUser user)
		{
			_context.Entry(user).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}
