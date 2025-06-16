using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedBook.Migrations
{
    /// <inheritdoc />
    public partial class AddTableIndicator89 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_BearingIndicatorId",
                table: "Indicators",
                column: "BearingIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_CheckupId",
                table: "Indicators",
                column: "CheckupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
