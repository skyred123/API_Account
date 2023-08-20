using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Data_Transfer_Object
{
	public class LoginDTO
	{
		public string LoginProvider { get; set; } = null!;
		public string ProviderKey { get; set; } = null!;
		public string ProviderDisplayName { get; set; } = null!;
		public string UserId { get; set; } = null!;

	}
}
