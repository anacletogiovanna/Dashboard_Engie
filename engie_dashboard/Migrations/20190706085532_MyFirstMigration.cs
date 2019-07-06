using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace engie_dashboard.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TipoSolicitacao = table.Column<int>(nullable: false),
                    Usina = table.Column<string>(nullable: true),
                    UG = table.Column<string>(nullable: true),
                    HoraSolicitacao = table.Column<DateTime>(nullable: false),
                    OperadorId = table.Column<string>(nullable: true),
                    VerificadorId = table.Column<string>(nullable: true),
                    EncaminhadoId = table.Column<string>(nullable: true),
                    StatusSolicitacao = table.Column<int>(nullable: false),
                    EstadoOperacional = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSolicitacao",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SolicitacaoId = table.Column<string>(nullable: true),
                    HoraModificacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSolicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoSolicitacao_Solicitacao_SolicitacaoId",
                        column: x => x.SolicitacaoId,
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSolicitacao_SolicitacaoId",
                table: "HistoricoSolicitacao",
                column: "SolicitacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoSolicitacao");

            migrationBuilder.DropTable(
                name: "Solicitacao");
        }
    }
}
