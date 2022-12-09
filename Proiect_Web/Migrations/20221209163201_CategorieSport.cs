using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Web.Migrations
{
    public partial class CategorieSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieNume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieSport",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervareID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieSport", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieSport_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieSport_Rezervare_RezervareID",
                        column: x => x.RezervareID,
                        principalTable: "Rezervare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieSport_CategorieID",
                table: "CategorieSport",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieSport_RezervareID",
                table: "CategorieSport",
                column: "RezervareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieSport");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
