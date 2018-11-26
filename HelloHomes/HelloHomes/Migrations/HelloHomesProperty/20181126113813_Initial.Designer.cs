﻿// <auto-generated />
using System;
using HelloHomes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelloHomes.Migrations.HelloHomesProperty
{
    [DbContext(typeof(HelloHomesPropertyContext))]
    [Migration("20181126113813_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelloHomes.Models.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovalComment")
                        .IsRequired();

                    b.Property<int>("ApprovalStatus");

                    b.Property<int>("Bedrooms");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte[]>("Image");

                    b.Property<string>("ImageContentType");

                    b.Property<long>("LandlordID");

                    b.Property<string>("LandlordName")
                        .IsRequired();

                    b.Property<string>("LandlordNumber")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("RentPerMonth");

                    b.HasKey("Id");

                    b.ToTable("Property");
                });
#pragma warning restore 612, 618
        }
    }
}
