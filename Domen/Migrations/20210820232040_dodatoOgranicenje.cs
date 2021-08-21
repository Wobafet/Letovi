using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class dodatoOgranicenje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrojMesta",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "NotLessThenZero",
                table: "Let",
                sql: "[BrojMesta] >= 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "NotLessThenZero",
                table: "Let");

            migrationBuilder.DropColumn(
                name: "BrojMesta",
                table: "Rezervacija");
        }
    }
}
