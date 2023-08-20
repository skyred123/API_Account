using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _dbContext;
        private DbSet<T> _dbSet { get; set; }
        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T?> GetByIdAsync(string id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async void AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}
		public void UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
		}

		public void DeleteAsync(string id)
		{
			var entity = _dbSet.Find(id);
			if (entity == null)
				return;
			_dbSet.Remove(entity);
		}

		
	}
}
