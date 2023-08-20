using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Implementation
{
    public interface IGenericRepository<T>
    {
		Task<List<T>> GetAllAsync();
		Task<T?> GetByIdAsync(string id);
		void AddAsync(T entity);
		void UpdateAsync(T entity);
		void DeleteAsync(string id);
	}
}
