using Microsoft.EntityFrameworkCore;

namespace Model {
    public class TrialContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            string UserID = "postgres";
            string DBName = "Week1-DB"; //change it accordingly
            string Host = "localhost"; //127.0.0.1
            string Port = "5432";
            builder.UseNpgsql($"User ID={UserID};Host={Host};Port={Port};Database={DBName};Pooling=true;");
            builder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
        }
    }
}