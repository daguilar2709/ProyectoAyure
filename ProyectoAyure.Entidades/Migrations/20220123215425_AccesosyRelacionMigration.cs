using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAyure.Data.Migrations
{
    public partial class AccesosyRelacionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioAccesoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioAcceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Constraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAcceso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_usuarioAccesoId",
                table: "Usuarios",
                column: "usuarioAccesoId",
                unique: true,
                filter: "[usuarioAccesoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_UsuarioAcceso_usuarioAccesoId",
                table: "Usuarios",
                column: "usuarioAccesoId",
                principalTable: "UsuarioAcceso",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_UsuarioAcceso_usuarioAccesoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "UsuarioAcceso");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_usuarioAccesoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "usuarioAccesoId",
                table: "Usuarios");
        }
    }
}
