using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube1.HelloNVC.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciDersleriTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrneciDersleri",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false),
                    Dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOgrneciDersleri", x => new { x.Ogrenciid, x.Dersid });
                    table.ForeignKey(
                        name: "FK_tblOgrneciDersleri_tblDersler_Dersid",
                        column: x => x.Dersid,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOgrneciDersleri_tblOgrenciler_Ogrenciid",
                        column: x => x.Ogrenciid,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOgrneciDersleri_Dersid",
                table: "tblOgrneciDersleri",
                column: "Dersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrneciDersleri");
        }
    }
}
