using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Data_Transfer_Object
{
	public class SignInDTO
	{
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
