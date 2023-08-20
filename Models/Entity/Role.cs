using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class Role
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public List<RoleClaim> RoleClaims { get; set; } = null!;
		public List<RoleUser> RoleUsers { get; set; } = null!;
	}
}
