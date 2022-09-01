using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Todo.DataAccess.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.DataAccess.Unit_Of_Work;

namespace Todo.Business.Registrations;

public static class DataAccessRegistration
{
    public static void AddDataAccessRegistrations(this IServiceCollection provider)
    {
        provider.AddDbContext<TodoContext>(options =>
        {
            options.UseNpgsql(Configurations.GetConnectionString);
            options.LogTo(Console.WriteLine, LogLevel.Information);

        });
        provider.AddScoped<IUow, Uow>(); 
    }
}