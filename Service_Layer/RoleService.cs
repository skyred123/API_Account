using Service_Layer.ExecResult;
using DataModels.Entity;
using DataModels.Implementation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class RoleService
	{
		private readonly IUnitofWork _unitofWork;

		public RoleService(IUnitofWork unitofWork)
		{
			_unitofWork = unitofWork;
		}

		public async Task<string> RoleAsStringAsync(string userId)
		{
			var listRoleUser = await _unitofWork.GetRepository<RoleUser>().GetAllAsync();
			var listRoleName = listRoleUser.Where(e => e.UserId == userId).Select(e => e.Role.Name).ToList();
			var roleAsString = string.Join(",", listRoleName);
			return roleAsString;
		}

		public async Task<List<Role>> GetAllRoleAsync()
		{
			return await _unitofWork.GetRepository<Role>().GetAllAsync();
		}
		public async Task<Role?> GetRoleAsync(string id)
		{
			return await _unitofWork.GetRepository<Role>().GetByIdAsync(id);
		}
		public async Task<OperationResult> AddRoleAsync(Role role)
		{
			try
			{
				await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<Role>().AddAsync(role));
				return new OperationResult { Success = true };
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				return new OperationResult { Success = false, ErrorMessage = ex.Message };
			}
		}
		public async Task<OperationResult> UpdateRoleAsync(Role role)
		{
			try
			{
				await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<Role>().UpdateAsync(role));
				return new OperationResult { Success = true };
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				return new OperationResult { Success = false, ErrorMessage = ex.Message };
			}
		}

		public async Task<OperationResult> DeleteRoleAsync(string id)
		{
			try
			{
				await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<Role>().DeleteAsync(id));
				return new OperationResult { Success = true };
			}
			catch (Exception ex)
			{
				return new OperationResult { Success = false, ErrorMessage = ex.Message };
			}
		}
	}
}
