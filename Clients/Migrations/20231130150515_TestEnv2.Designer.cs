﻿// <auto-generated />
using Clients.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clients.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231130150515_TestEnv2")]
    partial class TestEnv2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clients.Models.Pass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarroMarca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarroModelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarroPlaca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataHoraEntrada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataHoraSaida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Garagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecoTotal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passes");
                });
#pragma warning restore 612, 618
        }
    }
}
