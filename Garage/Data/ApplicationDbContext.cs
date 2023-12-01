using Garage.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pass> Passes { get; set; }
        public DbSet<PaymentFormModel> PaymentFormats { get; set; }
        public DbSet<GarageFormModel> Garages { get; set; }
    }
}
