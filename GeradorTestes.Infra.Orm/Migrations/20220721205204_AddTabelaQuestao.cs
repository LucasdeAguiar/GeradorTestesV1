using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeradorTestes.Infra.Orm.Migrations
{
    public partial class AddTabelaQuestao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBMateria_TBDisciplina_DisciplinaId",
                table: "TBMateria");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinaId",
                table: "TBMateria",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TBQuestao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enunciado = table.Column<string>(type: "varchar(500)", nullable: false),
                    MateriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBQuestao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBQuestao_TBMateria_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "TBMateria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBAlternativa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Correta = table.Column<bool>(type: "bit", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    QuestaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resposta = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAlternativa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAlternativa_TBQuestao",
                        column: x => x.QuestaoId,
                        principalTable: "TBQuestao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAlternativa_QuestaoId",
                table: "TBAlternativa",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBQuestao_MateriaId",
                table: "TBQuestao",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMateria_TBDisciplina_DisciplinaId",
                table: "TBMateria",
                column: "DisciplinaId",
                principalTable: "TBDisciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBMateria_TBDisciplina_DisciplinaId",
                table: "TBMateria");

            migrationBuilder.DropTable(
                name: "TBAlternativa");

            migrationBuilder.DropTable(
                name: "TBQuestao");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinaId",
                table: "TBMateria",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMateria_TBDisciplina_DisciplinaId",
                table: "TBMateria",
                column: "DisciplinaId",
                principalTable: "TBDisciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
