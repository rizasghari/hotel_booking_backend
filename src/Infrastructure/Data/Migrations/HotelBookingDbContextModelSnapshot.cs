﻿// <auto-generated />
using System;
using HotelBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBooking.src.Infrastructure.Data.Migrations
{
    [DbContext(typeof(HotelBookingDbContext))]
    partial class HotelBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("FeatureHotel", b =>
                {
                    b.Property<int>("FeaturesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HotelsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FeaturesId", "HotelsId");

                    b.HasIndex("HotelsId");

                    b.ToTable("FeatureHotel");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("IconPath")
                        .HasColumnOrder(2);

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Attachments", t =>
                        {
                            t.HasComment("Hotel file attachments");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<int>("BookingStatus")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings", t =>
                        {
                            t.HasComment("Hotel bookings");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT")
                        .HasColumnName("IconPath")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Hotel categories");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT")
                        .HasColumnName("IconPath")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Features", t =>
                        {
                            t.HasComment("Hotel features");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(5);

                    b.Property<string>("Cover")
                        .HasColumnType("TEXT")
                        .HasColumnName("CoverPath")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<decimal>("PerNightPrice")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Hotels", t =>
                        {
                            t.HasComment("Hotels");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(5);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL")
                        .HasColumnOrder(1);

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Locations", t =>
                        {
                            t.HasComment("Locations of hotels");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms", t =>
                        {
                            t.HasComment("Rooms of hotels");
                        });
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnOrder(2);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(6);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(4);

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("TEXT")
                        .HasColumnName("ProfilePhotoPath")
                        .HasColumnOrder(5);

                    b.Property<string>("ResetToken")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(8);

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(9);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(7);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users", t =>
                        {
                            t.HasComment("Registered users");
                        });
                });

            modelBuilder.Entity("HotelBooking.src.Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<int>("BookingId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasAlternateKey("BookingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings", t =>
                        {
                            t.HasComment("Ratings of bookings");
                        });
                });

            modelBuilder.Entity("HotelBooking.src.Domain.Entities.UserFavoriteHotel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<int>("HotelId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(0);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "HotelId");

                    b.HasIndex("HotelId");

                    b.ToTable("UserFavoriteHotels");
                });

            modelBuilder.Entity("FeatureHotel", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entities.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Attachment", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Attachments")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Booking", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Hotel", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Category", "Category")
                        .WithMany("Hotels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Location", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Hotel", "Hotel")
                        .WithOne("Location")
                        .HasForeignKey("HotelBooking.Domain.Entities.Location", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Room", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelBooking.src.Domain.Entities.Rating", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Booking", "Booking")
                        .WithMany("Ratings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBooking.src.Domain.Entities.UserFavoriteHotel", b =>
                {
                    b.HasOne("HotelBooking.Domain.Entities.Hotel", "Hotel")
                        .WithMany("FavoritedByUsers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelBooking.Domain.Entities.User", "User")
                        .WithMany("FavoriteHotels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Booking", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Category", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("FavoritedByUsers");

                    b.Navigation("Location");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.Room", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("HotelBooking.Domain.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("FavoriteHotels");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
