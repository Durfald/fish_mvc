﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fish_mvc.Infrastructure.DatabaseManagement;

#nullable disable

namespace fish_mvc.Migrations
{
    [DbContext(typeof(DatabaseConnection))]
    [Migration("20241121120028_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("fish_mvc.Models.ARENDATOR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Arendators");
                });

            modelBuilder.Entity("fish_mvc.Models.Marker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FreePlaces")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPlaces")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("X")
                        .HasColumnType("REAL");

                    b.Property<float>("Y")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Markers");
                });

            modelBuilder.Entity("fish_mvc.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArendatorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArendatorId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("fish_mvc.Models.Reservation", b =>
                {
                    b.HasOne("fish_mvc.Models.ARENDATOR", "Arendator")
                        .WithMany()
                        .HasForeignKey("ArendatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arendator");
                });
#pragma warning restore 612, 618
        }
    }
}
