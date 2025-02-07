﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cinema_be;

#nullable disable

namespace cinema_be.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("cinema_be.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cols")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rows")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Halls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 302,
                            Cols = 0,
                            Name = "Альфа",
                            Rows = 0
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 377,
                            Cols = 0,
                            Name = "Парадиз",
                            Rows = 0
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 346,
                            Cols = 0,
                            Name = "Арена",
                            Rows = 0
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cast")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("TmdbId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("cinema_be.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("cinema_be.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            HallId = 1,
                            MovieId = 85,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            HallId = 1,
                            MovieId = 85,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            HallId = 1,
                            MovieId = 85,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            HallId = 2,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 10, 10, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 18, 10, 0, 0),
                            HallId = 2,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 16, 20, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            HallId = 2,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 10, 10, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 18, 10, 0, 0),
                            HallId = 2,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 16, 20, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 22, 10, 0, 0),
                            HallId = 3,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 20, 10, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 22, 10, 0, 0),
                            HallId = 3,
                            MovieId = 426063,
                            StartTime = new TimeSpan(0, 20, 10, 0, 0)
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Col")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Row")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Seat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("cinema_be.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("cinema_be.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("cinema_be.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("cinema_be.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("cinema_be.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema_be.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("cinema_be.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cinema_be.Entities.Session", b =>
                {
                    b.HasOne("cinema_be.Entities.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema_be.Entities.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("cinema_be.Entities.Ticket", b =>
                {
                    b.HasOne("cinema_be.Entities.Hall", null)
                        .WithMany("Tickets")
                        .HasForeignKey("HallId");

                    b.HasOne("cinema_be.Entities.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema_be.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cinema_be.Entities.Hall", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("cinema_be.Entities.Movie", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("cinema_be.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
