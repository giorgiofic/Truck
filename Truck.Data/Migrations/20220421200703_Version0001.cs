using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Truck.Data.Migrations
{
    public partial class Version0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelTruck",
                columns: table => new
                {
                    IdModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTruck", x => x.IdModel);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    IdTruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdModel = table.Column<int>(type: "int", nullable: false),
                    YearFabrication = table.Column<int>(type: "int", nullable: false),
                    YearModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.IdTruck);
                    table.ForeignKey(
                        name: "FK_Truck_ModelTruck_IdModel",
                        column: x => x.IdModel,
                        principalTable: "ModelTruck",
                        principalColumn: "IdModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModelTruck",
                columns: new[] { "IdModel", "Model" },
                values: new object[] { 1, "FH" });

            migrationBuilder.InsertData(
                table: "ModelTruck",
                columns: new[] { "IdModel", "Model" },
                values: new object[] { 2, "FM" });

            migrationBuilder.InsertData(
                table: "ModelTruck",
                columns: new[] { "IdModel", "Model" },
                values: new object[] { 3, "Outer" });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_IdModel",
                table: "Truck",
                column: "IdModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "ModelTruck");
        }
    }
}
