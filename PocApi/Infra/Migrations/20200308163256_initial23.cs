using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    codPagamento = table.Column<string>(nullable: false),
                    tipoDePagamento = table.Column<string>(nullable: false),
                    valor = table.Column<double>(nullable: false),
                    statusPagamento = table.Column<string>(nullable: false),
                    dataPagamento = table.Column<DateTime>(nullable: false),
                    rastreio = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.codPagamento);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_rastreio",
                table: "Pagamentos",
                column: "rastreio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");
        }
    }
}
