using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebaNexos.Migrations
{
    public partial class pruebaNexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDoctores",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "idPacientes",
                table: "Citas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idDoctores",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idPacientes",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
