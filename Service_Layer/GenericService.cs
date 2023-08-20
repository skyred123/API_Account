using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
	public class GenericService<T, TDTO>
	{
		private readonly Mapper _entityMapper;

		public GenericService()
		{
			var _configMapper = new MapperConfiguration(cfg => cfg.CreateMap<T, TDTO>().ReverseMap());

			_entityMapper = new Mapper(_configMapper);
		}

		public List<TDTO> GetAllEntities(List<T> listEntitys)
		{
			var entityModels = _entityMapper.Map<List<T>, List<TDTO>>(listEntitys);

			return entityModels;
		}

		public TDTO? GetEntityById(T? entity)
		{
			if (entity == null)
			{
				return default(TDTO);
			}

			TDTO entityModel = _entityMapper.Map<T, TDTO>(entity);
			return entityModel;
		}

		public T ConvertEntity(TDTO entityModel)
		{
			T entity = _entityMapper.Map<TDTO, T>(entityModel);
			return entity;
		}
	}
}
