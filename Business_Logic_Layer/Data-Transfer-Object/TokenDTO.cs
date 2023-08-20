using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Data_Transfer_Object
{
	public class TokenDTO
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Value { get; set; } = null!;
		public string UserId { get; set; } = null!;

	}
}
