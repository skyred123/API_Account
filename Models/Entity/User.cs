using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class User
	{
		public string Id { get; set; } = null!;
		public string DisplayName { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Password { get; set; } = null!;
		public bool LockoutEnabled { get; set; }
		public DateTime LockoutEnd { get; set; }
		public int AccessFailedCount { get; set; }
		public List<RoleUser> RoleUsers { get; set; } = null!;
		public List<Login> Logins { get; set; } = null!;
		public List<Token> Tokens { get; set; } = null!;
	}
}
