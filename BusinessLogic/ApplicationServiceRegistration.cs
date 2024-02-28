using Class11.BusinessLogic;
using Class11.DAO;
using Class12.Persistence;
using Class13.BusinessLogic;
using Class13.BusinessLogic.Validators;
using Class13.DAO;
using Class13.Domain;
using Class13.DTO;
using FluentValidation;

namespace Class12.BusinessLogic
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationLogic(
            this IServiceCollection services)
        {
            services
                .AddScoped<ITaskRepository, TaskBL>()
                .AddScoped<IUserRepository, UsersBL>()
                .AddScoped<IGoalRepository, GoalsBL>()
                .AddScoped<IProficiencyRepository, ProficienciesBL>()
                .AddScoped<IMilestoneRepository, MilestoneBL>()
                .AddScoped<IValidator<TaskDto>, TaskValidator>()                
                .AddScoped<IValidator<UserDto>, UserValidator>();
            return services;
        }
    }
}
