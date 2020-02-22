using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initialize3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_codPagamento",
                table: "Pagamentos",
                column: "codPagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_codPagamento",
                table: "Pagamentos");
        }
    }
}
