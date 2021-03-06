﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LicencePlateApp.Entities;

namespace LicencePlateApp.Migrations
{
    [DbContext(typeof(LicencePlateContext))]
    [Migration("20171117085533_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LicencePlateApp.Models.LicencePlate", b =>
                {
                    b.Property<string>("Plate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Car_brand");

                    b.Property<string>("Car_model");

                    b.Property<string>("Color");

                    b.Property<int>("Year");

                    b.HasKey("Plate");

                    b.ToTable("Licence_plates");
                });
        }
    }
}
