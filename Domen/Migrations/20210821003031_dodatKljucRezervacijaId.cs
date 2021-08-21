using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class dodatKljucRezervacijaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija");

            migrationBuilder.AddColumn<int>(
                name: "RezervacijaId",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija",
                columns: new[] { "LetId", "KorisnikId", "RezervacijaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "RezervacijaId",
                table: "Rezervacija");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija",
                columns: new[] { "LetId", "KorisnikId" });
        }
    }
}
