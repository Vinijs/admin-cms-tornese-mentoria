using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admin_cms.Migrations
{
    /// <inheritdoc />
    public partial class AddPaginas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paginas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    AreaRestrita = table.Column<bool>(type: "bit", nullable: false),
                    Login = table.Column<bool>(type: "bit", nullable: false),
                    Home = table.Column<bool>(type: "bit", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paginas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paginas");
        }
    }
}
