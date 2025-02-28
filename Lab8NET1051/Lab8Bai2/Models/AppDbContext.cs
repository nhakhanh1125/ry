using Microsoft.EntityFrameworkCore;

namespace Lab8Bai2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
