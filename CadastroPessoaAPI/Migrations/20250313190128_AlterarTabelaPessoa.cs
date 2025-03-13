using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroPessoaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterarTabelaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pessoas",
                newName: "Sexo");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "Pessoas",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pessoas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
