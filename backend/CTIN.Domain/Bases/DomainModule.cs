using Microsoft.Extensions.DependencyInjection;
using CTIN.Common.Extentions;
using System.Reflection;
using CTIN.Common.Interfaces;

namespace CTIN.Domain.Bases
{
    public class DomainModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Add(option => {
                option.assembly = Assembly.Load("CTIN.Domain");
                option.lifeTime = ServiceLifetime.Scoped;
                option.filter = (x => x.Namespace == "CTIN.Domain.Services");
            });
        }
    }

}

