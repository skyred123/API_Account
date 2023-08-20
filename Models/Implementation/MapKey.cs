using DataModels.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Implementation
{
	public class MapKey
	{
		public AppDbContext MapAssociations(AppDbContext dbContext,Type type)
		{
			if (type == typeof(User))
			{
				dbContext.Set<User>().Include(e => e.RoleUsers).ThenInclude(e=>e.Role).Include(e => e.Logins).Include(e => e.Tokens).Load();
			}
			return dbContext;
		}
	}
}
