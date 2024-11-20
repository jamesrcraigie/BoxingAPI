using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boxers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredGymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxers_Gyms_RegisteredGymId",
                        column: x => x.RegisteredGymId,
                        principalTable: "Gyms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerBoxerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoserBoxerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fights_Boxers_LoserBoxerId",
                        column: x => x.LoserBoxerId,
                        principalTable: "Boxers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fights_Boxers_WinnerBoxerId",
                        column: x => x.WinnerBoxerId,
                        principalTable: "Boxers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxers_RegisteredGymId",
                table: "Boxers",
                column: "RegisteredGymId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_LoserBoxerId",
                table: "Fights",
                column: "LoserBoxerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_WinnerBoxerId",
                table: "Fights",
                column: "WinnerBoxerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Boxers");

            migrationBuilder.DropTable(
                name: "Gyms");
        }
    }
}
