using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAyure.Data.Migrations
{
    public partial class ConfiguraUsuariosPerfilesRelacion_2_26012022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfiles_perfilesId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_perfilesId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "perfilesId",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_perfilId",
                table: "Usuarios",
                column: "perfilId");

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

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_perfilId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "perfilesId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_perfilesId",
                table: "Usuarios",
                column: "perfilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfiles_perfilesId",
                table: "Usuarios",
                column: "perfilesId",
                principalTable: "Perfiles",
                principalColumn: "Id");
        }
    }
}
