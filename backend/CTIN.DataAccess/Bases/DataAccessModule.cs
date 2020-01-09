using Microsoft.Extensions.DependencyInjection;
using CTIN.Common.Interfaces;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Repository;

namespace CTIN.DataAccess.Bases
{
    public class DataAccessModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<NATemplateContext>>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
    }
}
