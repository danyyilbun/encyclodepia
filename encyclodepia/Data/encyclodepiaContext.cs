using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using encyclodepia.Models;

namespace encyclodepia.Data
{
    public class encyclodepiaContext : DbContext
    {
        public encyclodepiaContext (DbContextOptions<encyclodepiaContext> options)
            : base(options)
        {
        }

        public DbSet<encyclodepia.Models.Item> Item { get; set; } = default!;
    }
}
