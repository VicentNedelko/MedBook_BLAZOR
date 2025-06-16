using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedBook.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckupsIndicators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Laboratory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkups_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    BearingIndicatorId = table.Column<int>(type: "int", nullable: false),
                    CheckupId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ReferenceMax = table.Column<double>(type: "float", nullable: true),
                    ReferenceMin = table.Column<double>(type: "float", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indicators_BearingIndicators_BearingIndicatorId",
                        column: x => x.BearingIndicatorId,
                        principalTable: "BearingIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indicators_Checkups_CheckupId",
                        column: x => x.CheckupId,
                        principalTable: "Checkups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_PatientId",
                table: "Checkups",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_BearingIndicatorId",
                table: "Indicators",
                column: "BearingIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_CheckupId",
                table: "Indicators",
                column: "CheckupId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_PatientId",
                table: "Indicators",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Checkups");
        }
    }
}
