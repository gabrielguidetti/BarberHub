using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Migrations
{
    /// <inheritdoc />
    public partial class Marked_services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MARKED_SERVICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARKED_SERVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MARKED_SERVICES_SERVICES_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "SERVICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MARKED_SERVICES_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MARKED_SERVICES_ServiceId",
                table: "MARKED_SERVICES",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MARKED_SERVICES_UserId",
                table: "MARKED_SERVICES",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MARKED_SERVICES");
        }
    }
}
