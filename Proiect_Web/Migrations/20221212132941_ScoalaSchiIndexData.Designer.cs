﻿// <auto-generated />
using System;
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
    [Migration("20221212132941_ScoalaSchiIndexData")]
    partial class ScoalaSchiIndexData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Web.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategorieNume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Proiect_Web.Models.CategorieSport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("RezervareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("RezervareID");

                    b.ToTable("CategorieSport");
                });

            modelBuilder.Entity("Proiect_Web.Models.Monitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Monitor");
                });

            modelBuilder.Entity("Proiect_Web.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataProgramare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Echipament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonitorID")
                        .HasColumnType("int");

                    b.Property<string>("NrPersoane")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Partie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ScoalaSchiID")
                        .HasColumnType("int");

                    b.Property<decimal>("Tarif")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("MonitorID");

                    b.HasIndex("ScoalaSchiID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("Proiect_Web.Models.ScoalaSchi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeScoalaSchi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ScoalaSchi");
                });

            modelBuilder.Entity("Proiect_Web.Models.CategorieSport", b =>
                {
                    b.HasOne("Proiect_Web.Models.Categorie", "Categorie")
                        .WithMany("CategoriiSport")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Web.Models.Rezervare", "Rezervare")
                        .WithMany("CategorieSport")
                        .HasForeignKey("RezervareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Rezervare");
                });

            modelBuilder.Entity("Proiect_Web.Models.Rezervare", b =>
                {
                    b.HasOne("Proiect_Web.Models.Monitor", "Monitor")
                        .WithMany("Rezervari")
                        .HasForeignKey("MonitorID");

                    b.HasOne("Proiect_Web.Models.ScoalaSchi", "ScoalaSchi")
                        .WithMany("Rezervari")
                        .HasForeignKey("ScoalaSchiID");

                    b.Navigation("Monitor");

                    b.Navigation("ScoalaSchi");
                });

            modelBuilder.Entity("Proiect_Web.Models.Categorie", b =>
                {
                    b.Navigation("CategoriiSport");
                });

            modelBuilder.Entity("Proiect_Web.Models.Monitor", b =>
                {
                    b.Navigation("Rezervari");
                });

            modelBuilder.Entity("Proiect_Web.Models.Rezervare", b =>
                {
                    b.Navigation("CategorieSport");
                });

            modelBuilder.Entity("Proiect_Web.Models.ScoalaSchi", b =>
                {
                    b.Navigation("Rezervari");
                });
#pragma warning restore 612, 618
        }
    }
}
