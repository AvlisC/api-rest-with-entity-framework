using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesApi.Migrations
{
    public partial class Relacionamentodeumparamuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "Cinema",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinema_GerenteId",
                table: "Cinema",
                column: "GerenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinema_Gerente_GerenteId",
                table: "Cinema",
                column: "GerenteId",
                principalTable: "Gerente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinema_Gerente_GerenteId",
                table: "Cinema");

            migrationBuilder.DropIndex(
                name: "IX_Cinema_GerenteId",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Cinema");
        }
    }
}
