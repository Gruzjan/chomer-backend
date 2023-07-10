using Microsoft.EntityFrameworkCore;
using chomer_backend.Models;

namespace chomer_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<Chore> Houses { get; set; }
        public DbSet<HouseUser> UserHouses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
