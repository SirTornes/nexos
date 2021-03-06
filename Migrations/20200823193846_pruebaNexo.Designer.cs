﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pruebaNexos.Models;

namespace pruebaNexos.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200823193846_pruebaNexo")]
    partial class pruebaNexo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("pruebaNexos.Models.Citas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Doctoresid")
                        .HasColumnType("int");

                    b.Property<int?>("Pacientesid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Doctoresid");

                    b.HasIndex("Pacientesid");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("pruebaNexos.Models.Doctores", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("doc_cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doc_especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doc_hospital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doc_nombre_completo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doc_num_credencial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("pruebaNexos.Models.Pacientes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("pac_cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_cod_postal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_nombre_completo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_num_seguro_social")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pac_telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("pruebaNexos.Models.Citas", b =>
                {
                    b.HasOne("pruebaNexos.Models.Doctores", "Doctores")
                        .WithMany("Citas")
                        .HasForeignKey("Doctoresid");

                    b.HasOne("pruebaNexos.Models.Pacientes", "Pacientes")
                        .WithMany("Citas")
                        .HasForeignKey("Pacientesid");
                });
#pragma warning restore 612, 618
        }
    }
}
