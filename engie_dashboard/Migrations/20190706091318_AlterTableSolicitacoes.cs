using Microsoft.EntityFrameworkCore.Migrations;

namespace engie_dashboard.Migrations
{
    public partial class AlterTableSolicitacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UnidadeMedida",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "Solicitacao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadeMedida",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Solicitacao");
        }
    }
}
