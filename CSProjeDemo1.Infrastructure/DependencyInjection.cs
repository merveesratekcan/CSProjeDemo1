using Microsoft.Extensions.DependencyInjection;
using CSProjeDemo1.Domain.Interfaces;
using CSProjeDemo1.Infrastructure.Repositories;
using ILibraryRepository = CSProjeDemo1.Application.Interfaces.ILibraryRepository;

namespace CSProjeDemo1.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register repositories as singletons to maintain data across requests
            services.AddSingleton<ILibraryRepository, InMemoryLibraryRepository>();
            services.AddSingleton<IMemberRepository, InMemoryMemberRepository>();
            
            return services;
        }
    }
} 