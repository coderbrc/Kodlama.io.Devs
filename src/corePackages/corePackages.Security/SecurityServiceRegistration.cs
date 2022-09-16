using corepackages.Security.EmailAuthenticator;
using corePackages.Security.EmailAuthenticator;
using corePackages.Security.JWT;
using corePackages.Security.OtpAuthenticator.OtpNet;
using corePackages.Security.OtpAuthenticator;
using Microsoft.Extensions.DependencyInjection;

namespace corePackages.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
            services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
            return services;
        }
    }
}
