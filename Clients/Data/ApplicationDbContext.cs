using Clients.Models;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pass> Passes { get; set; }
    }
}
