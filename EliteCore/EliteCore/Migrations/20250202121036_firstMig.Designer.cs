﻿// <auto-generated />
using EliteCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EliteCore.Migrations
{
    [DbContext(typeof(EliteDbContext))]
    [Migration("20250202121036_firstMig")]
    partial class firstMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EliteCore.Models.GelenMail", b =>
                {
                    b.Property<int>("GelenMailKod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GelenMailKod"));

                    b.Property<string>("Ad")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("GelenMesaj")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("KullaniciMail")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Soyad")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("GelenMailKod");

                    b.HasIndex("GelenMailKod")
                        .IsUnique();

                    b.ToTable("GelenMailler");
                });
#pragma warning restore 612, 618
        }
    }
}
