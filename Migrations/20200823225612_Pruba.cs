using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebaNexos.Migrations
{
    public partial class Pruba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Doctores_Doctoresid",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_Pacientesid",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_Doctoresid",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_Pacientesid",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Doctoresid",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Pacientesid",
                table: "Citas");

            migrationBuilder.AddColumn<string>(
                name: "Doctores",
                table: "Citas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pacientes",
                table: "Citas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctores",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Pacientes",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "Doctoresid",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pacientesid",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Doctoresid",
                table: "Citas",
                column: "Doctoresid");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Pacientesid",
                table: "Citas",
                column: "Pacientesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Doctores_Doctoresid",
                table: "Citas",
                column: "Doctoresid",
                principalTable: "Doctores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_Pacientesid",
                table: "Citas",
                column: "Pacientesid",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
