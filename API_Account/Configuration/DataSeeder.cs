using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DataModels.Entity;
using DataModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service_Layer;

namespace API_Account.Configuration
{
	public class DataSeeder
	{
		public async void Initialize(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				RoleService? roleService = serviceScope.ServiceProvider.GetService<RoleService>();
				if (roleService == null)
				{
					return;
				}
				var list =  await roleService.GetAllRoleAsync();
				if (!list.Any())
				{
					var listRole = new List<Role>() {
						new Role { Id = Guid.NewGuid().ToString(), Name = "Admin" },
						new Role { Id = Guid.NewGuid().ToString(), Name = "User" },
						new Role { Id = Guid.NewGuid().ToString(), Name = "Manager" }
					};
					foreach (var role in listRole)
					{
						await roleService.AddRoleAsync(role);
					}
				}
			}
		}
	}
}
