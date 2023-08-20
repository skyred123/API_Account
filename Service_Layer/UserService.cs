using DataModels.Entity;
using DataModels.Implementation;
using Microsoft.AspNetCore.Identity;
using Service_Layer.ExecResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class UserService
    {
        private readonly IUnitofWork _unitofWork;

        public UserService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
			return await _unitofWork.GetRepository<User>(true).GetAllAsync();
        }
        public async Task<User?> GetUserAsync(string id)
        {
            return await _unitofWork.GetRepository<User>().GetByIdAsync(id);
        }
        public async Task<User?> IsValidUser(string email, string password)
        {
			var listUser = await _unitofWork.GetRepository<User>().GetAllAsync();
			var user = listUser.FirstOrDefault(e => e.Email == email);
			if (user == null)
			{
				return null;
			}
			var passwordHasher = new PasswordHasher<User>();
			string hashedPassword = passwordHasher.HashPassword(user, password);
			PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
			if (result == PasswordVerificationResult.Success)
				return user;
			return null;
		}
        public async Task<OperationResult> AddUserAsync(User user)
        {
            try
            {
                await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<User>().AddAsync(user));
                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }
        public async Task<OperationResult> UpdateUserAsync(User user)
        {
            try
            {
                await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<User>().UpdateAsync(user));
                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<OperationResult> DeleteUserAsync(string id)
        {
            try
            {
                await _unitofWork.ComleteAsync(() => _unitofWork.GetRepository<User>().DeleteAsync(id));
                return new OperationResult { Success = true };
            }
            catch (Exception ex)
            {
                return new OperationResult { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}
