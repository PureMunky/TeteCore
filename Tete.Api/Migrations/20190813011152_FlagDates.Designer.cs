﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tete.Api.Contexts;

namespace Tete.Api.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20190813011152_FlagDates")]
    partial class FlagDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tete.Models.Config.Flag", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Data")
                        .HasMaxLength(200);

                    b.Property<DateTime>("Modified");

                    b.Property<bool>("Value");

                    b.HasKey("Key");

                    b.ToTable("Flags");
                });

            modelBuilder.Entity("Tete.Models.Config.Setting", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<string>("Value")
                        .HasMaxLength(100);

                    b.HasKey("Key");

                    b.ToTable("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
