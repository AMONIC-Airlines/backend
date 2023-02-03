﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230203195140_RemoveAvailableSpaces")]
    partial class RemoveAvailableSpaces
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_unicode_ci")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Database.Models.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("BusinessSeats")
                        .HasColumnType("int(11)");

                    b.Property<int>("EconomySeats")
                        .HasColumnType("int(11)");

                    b.Property<string>("MakeModel")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("aircrafts", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("CountryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("CountryID");

                    b.Property<string>("Iatacode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("IATACode");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CountryId" }, "FK_AirPort_Country");

                    b.ToTable("airports", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Cabintype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("cabintypes", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("countries", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("CountryID");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CountryId" }, "FK_Office_Country");

                    b.ToTable("offices", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("roles", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ArrivalAirportID");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int(11)")
                        .HasColumnName("DepartureAirportID");

                    b.Property<int>("Distance")
                        .HasColumnType("int(11)");

                    b.Property<int>("FlightTime")
                        .HasColumnType("int(11)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DepartureAirportId" }, "FK_Routes_Airports2");

                    b.HasIndex(new[] { "ArrivalAirportId" }, "FK_Routes_Airports3");

                    b.ToTable("routes", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<int>("AircraftId")
                        .HasColumnType("int(11)")
                        .HasColumnName("AircraftID");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("EconomyPrice")
                        .HasColumnType("double");

                    b.Property<string>("FlightNumber")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int(11)")
                        .HasColumnName("RouteID");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AircraftId" }, "FK_Schedule_AirCraft");

                    b.HasIndex(new[] { "RouteId" }, "FK_Schedule_Routes");

                    b.ToTable("schedules", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("BookingReference")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<int>("CabinTypeId")
                        .HasColumnType("int(11)")
                        .HasColumnName("CabinTypeID");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PassportCountryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("PassportCountryID");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ScheduleID");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("UserID");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ScheduleId" }, "FK_Ticket_Schedule");

                    b.HasIndex(new[] { "CabinTypeId" }, "FK_Ticket_TravelClass");

                    b.HasIndex(new[] { "UserId" }, "FK_Ticket_User");

                    b.ToTable("tickets", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<bool?>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly?>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int(11)")
                        .HasColumnName("OfficeID");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("RoleID");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "OfficeId" }, "FK_Users_Offices");

                    b.HasIndex(new[] { "RoleId" }, "FK_Users_Roles");

                    b.ToTable("users", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb3");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb3_bin");
                });

            modelBuilder.Entity("Database.Models.Airport", b =>
                {
                    b.HasOne("Database.Models.Country", "Country")
                        .WithMany("Airports")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_AirPort_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Database.Models.Office", b =>
                {
                    b.HasOne("Database.Models.Country", "Country")
                        .WithMany("Offices")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_Office_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Database.Models.Route", b =>
                {
                    b.HasOne("Database.Models.Airport", "ArrivalAirport")
                        .WithMany("RouteArrivalAirports")
                        .HasForeignKey("ArrivalAirportId")
                        .IsRequired()
                        .HasConstraintName("FK_Routes_Airports3");

                    b.HasOne("Database.Models.Airport", "DepartureAirport")
                        .WithMany("RouteDepartureAirports")
                        .HasForeignKey("DepartureAirportId")
                        .IsRequired()
                        .HasConstraintName("FK_Routes_Airports2");

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("Database.Models.Schedule", b =>
                {
                    b.HasOne("Database.Models.Aircraft", "Aircraft")
                        .WithMany("Schedules")
                        .HasForeignKey("AircraftId")
                        .IsRequired()
                        .HasConstraintName("FK_Schedule_AirCraft");

                    b.HasOne("Database.Models.Route", "Route")
                        .WithMany("Schedules")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK_Schedule_Routes");

                    b.Navigation("Aircraft");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Database.Models.Ticket", b =>
                {
                    b.HasOne("Database.Models.Cabintype", "CabinType")
                        .WithMany("Tickets")
                        .HasForeignKey("CabinTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_TravelClass");

                    b.HasOne("Database.Models.Schedule", "Schedule")
                        .WithMany("Tickets")
                        .HasForeignKey("ScheduleId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_Schedule");

                    b.HasOne("Database.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Ticket_User");

                    b.Navigation("CabinType");

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.HasOne("Database.Models.Office", "Office")
                        .WithMany("Users")
                        .HasForeignKey("OfficeId")
                        .HasConstraintName("FK_Users_Offices");

                    b.HasOne("Database.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.Navigation("Office");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Database.Models.Aircraft", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Database.Models.Airport", b =>
                {
                    b.Navigation("RouteArrivalAirports");

                    b.Navigation("RouteDepartureAirports");
                });

            modelBuilder.Entity("Database.Models.Cabintype", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Database.Models.Country", b =>
                {
                    b.Navigation("Airports");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("Database.Models.Office", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Database.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Database.Models.Route", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Database.Models.Schedule", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Database.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
