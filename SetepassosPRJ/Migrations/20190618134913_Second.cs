using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SetepassosPRJ.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    NomeEquipa = table.Column<string>(nullable: true),
                    NomeMembroEquipa = table.Column<string>(nullable: true),
                    NrAlunoMembroEquipa = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
