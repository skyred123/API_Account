using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Implementation
{
	public interface IUnitofWork : IDisposable
	{
		IGenericRepository<T> GetRepository<T>(bool? MapKey = false) where T : class;
		Task<bool> ComleteAsync(Action action);
	}
}
