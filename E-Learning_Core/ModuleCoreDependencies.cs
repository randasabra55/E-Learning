using E_Learning_Core.Bases;
using E_Learning_Core.Behaviors;
using E_Learning_Core.Features.Users.Commands.Handlers;
using E_Learning_Core.Features.Users.Commands.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Learning_Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            //Configuration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //  services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(AddUserCommand).Assembly);



            //Configuration Of Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //  services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IRequestHandler<AddUserCommand, Response<string>>, UserCommandHandler>();

            return services;
        }

    }
}