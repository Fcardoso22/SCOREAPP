using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Exercicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Exercicio");

            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "Exercicio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nota",
                table: "Exercicio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Exercicio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
