using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurmaUc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurmaIdTurma",
                table: "Turma_UC",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UcIdUc",
                table: "Turma_UC",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turma_UC_TurmaIdTurma",
                table: "Turma_UC",
                column: "TurmaIdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_UC_UcIdUc",
                table: "Turma_UC",
                column: "UcIdUc");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_UC_Turma_TurmaIdTurma",
                table: "Turma_UC",
                column: "TurmaIdTurma",
                principalTable: "Turma",
                principalColumn: "Id_Turma");

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_UC_UC_UcIdUc",
                table: "Turma_UC",
                column: "UcIdUc",
                principalTable: "UC",
                principalColumn: "Id_UC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_UC_Turma_TurmaIdTurma",
                table: "Turma_UC");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_UC_UC_UcIdUc",
                table: "Turma_UC");

            migrationBuilder.DropIndex(
                name: "IX_Turma_UC_TurmaIdTurma",
                table: "Turma_UC");

            migrationBuilder.DropIndex(
                name: "IX_Turma_UC_UcIdUc",
                table: "Turma_UC");

            migrationBuilder.DropColumn(
                name: "TurmaIdTurma",
                table: "Turma_UC");

            migrationBuilder.DropColumn(
                name: "UcIdUc",
                table: "Turma_UC");
        }
    }
}
