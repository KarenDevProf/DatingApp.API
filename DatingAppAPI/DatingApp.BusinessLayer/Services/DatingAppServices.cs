using DatingApp.BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.BusinessLayer.Services
{
    public class DatingAppServices : IDatingAppServices
    {
        readonly IServiceProvider _serviceProvider;
        public DatingAppServices(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public T GetService<T>() => _serviceProvider.GetRequiredService<T>();
    }
}
