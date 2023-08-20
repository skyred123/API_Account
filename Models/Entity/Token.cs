using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entity
{
	public class Token
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Value { get; set; } = null!;
		public string UserId { get; set; } = null!;

		public User User { get; set; } = null!;
	}
}
