using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XTRA.Infrastructure.DBcontext;

namespace XTRA.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPersistence();
            return services;
        }
        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = CleanArchitecture.sqlite"));

            //services.AddScoped<IRemindersRepository, RemindersRepository>();
            //services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
