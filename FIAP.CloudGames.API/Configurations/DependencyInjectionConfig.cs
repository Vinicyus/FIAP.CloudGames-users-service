using FIAP.CloudGames.Application.DTOs;
using FIAP.CloudGames.Application.Interfaces;
using FIAP.CloudGames.Application.Services;
using FIAP.CloudGames.Application.Validators;
using FIAP.CloudGames.Domain.Interfaces;
using FIAP.CloudGames.Infra.Repository;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.CloudGames.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            // Add Application Insights Telemetry
            builder.Services.AddApplicationInsightsTelemetry();

            //Services

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            // Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Validators
            builder.Services.AddScoped<IValidator<CreateUserDto>, CreateUserValidator>();

            return builder;
        }
    }
}