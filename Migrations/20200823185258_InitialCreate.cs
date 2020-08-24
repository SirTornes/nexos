using Microsoft.EntityFrameworkCore.Migrations;

namespace pruebaNexos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doc_cedula = table.Column<string>(nullable: true),
                    doc_nombre_completo = table.Column<string>(nullable: true),
                    doc_especialidad = table.Column<string>(nullable: true),
                    doc_num_credencial = table.Column<string>(nullable: true),
                    doc_hospital = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pac_cedula = table.Column<string>(nullable: true),
                    pac_nombre_completo = table.Column<string>(nullable: true),
                    pac_num_seguro_social = table.Column<string>(nullable: true),
                    pac_cod_postal = table.Column<string>(nullable: true),
                    pac_telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPacientes = table.Column<int>(nullable: false),
                    Pacientesid = table.Column<int>(nullable: true),
                    idDoctores = table.Column<int>(nullable: false),
                    Doctoresid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Citas_Doctores_Doctoresid",
                        column: x => x.Doctoresid,
                        principalTable: "Doctores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_Pacientesid",
                        column: x => x.Pacientesid,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Doctoresid",
                table: "Citas",
                column: "Doctoresid");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_Pacientesid",
                table: "Citas",
                column: "Pacientesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
