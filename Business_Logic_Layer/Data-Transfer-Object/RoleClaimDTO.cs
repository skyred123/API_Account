using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Data_Transfer_Object
{
	public class RoleClaimDTO
	{
		public string Id { get; set; } = null!;
		public string RoleId { get; set; } = null!;
		public string RoleType { get; set; } = null!;
		public string RoleValue { get; set; } = null!;

	}
}
