using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TechChallenge.Persistance.Context;

namespace TechChallenge.Persistance
{
    public static class PersistanceExtensions
    {
        private const string CS_VARIABLE_NAME = "CS_TECH_CHALLENGE_FIAP";
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            string? connectionString = Environment.GetEnvironmentVariable(CS_VARIABLE_NAME, EnvironmentVariableTarget.Machine);
            Version? version = Assembly.GetExecutingAssembly().GetName().Version;

            MySqlServerVersion serverVersion = new(version ?? new(1,0,0));

            services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, serverVersion));
            services.AddDbContext<ReadOnlyDbContext>(opt => opt.UseMySql(connectionString, serverVersion));
        }
    }
}
