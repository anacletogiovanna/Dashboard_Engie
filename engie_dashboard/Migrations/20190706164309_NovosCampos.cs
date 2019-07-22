using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace engie_dashboard.Migrations
{
    public partial class NovosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerificadorId",
                table: "Solicitacao",
                newName: "VazaoVertida");

            migrationBuilder.RenameColumn(
                name: "HoraSolicitacao",
                table: "Solicitacao",
                newName: "Data");

            migrationBuilder.AlterColumn<string>(
                name: "OperadorId",
                table: "Solicitacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoOperacional",
                table: "Solicitacao",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "EncaminhadoId",
                table: "Solicitacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Chuva",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComandoDePotencia",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NivelDeReservatorio",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precipitacao",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolicitanteId",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDePotencia",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VazaoAfluente",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VazaoDefluente",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VazaoTurbinada",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comando",
                table: "HistoricoSolicitacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusSolicitacao",
                table: "HistoricoSolicitacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NomeCompleto = table.Column<string>(nullable: true),
                    Empresa = table.Column<int>(nullable: false),
                    Profile = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_EncaminhadoId",
                table: "Solicitacao",
                column: "EncaminhadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_OperadorId",
                table: "Solicitacao",
                column: "OperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SolicitanteId",
                table: "Solicitacao",
                column: "SolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Usuario_EncaminhadoId",
                table: "Solicitacao",
                column: "EncaminhadoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Usuario_OperadorId",
                table: "Solicitacao",
                column: "OperadorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Usuario_SolicitanteId",
                table: "Solicitacao",
                column: "SolicitanteId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Usuario_EncaminhadoId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Usuario_OperadorId",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Usuario_SolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_EncaminhadoId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_OperadorId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_SolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Chuva",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "ComandoDePotencia",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "NivelDeReservatorio",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Precipitacao",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "SolicitanteId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "TipoDePotencia",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "VazaoAfluente",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "VazaoDefluente",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "VazaoTurbinada",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "Comando",
                table: "HistoricoSolicitacao");

            migrationBuilder.DropColumn(
                name: "StatusSolicitacao",
                table: "HistoricoSolicitacao");

            migrationBuilder.RenameColumn(
                name: "VazaoVertida",
                table: "Solicitacao",
                newName: "VerificadorId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Solicitacao",
                newName: "HoraSolicitacao");

            migrationBuilder.AlterColumn<string>(
                name: "OperadorId",
                table: "Solicitacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstadoOperacional",
                table: "Solicitacao",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EncaminhadoId",
                table: "Solicitacao",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
