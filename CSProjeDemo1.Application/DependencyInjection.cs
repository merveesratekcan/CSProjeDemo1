using Microsoft.Extensions.DependencyInjection;
using CSProjeDemo1.Application.Interfaces;
using CSProjeDemo1.Application.Services;
using CSProjeDemo1.Application.Mappings;
using FluentValidation;
using System.Reflection;
using IMemberService = CSProjeDemo1.Application.Interfaces.IMemberService;

namespace CSProjeDemo1.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
} 