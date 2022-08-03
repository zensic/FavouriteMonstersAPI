﻿// <auto-generated />
using System;
using FavouriteMonstersAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FavouriteMonstersAPI.Migrations
{
    [DbContext(typeof(MonstersDbContext))]
    [Migration("20220802082404_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FavouriteMonstersAPI.Models.Elements", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Elements");

                    b.HasData(
                        new
                        {
                            Id = new Guid("857001bb-a951-49a7-8b02-9165396b77b0"),
                            Color = "#cf3b47",
                            Name = "Fire"
                        },
                        new
                        {
                            Id = new Guid("51849274-e176-4295-b409-536e3039f7ec"),
                            Color = "#4f6cd0",
                            Name = "Water"
                        },
                        new
                        {
                            Id = new Guid("7a096af8-1221-4f63-b579-7e1bd67b2359"),
                            Color = "#5d7a28",
                            Name = "Green"
                        });
                });

            modelBuilder.Entity("FavouriteMonstersAPI.Models.Monsters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ElementId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("FavouriteMonstersAPI.Models.Monsters", b =>
                {
                    b.HasOne("FavouriteMonstersAPI.Models.Elements", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });
#pragma warning restore 612, 618
        }
    }
}
