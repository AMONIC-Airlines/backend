using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class NewAvailableSpaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ScheduleId = table.Column<int>(type: "int(11)", nullable: false),
                    OccipiedEconomSeats = table.Column<int>(type: "int", nullable: true),
                    OccupiedBusinesssSeats = table.Column<int>(type: "int", nullable: true),
                    OccupiedFirstClassSeats = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableSpaces_schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "schedules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSpaces_ScheduleId",
                table: "AvailableSpaces",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSpaces");
        }
    }
}
