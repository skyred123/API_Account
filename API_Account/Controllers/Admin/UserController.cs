using Business_Logic_Layer.Data_Transfer_Object;
using DataModels.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer;

namespace API_Account.Controllers.Admin
{
	[Route("Account/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;
		private readonly GenericService<User,SignInDTO> _genericService;
		private readonly AccountService _accountService;

		public UserController(UserService userService, GenericService<User, SignInDTO> genericService, AccountService accountService)
		{
			_userService = userService;
			_genericService = genericService;
			_accountService = accountService;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> SignIn(SignInDTO signModel)
		{
			var user = _genericService.ConvertEntity(signModel);
			var result = await _accountService.LoginAsync(user);
			if (result.Success == true)
			{
				return Ok(result);
			}
			return Unauthorized();
		}
		[HttpPost("Register")]
		public async Task<IActionResult> SignIn(SignUpDTO signUpModel)
		{
			return Unauthorized();
		}
		[Authorize]
		[HttpGet("GetAllUser")]
		public async Task<IActionResult> GetAllUser()
		{
			var listUser = await _userService.GetAllUserAsync();
			return Ok(listUser);
		}
	}
}
