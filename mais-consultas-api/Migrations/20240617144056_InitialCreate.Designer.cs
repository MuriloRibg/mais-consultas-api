﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mais_consultas_api.Data;

#nullable disable

namespace mais_consultas_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240617144056_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("mais_consultas_api.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LineOne")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LineTwo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_Patient")
                        .HasColumnType("int");

                    b.Property<int>("Id_Professional")
                        .HasColumnType("int");

                    b.Property<int>("Id_Provider")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Patient")
                        .IsUnique();

                    b.HasIndex("Id_Professional")
                        .IsUnique();

                    b.HasIndex("Id_Provider")
                        .IsUnique();

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Professional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_Provider")
                        .HasColumnType("int");

                    b.Property<int>("Id_Service")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Provider")
                        .IsUnique();

                    b.HasIndex("Id_Service")
                        .IsUnique();

                    b.ToTable("Professionals");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("Id_Address")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Address");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Appointment", b =>
                {
                    b.HasOne("mais_consultas_api.Models.Patient", "Patient")
                        .WithOne("Appointment")
                        .HasForeignKey("mais_consultas_api.Models.Appointment", "Id_Patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mais_consultas_api.Models.Professional", "Professional")
                        .WithOne("Appointment")
                        .HasForeignKey("mais_consultas_api.Models.Appointment", "Id_Professional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mais_consultas_api.Models.Provider", "Provider")
                        .WithOne("Appointment")
                        .HasForeignKey("mais_consultas_api.Models.Appointment", "Id_Provider")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Professional");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Professional", b =>
                {
                    b.HasOne("mais_consultas_api.Models.Provider", "Provider")
                        .WithOne("Professional")
                        .HasForeignKey("mais_consultas_api.Models.Professional", "Id_Provider")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mais_consultas_api.Models.Service", "Service")
                        .WithOne("Professional")
                        .HasForeignKey("mais_consultas_api.Models.Professional", "Id_Service")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Provider", b =>
                {
                    b.HasOne("mais_consultas_api.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("Id_Address")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("mais_consultas_api.Models.Patient", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("mais_consultas_api.Models.Professional", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("mais_consultas_api.Models.Provider", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();

                    b.Navigation("Professional")
                        .IsRequired();
                });

            modelBuilder.Entity("mais_consultas_api.Models.Service", b =>
                {
                    b.Navigation("Professional")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
