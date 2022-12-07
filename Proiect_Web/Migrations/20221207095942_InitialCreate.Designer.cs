﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Web.Data;

#nullable disable

namespace Proiect_Web.Migrations
{
    [DbContext(typeof(Proiect_WebContext))]
    [Migration("20221207095942_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Web.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Echipament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Monitor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrPersoane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Partie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tarif")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Rezervare");
                });
#pragma warning restore 612, 618
        }
    }
}
