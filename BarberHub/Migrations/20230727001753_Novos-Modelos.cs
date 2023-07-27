using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberHub.Migrations
{
    /// <inheritdoc />
    public partial class NovosModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BARBER_SHOPS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARBER_SHOPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BARBER_SHOPS_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BARBERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartWorkTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishWorkTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BarberShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARBERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BARBERS_BARBER_SHOPS_BarberShopId",
                        column: x => x.BarberShopId,
                        principalTable: "BARBER_SHOPS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SERVICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    BarberShopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SERVICES_BARBER_SHOPS_BarberShopId",
                        column: x => x.BarberShopId,
                        principalTable: "BARBER_SHOPS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BARBER_SERVICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    BarberId = table.Column<int>(type: "int", nullable: false),
                    TimeSpent = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BARBER_SERVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BARBER_SERVICES_BARBERS_BarberId",
                        column: x => x.BarberId,
                        principalTable: "BARBERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BARBER_SERVICES_SERVICES_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "SERVICES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BARBER_SERVICES_BarberId",
                table: "BARBER_SERVICES",
                column: "BarberId");

            migrationBuilder.CreateIndex(
                name: "IX_BARBER_SERVICES_ServiceId",
                table: "BARBER_SERVICES",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BARBER_SHOPS_UserId",
                table: "BARBER_SHOPS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BARBERS_BarberShopId",
                table: "BARBERS",
                column: "BarberShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICES_BarberShopId",
                table: "SERVICES",
                column: "BarberShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BARBER_SERVICES");

            migrationBuilder.DropTable(
                name: "BARBERS");

            migrationBuilder.DropTable(
                name: "SERVICES");

            migrationBuilder.DropTable(
                name: "BARBER_SHOPS");
        }
    }
}
