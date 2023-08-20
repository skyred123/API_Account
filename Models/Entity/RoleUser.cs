using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class RoleUser
	{
		public string RoleId { get; set; } = null!;
		public string UserId { get; set; } = null!;
		public User User { get; set; } = null!;
		public Role Role { get; set; } = null!;
	}
}
