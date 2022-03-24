using Microsoft.EntityFrameworkCore.Migrations;

namespace Porto.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliente = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    numContainer = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    typeContainer = table.Column<int>(type: "INT", nullable: false),
                    statusContainer = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    categoryContainer = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeMovement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInitial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourInitial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFinish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourFinish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Movements");
        }
    }
}
