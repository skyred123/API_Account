using Business_Logic_Layer.Data_Transfer_Object;
using DataModels.Entity;
using Microsoft.AspNetCore.Mvc;
using Service_Layer;

namespace API_Account.Controllers.Admin
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly CryptionService _cryptionService;
		private readonly JwtService _jwtService;
		private readonly AccountService _accountService;
		private readonly GenericService<User,SignInDTO> _genericService;

		public TestController(CryptionService cryptionService, JwtService jwtService, AccountService accountService)
		{
			_cryptionService = cryptionService;
			_jwtService = jwtService;
			_accountService = accountService;
			_genericService = new GenericService<User, SignInDTO>();
		}
	}
}
