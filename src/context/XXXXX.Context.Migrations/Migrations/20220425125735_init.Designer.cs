﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using XXXXX.Context.Core;
using XXXXX.Context.Core.DTOs;

namespace XXXXX.Context.Migrations.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220425125735_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.ApplicationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdminHost")
                        .HasColumnType("text");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("ShellHost")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.OrganisationTypePermissionDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OrganisationTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("OrganisationTypePermissions");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.PermissionCategoryDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("LabelDefault")
                        .HasColumnType("text");

                    b.Property<string>("Prefix")
                        .HasColumnType("text");

                    b.Property<List<TranslationPermissionCategoryDTO>>("Translations")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("PermissionCategories");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.PermissionDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("LabelDefault")
                        .HasColumnType("text");

                    b.Property<List<TranslationPermissionDTO>>("Translations")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.RolePermissionDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.RouteDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("DrawerCategory")
                        .HasColumnType("text");

                    b.Property<string>("DrawerIcon")
                        .HasColumnType("text");

                    b.Property<string>("DrawerLabelDefault")
                        .HasColumnType("text");

                    b.Property<bool>("Exact")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<bool>("ShowOnDrawer")
                        .HasColumnType("boolean");

                    b.Property<List<TranslationRouteDTO>>("Translations")
                        .HasColumnType("jsonb");

                    b.Property<string>("Uri")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.TranslationDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean");

                    b.Property<string>("ValueDefault")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.OrganisationTypePermissionDTO", b =>
                {
                    b.HasOne("XXXXX.Context.Core.DTOs.PermissionDTO", "Permission")
                        .WithMany("OrganisationTypePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.RolePermissionDTO", b =>
                {
                    b.HasOne("XXXXX.Context.Core.DTOs.PermissionDTO", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("XXXXX.Context.Core.DTOs.PermissionDTO", b =>
                {
                    b.Navigation("OrganisationTypePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}