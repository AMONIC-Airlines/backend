using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedAvailableSpaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "aircrafts",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         MakeModel = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         TotalSeats = table.Column<int>(type: "int(11)", nullable: false),
            //         EconomySeats = table.Column<int>(type: "int(11)", nullable: false),
            //         BusinessSeats = table.Column<int>(type: "int(11)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "cabintypes",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "countries",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "roles",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "airports",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         CountryID = table.Column<int>(type: "int(11)", nullable: false),
            //         IATACode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_AirPort_Country",
            //             column: x => x.CountryID,
            //             principalTable: "countries",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "offices",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         CountryID = table.Column<int>(type: "int(11)", nullable: false),
            //         Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Contact = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_Office_Country",
            //             column: x => x.CountryID,
            //             principalTable: "countries",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "routes",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         DepartureAirportID = table.Column<int>(type: "int(11)", nullable: false),
            //         ArrivalAirportID = table.Column<int>(type: "int(11)", nullable: false),
            //         Distance = table.Column<int>(type: "int(11)", nullable: false),
            //         FlightTime = table.Column<int>(type: "int(11)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_Routes_Airports2",
            //             column: x => x.DepartureAirportID,
            //             principalTable: "airports",
            //             principalColumn: "ID");
            //         table.ForeignKey(
            //             name: "FK_Routes_Airports3",
            //             column: x => x.ArrivalAirportID,
            //             principalTable: "airports",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "users",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         RoleID = table.Column<int>(type: "int(11)", nullable: false),
            //         Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         OfficeID = table.Column<int>(type: "int(11)", nullable: true),
            //         Birthdate = table.Column<DateOnly>(type: "date", nullable: true),
            //         Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_Users_Offices",
            //             column: x => x.OfficeID,
            //             principalTable: "offices",
            //             principalColumn: "ID");
            //         table.ForeignKey(
            //             name: "FK_Users_Roles",
            //             column: x => x.RoleID,
            //             principalTable: "roles",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateTable(
            //     name: "schedules",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         Date = table.Column<DateOnly>(type: "date", nullable: false),
            //         Time = table.Column<TimeOnly>(type: "time", nullable: false),
            //         AircraftID = table.Column<int>(type: "int(11)", nullable: false),
            //         RouteID = table.Column<int>(type: "int(11)", nullable: false),
            //         EconomyPrice = table.Column<double>(type: "double", nullable: false),
            //         Confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //         FlightNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_Schedule_AirCraft",
            //             column: x => x.AircraftID,
            //             principalTable: "aircrafts",
            //             principalColumn: "ID");
            //         table.ForeignKey(
            //             name: "FK_Schedule_Routes",
            //             column: x => x.RouteID,
            //             principalTable: "routes",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder
                .CreateTable(
                    name: "AvailableSpaces",
                    columns: table =>
                        new
                        {
                            ScheduleId = table.Column<int>(type: "int(11)", nullable: false),
                            OccipiedEconomSeats = table.Column<int>(type: "int", nullable: false),
                            OccupiedBusinesssSeats = table.Column<int>(
                                type: "int",
                                nullable: false
                            ),
                            OccupiedFirstClassSeats = table.Column<int>(
                                type: "int",
                                nullable: false
                            )
                        },
                    constraints: table =>
                    {
                        table.ForeignKey(
                            name: "FK_AvailableSpaces_schedules_ScheduleId",
                            column: x => x.ScheduleId,
                            principalTable: "schedules",
                            principalColumn: "ID",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            // migrationBuilder.CreateTable(
            //     name: "tickets",
            //     columns: table => new
            //     {
            //         ID = table.Column<int>(type: "int(11)", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         UserID = table.Column<int>(type: "int(11)", nullable: false),
            //         ScheduleID = table.Column<int>(type: "int(11)", nullable: false),
            //         CabinTypeID = table.Column<int>(type: "int(11)", nullable: false),
            //         Firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Phone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         PassportNumber = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         PassportCountryID = table.Column<int>(type: "int(11)", nullable: false),
            //         BookingReference = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "utf8mb3_bin")
            //             .Annotation("MySql:CharSet", "utf8mb3"),
            //         Confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.ID);
            //         table.ForeignKey(
            //             name: "FK_Ticket_Schedule",
            //             column: x => x.ScheduleID,
            //             principalTable: "schedules",
            //             principalColumn: "ID");
            //         table.ForeignKey(
            //             name: "FK_Ticket_TravelClass",
            //             column: x => x.CabinTypeID,
            //             principalTable: "cabintypes",
            //             principalColumn: "ID");
            //         table.ForeignKey(
            //             name: "FK_Ticket_User",
            //             column: x => x.UserID,
            //             principalTable: "users",
            //             principalColumn: "ID");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb3")
            //     .Annotation("Relational:Collation", "utf8mb3_bin");

            // migrationBuilder.CreateIndex(
            //     name: "FK_AirPort_Country",
            //     table: "airports",
            //     column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSpaces_ScheduleId",
                table: "AvailableSpaces",
                column: "ScheduleId"
            );

            // migrationBuilder.CreateIndex(
            //     name: "FK_Office_Country",
            //     table: "offices",
            //     column: "CountryID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Routes_Airports2",
            //     table: "routes",
            //     column: "DepartureAirportID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Routes_Airports3",
            //     table: "routes",
            //     column: "ArrivalAirportID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Schedule_AirCraft",
            //     table: "schedules",
            //     column: "AircraftID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Schedule_Routes",
            //     table: "schedules",
            //     column: "RouteID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Ticket_Schedule",
            //     table: "tickets",
            //     column: "ScheduleID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Ticket_TravelClass",
            //     table: "tickets",
            //     column: "CabinTypeID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Ticket_User",
            //     table: "tickets",
            //     column: "UserID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Users_Offices",
            //     table: "users",
            //     column: "OfficeID");

            // migrationBuilder.CreateIndex(
            //     name: "FK_Users_Roles",
            //     table: "users",
            //     column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AvailableSpaces");

            // migrationBuilder.DropTable(
            //     name: "tickets");

            // migrationBuilder.DropTable(
            //     name: "schedules");

            // migrationBuilder.DropTable(
            //     name: "cabintypes");

            // migrationBuilder.DropTable(
            //     name: "users");

            // migrationBuilder.DropTable(
            //     name: "aircrafts");

            // migrationBuilder.DropTable(
            //     name: "routes");

            // migrationBuilder.DropTable(
            //     name: "offices");

            // migrationBuilder.DropTable(
            //     name: "roles");

            // migrationBuilder.DropTable(
            //     name: "airports");

            // migrationBuilder.DropTable(
            //     name: "countries");
        }
    }
}
