using Azure;
using DataModels.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Service_Layer.ExecResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
	public class AccountService
	{
		private readonly UserService _userService;
		private readonly JwtService _jwtService;

		public AccountService(UserService userService, JwtService jwtService)
		{
			_userService = userService;
			_jwtService = jwtService;
		}

		public async Task<OperationResult> LoginAsync(User user)
		{
			var result = await _userService.IsValidUser(user.Email, user.Password);
			if (result == null) return new OperationResult {Success= false,ErrorMessage= "No results found"};

			var token = _jwtService.GenerateJwtToken(result, Guid.NewGuid().ToString(), DateTime.UtcNow.AddMinutes(5));

			return new OperationResult { Success = true, Data = new {Token = token} };
		}
	}
}
