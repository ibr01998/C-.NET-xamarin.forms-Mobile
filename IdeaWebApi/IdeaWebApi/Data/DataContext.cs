using Microsoft.EntityFrameworkCore;

namespace IdeaWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Idea> ideas { get; set; }
    }
}
