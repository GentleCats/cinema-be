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

            modelBuilder.Entity("cinema_be.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookingTime = new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookingTime = new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 8,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookingTime = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            BookingTime = new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            BookingTime = new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            BookingTime = new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = 4,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("cinema_be.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Сapacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Halls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Альфа",
                            Сapacity = 302
                        },
                        new
                        {
                            Id = 2,
                            Name = "Парадиз",
                            Сapacity = 377
                        },
                        new
                        {
                            Id = 3,
                            Name = "Арена",
                            Сapacity = 346
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

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
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
                            MovieId = 1,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            HallId = 1,
                            MovieId = 1,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            HallId = 1,
                            MovieId = 1,
                            StartTime = new TimeSpan(0, 19, 55, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            HallId = 2,
                            MovieId = 2,
                            StartTime = new TimeSpan(0, 10, 10, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 18, 10, 0, 0),
                            HallId = 2,
                            MovieId = 2,
                            StartTime = new TimeSpan(0, 16, 20, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            HallId = 2,
                            MovieId = 2,
                            StartTime = new TimeSpan(0, 10, 10, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 18, 10, 0, 0),
                            HallId = 2,
                            MovieId = 2,
                            StartTime = new TimeSpan(0, 16, 20, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Date = new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 22, 10, 0, 0),
                            HallId = 3,
                            MovieId = 3,
                            StartTime = new TimeSpan(0, 20, 10, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Date = new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 22, 10, 0, 0),
                            HallId = 3,
                            MovieId = 3,
                            StartTime = new TimeSpan(0, 20, 10, 0, 0)
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HallId = 1,
                            Price = 250m
                        },
                        new
                        {
                            Id = 2,
                            HallId = 3,
                            Price = 220m
                        },
                        new
                        {
                            Id = 3,
                            HallId = 2,
                            Price = 230m
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "osadets@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "Qwerty!",
                            UserName = "Sasha Osadets"
                        },
                        new
                        {
                            Id = 2,
                            Email = "fedor@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "Qwerty!",
                            UserName = "Fedor"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Maksym@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "Qwerty!",
                            UserName = "Maksym Banatskyi"
                        },
                        new
                        {
                            Id = 4,
                            Email = "MaksymL@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "Qwerty!",
                            UserName = "Maksym Lazarchuk"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Volodymyr@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "Qwerty!",
                            UserName = "Volodymyr Yakovchuk"
                        },
                        new
                        {
                            Id = 6,
                            Email = "admin@gmail.com",
                            IsAdmin = true,
                            PasswordHash = "psw!admin",
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("cinema_be.Entities.Booking", b =>
                {
                    b.HasOne("cinema_be.Entities.Session", "Session")
                        .WithMany("Bookings")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cinema_be.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("User");
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
                    b.HasOne("cinema_be.Entities.Hall", "Hall")
                        .WithMany("Tickets")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");
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

            modelBuilder.Entity("cinema_be.Entities.Session", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("cinema_be.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
