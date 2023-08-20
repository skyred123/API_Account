using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class Login
	{
		public string LoginProvider { get; set; } = null!;
		public string ProviderKey { get; set; } = null!;
		public string ProviderDisplayName { get; set; } = null!;
		public string UserId { get; set; } = null!;

		public User User { get; set; } = null!;
	}
}
