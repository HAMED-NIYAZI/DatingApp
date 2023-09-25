using Data.Context;
using DatingApp.Api.Services.Implementation;
using DatingApp.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,IConfiguration configuration)
        {

            //اضافه کردن کانتکست
            services.AddDbContext<DatingAppContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DatingAppConnectionString"));
            });

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
