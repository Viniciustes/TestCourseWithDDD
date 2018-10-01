using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestCourseWithDDD.IoC
{
    public static class StartupIoC
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration["TestCourseWithDDDConnectionString"]));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
