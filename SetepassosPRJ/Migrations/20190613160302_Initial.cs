using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SetepassosPRJ.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Nome = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    ResultadoFinal = table.Column<int>(nullable: false),
                    Chave = table.Column<bool>(nullable: false),
                    InimigosVencidos = table.Column<int>(nullable: false),
                    FugasInimigos = table.Column<int>(nullable: false),
                    InvestigacoesArea = table.Column<int>(nullable: false),
                    IntensEcontrados = table.Column<int>(nullable: false),
                    PocoesUsadas = table.Column<int>(nullable: false),
                    PocoesTotal = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
