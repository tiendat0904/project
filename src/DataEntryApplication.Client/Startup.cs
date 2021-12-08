using DataEntryApplication.Client.Services;
using Blazored.LocalStorage;
using DataEntryApplication.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DataEntryApplication.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICMD1Services, CMD1Service>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
