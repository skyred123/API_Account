using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class RoleClaim
	{
		public string Id { get; set; } = null!;
		public string RoleId { get; set; } = null!;
		public string RoleType { get; set; } = null!;
		public string RoleValue { get; set; } = null!;

		public Role Role { get; set; } = null!;
	}
}
