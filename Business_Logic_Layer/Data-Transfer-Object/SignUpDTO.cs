using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Data_Transfer_Object
{
	public class SignUpDTO
	{
		public string DisplayName { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string PasswordConfirm { get; set; } = null!;
	}
}
