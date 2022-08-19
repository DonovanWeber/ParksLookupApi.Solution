using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksLookup.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParkName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ParkDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StateName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "ParkDescription", "ParkName", "StateName" },
                values: new object[,]
                {
                    { 1, "wilderness recreations area atop a volcanic hot spot", "Yellowstone National Park", "Wyoming" },
                    { 2, "Inside California's Sierra Nevada mountains", "Yosemite National Park", "California" },
                    { 3, "Popular summer destination for mountaineering, hiking, backcountry camping and fishing", "Grand Teton National Park", "Wyoming" },
                    { 4, "Wide views of canyons revealing layered bands of red rock", "Grand Canyon National Park", "Arizona" },
                    { 5, "Glacier carved peaks and valleys running to the Canadian border", "Glacier National Park", "Montana" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
