using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAyure.Data.Migrations
{
    public partial class PerfilyRelacionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "perfilId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePerfil = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_perfilId",
                table: "Usuarios",
                column: "perfilId",
                unique: true,
                filter: "[perfilId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfiles_perfilId",
                table: "Usuarios",
                column: "perfilId",
                principalTable: "Perfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfiles_perfilId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_perfilId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "perfilId",
                table: "Usuarios");
        }
    }
}
