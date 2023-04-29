﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230429072126_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicketManagement.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastNodifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7353-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Plays"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Conferences"
                        });
                });

            modelBuilder.Entity("TicketManagement.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Artist")
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastNodifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e88"),
                            Artist = "John Egbert",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 10, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8078),
                            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerised the worls with his banjo",
                            ImageUrl = "https://images.unsplash.com/photo-1533174072545-7a4b6ad7a6c3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                            Name = "John Egbert Live",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("ee57ff8b-6a96-4eb6-8625-eb4be2d84e88"),
                            Artist = "Dj Neptune",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 12, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8235),
                            Description = "DJs from all over the world will compete in this epic battle for the Sound King",
                            ImageUrl = "https://images.unsplash.com/photo-1526979118433-63c7344f06f1?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                            Name = "Clash of the Dj",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("fa576f8b-6a8a-4ee6-8635-eb4be2d84e88"),
                            Artist = "Michael Jackson",
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2024, 2, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8258),
                            Description = "Micael Jackson doesn't need an introduction. His 25 concert across the global last year were seen by thousands. Can we add you to the list?",
                            ImageUrl = "https://images.unsplash.com/photo-1577640905050-83665af216b9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
                            Name = "The state of Affairs: Michael Live!",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("ef236f8b-788a-4e6d-8635-eb4be2d84e88"),
                            Artist = "Mauel Santinonsi",
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 8, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8273),
                            Description = "The best tech conference in the world!",
                            ImageUrl = "https://images.unsplash.com/photo-1577640905050-83665af216b9?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80",
                            Name = "Spanish guitar hits woth Manuel",
                            Price = 25
                        },
                        new
                        {
                            EventId = new Guid("98ac6f8b-6a8a-46d6-8635-eb4be2d84e88"),
                            Artist = "Nick Sailor",
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 12, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8286),
                            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravagance, written by Nick Sailor, the man from 'My Dad and Sister'",
                            ImageUrl = "https://images.unsplash.com/photo-1516450360452-9312f5e86fc7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80",
                            Name = "To The Moon And Back",
                            Price = 135
                        });
                });

            modelBuilder.Entity("TicketManagement.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastNodifiedBy")
                        .HasColumnType("text");

                    b.Property<bool>("OrderPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e45c6f8b-6e9a-46f6-8635-f6729ea54bba"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2023, 4, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8309),
                            OrderTotal = 400,
                            UserId = new Guid("abb57894-6e1a-aaf6-8635-f6729ea54bba")
                        },
                        new
                        {
                            Id = new Guid("86d3a045-34fd-4e4d-8635-ad129ea54bba"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2023, 4, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8326),
                            OrderTotal = 135,
                            UserId = new Guid("ac3cfaf5-34fd-4e4d-8635-ad1083ddc340")
                        },
                        new
                        {
                            Id = new Guid("7a1cca4b-066c-4ac7-b3df-f6729ea5e7e0"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2023, 4, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8338),
                            OrderTotal = 85,
                            UserId = new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c")
                        },
                        new
                        {
                            Id = new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2023, 4, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8350),
                            OrderTotal = 245,
                            UserId = new Guid("4ad901be-6e1a-46dd-8635-f6729ea54bba")
                        },
                        new
                        {
                            Id = new Guid("e6a2679c-80b1-4781-b5c0-6f4c91b405b6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderPaid = true,
                            OrderPlaced = new DateTime(2023, 4, 29, 8, 21, 26, 304, DateTimeKind.Local).AddTicks(8362),
                            OrderTotal = 142,
                            UserId = new Guid("7aeb2c01-6e1a-46dd-8635-330bdf950f5c")
                        });
                });

            modelBuilder.Entity("TicketManagement.Domain.Entities.Event", b =>
                {
                    b.HasOne("TicketManagement.Domain.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TicketManagement.Domain.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}