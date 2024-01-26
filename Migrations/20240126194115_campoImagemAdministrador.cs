using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin_cms.Migrations
{
    /// <inheritdoc />
    public partial class campoImagemAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Administradores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Administradores");
        }
    }
}
