using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Infra.Context;
using The3BlackBro.WebQueue.Infra.Data.Repositories;
using The3BlackBro.WebQueue.Service.Services;

namespace The3BlackBro.WebQueue.Service
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString)
        {
            
            services.AddDbContext<WebQueueContext>(o => o.UseNpgsql(connectionString));

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICurrentQueueRepository, CurrentQueueRepository>();
            services.AddTransient<ICurrentQueueService, CurrentQueueService>();

            services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddTransient<IServiceTypeService, ServiceTypeService>();

            services.AddTransient<ICustumerRepository, CustumerRepository>();
            services.AddTransient<ICustumerService, CustumerService>();

            services.AddTransient<IDayBalanceRepository, DayBalanceRepository>();
            services.AddTransient<IDayBalanceService, DayBalanceService>();

            services.AddTransient<ICustumerSelectedServicesRepository, CustumerSelectedServicesRepository>();
            services.AddTransient<IWebQueueContext, WebQueueContext>();

            return services;
        }
    }
}
