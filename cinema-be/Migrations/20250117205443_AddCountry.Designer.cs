﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cinema_be;

#nullable disable

namespace cinema_be.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250117205443_AddCountry")]
    partial class AddCountry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("cinema_be.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cast")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
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

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("HallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
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
