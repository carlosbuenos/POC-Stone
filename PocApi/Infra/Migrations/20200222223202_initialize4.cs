using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initialize4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_codPagamento",
                table: "Pagamentos");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_rastreio",
                table: "Pagamentos",
                column: "rastreio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_rastreio",
                table: "Pagamentos");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_codPagamento",
                table: "Pagamentos",
                column: "codPagamento");
        }
    }
}
