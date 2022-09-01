using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Todo.DataAccess.Contexts;

namespace Todo.Business;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoContext>
{
    public TodoContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TodoContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configurations.GetConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}