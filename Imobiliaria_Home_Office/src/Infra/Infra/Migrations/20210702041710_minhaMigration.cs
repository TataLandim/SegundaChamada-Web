using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class minhaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imoveis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    QtdDeQuartos = table.Column<int>(type: "int", nullable: false),
                    ValorDoAluguel = table.Column<decimal>(type: "decimal(10.2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imoveis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imoveis");
        }
    }
}
