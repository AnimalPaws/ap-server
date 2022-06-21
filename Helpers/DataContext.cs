using ap_server.Entities;
using ap_server.Entities.Foundation;
using ap_server.Entities.User;
using ap_server.Entities.Veterinary;
using Microsoft.EntityFrameworkCore;

namespace ap_server.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration, DbContextOptions options) : base (options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseMySQL(Configuration.GetConnectionString("APDatabase"));
        }

        public DbSet<User> user { get; set; }
        public DbSet<UserProfile> user_profile { get; set; }
        public DbSet<Announcement> announce { get; set; }
    }
}
