using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WorkFlow.Application.RequestTypeBL;

namespace WorkFlow.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Create.Command).Assembly);
           
            return services;
        }
    }
}
