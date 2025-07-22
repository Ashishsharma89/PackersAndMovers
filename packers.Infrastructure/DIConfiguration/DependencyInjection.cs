using Packer.Application.Interfaces.ML;
using Packer.Application.Services;



namespace packers.Infrastructure.DIConfiguration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IResetTokenRepository, ResetTokenRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMoveRequestRepository, MoveRequestRepository>();
            services.AddScoped<IMoveService, MoveService>();
            services.AddScoped<ITrackingEventRepository, TrackingEventRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITrackingEventService, TrackingEventService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IPredictionService, PredictionService>();

            // Register FCM config and service
            services.Configure<FcmConfig>(configuration.GetSection("FcmSettings"));
            services.AddSingleton<FcmService>();

            return services;
        }
    }
}
