using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace encyclodepia.Models
{
    public class AppDBContext : DbContext
    { 
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 
        
        } 
        public DbSet<Item> Items { get; set; }
        public DbSet<Encyclopedia> encyclopedia { get; set; }
    }
   
    
}
