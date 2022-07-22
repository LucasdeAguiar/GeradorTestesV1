using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeradorTestes.Infra.Orm.Migrations
{
    public partial class AddTabelaMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TBDisciplina",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TBMateria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Serie = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBMateria_TBDisciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "TBDisciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBMateria_DisciplinaId",
                table: "TBMateria",
                column: "DisciplinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBMateria");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TBDisciplina",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
