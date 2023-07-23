﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chomer_backend.Data;

#nullable disable

namespace chomer_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230723133434_seed database")]
    partial class seeddatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("chomer_backend.Models.Chore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedToId = 1,
                            CreatedById = 2,
                            Description = "Whole villa otherwise I will not count it <3",
                            HouseId = 1,
                            Name = "Vaccum",
                            Value = 100
                        },
                        new
                        {
                            Id = 2,
                            CreatedById = 2,
                            HouseId = 1,
                            Name = "Dishwasher"
                        });
                });

            modelBuilder.Entity("chomer_backend.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gustavilla",
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("chomer_backend.Models.HouseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HouseUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HouseId = 1,
                            IsAdmin = true,
                            Points = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            HouseId = 1,
                            IsAdmin = true,
                            Points = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            HouseId = 1,
                            IsAdmin = false,
                            Points = 0,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("chomer_backend.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rewards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 2000,
                            HouseId = 1,
                            Name = "Holiday trip",
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            Cost = 200,
                            HouseId = 1,
                            Name = "Ice cream"
                        });
                });

            modelBuilder.Entity("chomer_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pablo@gmail.com",
                            Name = "Pablo",
                            Password = "Paword"
                        },
                        new
                        {
                            Id = 2,
                            Email = "gustav@gmail.com",
                            Name = "Gustavo",
                            Password = "Gusword"
                        },
                        new
                        {
                            Id = 3,
                            Email = "walt@gmail.com",
                            Name = "Walter",
                            Password = "Walword"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
