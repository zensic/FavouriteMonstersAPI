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
    [Migration("20220919064603_InitialCreation")]
    partial class InitialCreation
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
                            Id = new Guid("96089ab3-952e-42ff-b21c-87aebcdc01f2"),
                            Color = "#cf3b47",
                            Name = "Fire"
                        },
                        new
                        {
                            Id = new Guid("67357d7d-c227-44cd-bc22-9e49ab4b05c1"),
                            Color = "#4f6cd0",
                            Name = "Water"
                        },
                        new
                        {
                            Id = new Guid("fba2c4d7-ef8f-4027-93e8-00080a664802"),
                            Color = "#5d7a28",
                            Name = "Grass"
                        },
                        new
                        {
                            Id = new Guid("70db4b22-7b2f-476a-95b0-92a4fc33c960"),
                            Color = "#ffbf00",
                            Name = "Electric"
                        });
                });

            modelBuilder.Entity("FavouriteMonstersAPI.Models.Monsters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defence")
                        .HasColumnType("int");

                    b.Property<Guid>("ElementId")
                        .HasColumnType("char(36)");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("FavouriteMonstersAPI.TokenAuthentication.Token", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Value");

                    b.ToTable("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
