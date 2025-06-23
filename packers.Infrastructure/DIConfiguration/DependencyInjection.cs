using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Packer.Application.Services;
using Packer.Application.Interfaces.Repository;
using Packer.Infrastructure.Repositories.Users;
using Packer.Application.Interfaces.Auth;
using Packer.Application.Interfaces.Conmmunication;
using Packer.Infrastructure.Services.Communication;

namespace Packer.Infrastructure.DIConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResetTokenRepository, ResetTokenRepository>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
