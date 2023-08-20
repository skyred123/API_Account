using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Implementation
{
    public class UnitofWork : IUnitofWork
    {
		private bool _disposed = false;
		private AppDbContext _dbContext;
		private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
		public UnitofWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		public IGenericRepository<T> GetRepository<T>(bool? mapKey = false) where T : class
		{
			if (mapKey == true) _dbContext = new MapKey().MapAssociations(_dbContext, typeof(T));

			if (_repositories.ContainsKey(typeof(T)))
			{
				var repository = _repositories[typeof(T)];
				if (repository != null)
				{
					return repository as IGenericRepository<T> ?? throw new ArgumentNullException(nameof(repository));
				}
			}

			var newRepository = new GenericRepository<T>(_dbContext);
			_repositories.Add(typeof(T), newRepository);
			return newRepository;
		}

		public async Task<bool> ComleteAsync(Action action)
		{
			using var transaction = _dbContext.Database.BeginTransaction();

			try
			{
				action();
				await _dbContext.SaveChangesAsync();
				transaction.Commit();
				return true;
			}
			catch
			{
				transaction.Rollback();
				return false;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}

				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}


	}
}
