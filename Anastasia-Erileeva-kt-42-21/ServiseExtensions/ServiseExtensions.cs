using Anastasia_Erileeva_kt_42_21.Interfaces;
using static Anastasia_Erileeva_kt_42_21.Interfaces.IStudentService;

namespace Anastasia_Erileeva_kt_42_21.ServiseExtensions
{
    public static class ServiseExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}