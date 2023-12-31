﻿using Microsoft.EntityFrameworkCore;
using chomer_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace chomer_backend.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseUser> HouseUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chore>()
                .HasOne(ch => ch.AssignedTo)
                .WithMany(hu => hu.AssignedChores)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Chore>()
                .HasOne(ch => ch.CreatedBy)
                .WithMany(hu => hu.CreatedChores)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chore>()
                .HasOne(ch => ch.House)
                .WithMany(h => h.Chores)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<House>()
                .HasOne(h => h.Owner)
                .WithMany(u => u.Houses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HouseUser>()
               .HasOne(hu => hu.User)
               .WithMany(u => u.HouseUsers)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HouseUser>()
               .HasOne(hu => hu.House)
               .WithMany(h => h.HouseUsers)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reward>()
               .HasOne(r => r.House)
               .WithMany(h => h.Rewards)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Pablo",
                    Email = "pablo@gmail.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Gustavo",
                    Email = "gustav@gmail.com"
                },
                new User
                {
                    Id = 3,
                    Name = "Walter",
                    Email = "walt@gmail.com"
                }
            );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Name = "Gustavilla",
                    OwnerId = 2
                }
            );
            modelBuilder.Entity<HouseUser>().HasData(
                new HouseUser
                {
                    Id = 1,
                    UserId = 1,
                    HouseId = 1,
                    IsAdmin = true
                },
                new HouseUser
                {
                    Id = 2,
                    UserId = 2,
                    HouseId = 1,
                    IsAdmin = true
                },
                new HouseUser
                {
                    Id = 3,
                    UserId = 3,
                    HouseId = 1
                }
            );
            modelBuilder.Entity<Chore>().HasData(
                new Chore
                {
                    Id = 1,
                    Name = "Vaccum",
                    Description = "Whole villa otherwise I will not count it <3",
                    Value = 100,
                    HouseId = 1,
                    CreatedById = 2,
                    AssignedToId = 1
                },
                new Chore
                {
                    Id = 2,
                    Name = "Dishwasher",
                    HouseId = 1,
                    CreatedById = 2
                }
            );
            modelBuilder.Entity<Reward>().HasData(
                new Reward
                {
                    Id = 1,
                    Name = "Holiday trip",
                    Cost = 2000,
                    Quantity = 1,
                    HouseId = 1
                },
                new Reward
                {
                    Id = 2,
                    Name = "Ice cream",
                    Cost = 200,
                    HouseId = 1
                }
            );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                );
        }
    }
}
