using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAyure.Data.Migrations
{
    public partial class _2nd_Fixes02052022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "UsuarioAcceso",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "UsuarioAcceso");
        }
    }
}
