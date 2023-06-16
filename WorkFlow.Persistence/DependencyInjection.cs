using Microsoft.Extensions.DependencyInjection;
using WorkFlow.Persistence.Repositories;
using WorkFlow.Application.Interfaces;
using WorkFlow.Persistence.MappingProfiles;
using WorkFlow.Domain.Entities;
using WorkFlow.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace WorkFlow.Persistence
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IRequestTypesRepository, RequestTypesRepository>();
            services.AddScoped<IRequestFormsRepository, RequestFormsRepository>();
            services.AddScoped<IRequestFormControlsRepository, RequestFormControlsRepository>();
            services.AddScoped<IPositionsRepository, PositionRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IUserActionsRepository, UserActionsRepository>();
            services.AddScoped<IControlConditionRepository, ControlConditionRepository>();
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IUsersConditionRepository, UsersConditionRepository>();
            // services.AddScoped<IRequestFormControlConditionsRepository, RequestFormControlConditionsRepository>();
            // services.AddScoped<IRequestFormControlConditionLevelsRepository, RequestFormControlConditionLevelsRepository>();
            services.AddAutoMapper(typeof(Mappers).Assembly);
 
            return services;
        }
    }
}
