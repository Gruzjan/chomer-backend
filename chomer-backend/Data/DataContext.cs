using Microsoft.EntityFrameworkCore;
using chomer_backend.Models;

namespace chomer_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseUser> HouseUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}
