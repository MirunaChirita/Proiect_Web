using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Web.Migrations
{
    public partial class Monitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monitor",
                table: "Rezervare");

            migrationBuilder.AddColumn<int>(
                name: "MonitorID",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoalaSchiID",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScoalaSchi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeScoalaSchi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoalaSchi", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_MonitorID",
                table: "Rezervare",
                column: "MonitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ScoalaSchiID",
                table: "Rezervare",
                column: "ScoalaSchiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Monitor_MonitorID",
                table: "Rezervare",
                column: "MonitorID",
                principalTable: "Monitor",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_ScoalaSchi_ScoalaSchiID",
                table: "Rezervare",
                column: "ScoalaSchiID",
                principalTable: "ScoalaSchi",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Monitor_MonitorID",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_ScoalaSchi_ScoalaSchiID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "ScoalaSchi");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_MonitorID",
                table: "Rezervare");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_ScoalaSchiID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "MonitorID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "ScoalaSchiID",
                table: "Rezervare");

            migrationBuilder.AddColumn<string>(
                name: "Monitor",
                table: "Rezervare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
