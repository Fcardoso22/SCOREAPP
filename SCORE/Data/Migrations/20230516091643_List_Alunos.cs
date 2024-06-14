using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class List_Alunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaIdTurma",
                table: "Aluno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TurmaIdTurma",
                table: "Aluno",
                column: "TurmaIdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaIdTurma",
                table: "Aluno",
                column: "TurmaIdTurma",
                principalTable: "Turma",
                principalColumn: "Id_Turma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaIdTurma",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_TurmaIdTurma",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "TurmaIdTurma",
                table: "Aluno");
        }
    }
}
