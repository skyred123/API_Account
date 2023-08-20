using DataModels.Implementation;
using Service_Layer;

namespace API_Account.Configuration
{
	public class ServiceConfiguration
	{
        private IServiceCollection _services;

		public ServiceConfiguration(IServiceCollection services)
		{
			_services = services;
			ServiceAddTransient();
		}

		public void ServiceAddTransient()
        {
			_services.AddScoped<IUnitofWork, UnitofWork>();

			_services.AddTransient<RoleService>();
			_services.AddTransient<UserService>();

			_services.AddTransient<JwtService>();
			_services.AddTransient<CryptionService>();
			_services.AddTransient<AccountService>();
		}
	}
}
