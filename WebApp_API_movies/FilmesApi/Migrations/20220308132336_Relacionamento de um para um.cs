using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesApi.Migrations
{
    public partial class Relacionamentodeumparaum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Cinema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_EnderecoId",
                table: "Cinema",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Endereco_EnderecoId",
                table: "Cinema",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Endereco_EnderecoId",
                table: "Cinema");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_EnderecoId",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Cinema");
        }
    }
}
