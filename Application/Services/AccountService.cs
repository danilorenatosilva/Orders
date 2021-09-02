using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly SymmetricSecurityKey _key;

		public AccountService(UserManager<IdentityUser> userManager,
							SignInManager<IdentityUser> signInManager,
							IMapper mapper,
							IConfiguration configuration,
							IUserService userService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
			_userService = userService;
			var tokenKey = configuration["TokenKey"];
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
		}

		public async Task<UserViewModel> Login(LoginUserViewModel loginUserViewModel)
		{
			var user = await _userManager.Users
				.SingleOrDefaultAsync(x => x.UserName == loginUserViewModel.UserName.ToLower());

			if (user == null)
				return null;

			var result = await _signInManager
				.CheckPasswordSignInAsync(user, loginUserViewModel.Password, false);

			if (!result.Succeeded)
				return null;

			var appUser = _userService.GetUserByUserName(user.UserName);

			return new UserViewModel
			{
				UserName = appUser.UserName,
				Token = await CreateToken(user),
				Email = appUser.Email,
				FullDisplayName = appUser.FullDisplayName
			};
		}

		public async Task<UserViewModel> Register(RegisterUserViewModel registerUserViewModel)
		{
			var user = _mapper.Map<IdentityUser>(registerUserViewModel);

			user.UserName = registerUserViewModel.UserName.ToLower();

			var result = await _userManager.CreateAsync(user, registerUserViewModel.Password);

			if (!result.Succeeded)
				return null;

			var userViewModel = new UserViewModel
			{
				Email = registerUserViewModel.Email,
				FullDisplayName = registerUserViewModel.FullDisplayName,
				UserName = registerUserViewModel.UserName
			};
			_userService.Create(userViewModel);

			return new UserViewModel
			{
				UserName = user.UserName,
				Email = user.Email,
				FullDisplayName = userViewModel.FullDisplayName,
				Token = await CreateToken(user)
			};
		}

		public async Task<string> CreateToken(IdentityUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
			};

			var identityClaims = new ClaimsIdentity(claims);

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
			{
				Subject = identityClaims,
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
			});

			return tokenHandler.WriteToken(token);
		}
	}
}
