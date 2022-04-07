﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoAyure.Data.Contexto;

#nullable disable

namespace ProyectoAyure.Data.Migrations
{
    [DbContext(typeof(AyureDbContext))]
    [Migration("20220205230111_Fixes02052022")]
    partial class Fixes02052022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.Perfiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("NombrePerfil")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.UsuarioAcceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Constraseña")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UsuarioAcceso");
                });

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Telefono1")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Telefono2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("perfilId")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioAccesoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("perfilId");

                    b.HasIndex("usuarioAccesoId")
                        .IsUnique()
                        .HasFilter("[usuarioAccesoId] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.Usuarios", b =>
                {
                    b.HasOne("ProyectoAyure.Data.Entidades.Perfiles", "perfiles")
                        .WithMany("usuarios")
                        .HasForeignKey("perfilId");

                    b.HasOne("ProyectoAyure.Data.Entidades.UsuarioAcceso", "usuarioAcceso")
                        .WithOne("usuarios")
                        .HasForeignKey("ProyectoAyure.Data.Entidades.Usuarios", "usuarioAccesoId");

                    b.Navigation("perfiles");

                    b.Navigation("usuarioAcceso");
                });

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.Perfiles", b =>
                {
                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("ProyectoAyure.Data.Entidades.UsuarioAcceso", b =>
                {
                    b.Navigation("usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
