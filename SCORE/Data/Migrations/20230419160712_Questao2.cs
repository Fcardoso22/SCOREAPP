using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Questao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opcao");

            migrationBuilder.DropTable(
                name: "Questao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questao",
                columns: table => new
                {
                    IdQuestao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercicioIdExercicio = table.Column<int>(type: "int", nullable: true),
                    Ficheiro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.IdQuestao);
                    table.ForeignKey(
                        name: "FK_Questao_Exercicio_ExercicioIdExercicio",
                        column: x => x.ExercicioIdExercicio,
                        principalTable: "Exercicio",
                        principalColumn: "Id_Exercicio");
                });

            migrationBuilder.CreateTable(
                name: "Opcao",
                columns: table => new
                {
                    IdOpcao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correto = table.Column<bool>(type: "bit", nullable: false),
                    QuestaoIdQuestao = table.Column<int>(type: "int", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcao", x => x.IdOpcao);
                    table.ForeignKey(
                        name: "FK_Opcao_Questao_QuestaoIdQuestao",
                        column: x => x.QuestaoIdQuestao,
                        principalTable: "Questao",
                        principalColumn: "IdQuestao");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opcao_QuestaoIdQuestao",
                table: "Opcao",
                column: "QuestaoIdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_ExercicioIdExercicio",
                table: "Questao",
                column: "ExercicioIdExercicio");
        }
    }
}
