using Microsoft.Extensions.Configuration;

namespace Todo.Business;

public class Configurations
{
    public static string GetConnectionString
    {
        get
        {
            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../UI/TodoApp.UI"));
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("postgreSql");
        }
    }
}