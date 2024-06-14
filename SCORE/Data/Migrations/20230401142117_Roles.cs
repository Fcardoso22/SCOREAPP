using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCORE.Data.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    NMecanograficoAluno = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno__7C8A234AEFB222B4", x => x.NMecanograficoAluno);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    NMecanograficoDocente = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Docente__BAA1BFEF0BE3947F", x => x.NMecanograficoDocente);
                });

            migrationBuilder.CreateTable(
                name: "Equipa",
                columns: table => new
                {
                    Id_Equipa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Overall_Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipa__4B9119CE57613823", x => x.Id_Equipa);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id_Exercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exercici__8BAE3646C5C2B738", x => x.Id_Exercicio);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id_Jogador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jogador__5720AAD9471CC4B6", x => x.Id_Jogador);
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    Id_Jogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataJogo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jogo__FECD839810E75792", x => x.Id_Jogo);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id_Turma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma__5CF918CE321987AE", x => x.Id_Turma);
                });

            migrationBuilder.CreateTable(
                name: "UC",
                columns: table => new
                {
                    Id_UC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UC__16EC21A836FAADA2", x => x.Id_UC);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Equipa",
                columns: table => new
                {
                    Id_Aluno_Equipa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NMecanograficoAluno = table.Column<int>(type: "int", nullable: false),
                    Id_Equipa = table.Column<int>(type: "int", nullable: false),
                    Id_Turma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno_Eq__9B02E1C300D9DD40", x => x.Id_Aluno_Equipa);
                    table.ForeignKey(
                        name: "FK__Aluno_Equ__Id_Eq__4E88ABD4",
                        column: x => x.Id_Equipa,
                        principalTable: "Equipa",
                        principalColumn: "Id_Equipa");
                    table.ForeignKey(
                        name: "FK__Aluno_Equ__NMeca__4D94879B",
                        column: x => x.NMecanograficoAluno,
                        principalTable: "Aluno",
                        principalColumn: "NMecanograficoAluno");
                });

            migrationBuilder.CreateTable(
                name: "Equipa_Jogador",
                columns: table => new
                {
                    Id_Equipa_Jogador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Equipa = table.Column<int>(type: "int", nullable: false),
                    Id_Jogador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipa_J__65683B32B2C79ABC", x => x.Id_Equipa_Jogador);
                    table.ForeignKey(
                        name: "FK__Equipa_Jo__Id_Eq__49C3F6B7",
                        column: x => x.Id_Equipa,
                        principalTable: "Equipa",
                        principalColumn: "Id_Equipa");
                    table.ForeignKey(
                        name: "FK__Equipa_Jo__Id_Jo__4AB81AF0",
                        column: x => x.Id_Jogador,
                        principalTable: "Jogador",
                        principalColumn: "Id_Jogador");
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id_Campeonato = table.Column<int>(type: "int", nullable: false),
                    Terminado = table.Column<bool>(type: "bit", nullable: false),
                    Id_Turma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campeona__A8849C34EDC06937", x => x.Id_Campeonato);
                    table.ForeignKey(
                        name: "FK__Campeonat__Id_Tu__33D4B598",
                        column: x => x.Id_Turma,
                        principalTable: "Turma",
                        principalColumn: "Id_Turma");
                });

            migrationBuilder.CreateTable(
                name: "Turma_Aluno",
                columns: table => new
                {
                    Id_Turma_Aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Turma = table.Column<int>(type: "int", nullable: false),
                    NMecanograficoAluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma_Al__AAF950D028AD7F30", x => x.Id_Turma_Aluno);
                    table.ForeignKey(
                        name: "FK__Turma_Alu__Id_Tu__5165187F",
                        column: x => x.Id_Turma,
                        principalTable: "Turma",
                        principalColumn: "Id_Turma");
                    table.ForeignKey(
                        name: "FK__Turma_Alu__NMeca__52593CB8",
                        column: x => x.NMecanograficoAluno,
                        principalTable: "Aluno",
                        principalColumn: "NMecanograficoAluno");
                });

            migrationBuilder.CreateTable(
                name: "Docente_UC",
                columns: table => new
                {
                    Id_Docente_UC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NMecanograficoDocente = table.Column<int>(type: "int", nullable: false),
                    id_UC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Docente___2E47949A93F1E34E", x => x.Id_Docente_UC);
                    table.ForeignKey(
                        name: "FK__Docente_U__NMeca__3E52440B",
                        column: x => x.NMecanograficoDocente,
                        principalTable: "Docente",
                        principalColumn: "NMecanograficoDocente");
                    table.ForeignKey(
                        name: "FK__Docente_U__id_UC__3F466844",
                        column: x => x.id_UC,
                        principalTable: "UC",
                        principalColumn: "Id_UC");
                });

            migrationBuilder.CreateTable(
                name: "Exercicio_UC",
                columns: table => new
                {
                    Id_Exercicio_UC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Exercicio = table.Column<int>(type: "int", nullable: false),
                    Id_UC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Exercici__D473139A0A7D01D9", x => x.Id_Exercicio_UC);
                    table.ForeignKey(
                        name: "FK__Exercicio__Id_Ex__4222D4EF",
                        column: x => x.Id_Exercicio,
                        principalTable: "Exercicio",
                        principalColumn: "Id_Exercicio");
                    table.ForeignKey(
                        name: "FK__Exercicio__Id_UC__4316F928",
                        column: x => x.Id_UC,
                        principalTable: "UC",
                        principalColumn: "Id_UC");
                });

            migrationBuilder.CreateTable(
                name: "Turma_UC",
                columns: table => new
                {
                    Id_Turma_UC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Turma = table.Column<int>(type: "int", nullable: false),
                    Id_UC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma_UC__CA3EC711F7FA34F5", x => x.Id_Turma_UC);
                    table.ForeignKey(
                        name: "FK__Turma_UC__Id_Tur__36B12243",
                        column: x => x.Id_Turma,
                        principalTable: "Turma",
                        principalColumn: "Id_Turma");
                    table.ForeignKey(
                        name: "FK__Turma_UC__Id_UC__37A5467C",
                        column: x => x.Id_UC,
                        principalTable: "UC",
                        principalColumn: "Id_UC");
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Campeonato",
                columns: table => new
                {
                    Id_Aluno_Campeonato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NMecanograficoAluno = table.Column<int>(type: "int", nullable: false),
                    Id_campeonato = table.Column<int>(type: "int", nullable: false),
                    Creditos = table.Column<int>(type: "int", nullable: false),
                    Num_Entradas = table.Column<int>(type: "int", nullable: false),
                    Tempo_Min = table.Column<int>(type: "int", nullable: false),
                    Num_Submissoes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno_Ca__83E4D97D2B0DD820", x => x.Id_Aluno_Campeonato);
                    table.ForeignKey(
                        name: "FK__Aluno_Cam__Id_ca__46E78A0C",
                        column: x => x.Id_campeonato,
                        principalTable: "Campeonato",
                        principalColumn: "Id_Campeonato");
                    table.ForeignKey(
                        name: "FK__Aluno_Cam__NMeca__45F365D3",
                        column: x => x.NMecanograficoAluno,
                        principalTable: "Aluno",
                        principalColumn: "NMecanograficoAluno");
                });

            migrationBuilder.CreateTable(
                name: "Campeonato_Equipa",
                columns: table => new
                {
                    Id_Campeonato_Equipa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Equipa = table.Column<int>(type: "int", nullable: false),
                    Id_Campeonato = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false),
                    Pontuacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campeona__20443250C98E5302", x => x.Id_Campeonato_Equipa);
                    table.ForeignKey(
                        name: "FK__Campeonat__Id_Ca__3B75D760",
                        column: x => x.Id_Campeonato,
                        principalTable: "Campeonato",
                        principalColumn: "Id_Campeonato");
                    table.ForeignKey(
                        name: "FK__Campeonat__Id_Eq__3A81B327",
                        column: x => x.Id_Equipa,
                        principalTable: "Equipa",
                        principalColumn: "Id_Equipa");
                });

            migrationBuilder.CreateTable(
                name: "Campeonato_Jogo",
                columns: table => new
                {
                    Id_Campeonato_Jogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Campeonato = table.Column<int>(type: "int", nullable: false),
                    Id_Jogo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Campeona__870298C0FC284ADB", x => x.Id_Campeonato_Jogo);
                    table.ForeignKey(
                        name: "FK__Campeonat__Id_Ca__5535A963",
                        column: x => x.Id_Campeonato,
                        principalTable: "Campeonato",
                        principalColumn: "Id_Campeonato");
                    table.ForeignKey(
                        name: "FK__Campeonat__Id_Jo__5629CD9C",
                        column: x => x.Id_Jogo,
                        principalTable: "Jogo",
                        principalColumn: "Id_Jogo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Campeonato_Id_campeonato",
                table: "Aluno_Campeonato",
                column: "Id_campeonato");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Campeonato_NMecanograficoAluno",
                table: "Aluno_Campeonato",
                column: "NMecanograficoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Equipa_Id_Equipa",
                table: "Aluno_Equipa",
                column: "Id_Equipa");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Equipa_NMecanograficoAluno",
                table: "Aluno_Equipa",
                column: "NMecanograficoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_Id_Turma",
                table: "Campeonato",
                column: "Id_Turma");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_Equipa_Id_Campeonato",
                table: "Campeonato_Equipa",
                column: "Id_Campeonato");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_Equipa_Id_Equipa",
                table: "Campeonato_Equipa",
                column: "Id_Equipa");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_Jogo_Id_Campeonato",
                table: "Campeonato_Jogo",
                column: "Id_Campeonato");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_Jogo_Id_Jogo",
                table: "Campeonato_Jogo",
                column: "Id_Jogo");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_UC_id_UC",
                table: "Docente_UC",
                column: "id_UC");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_UC_NMecanograficoDocente",
                table: "Docente_UC",
                column: "NMecanograficoDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Equipa_Jogador_Id_Equipa",
                table: "Equipa_Jogador",
                column: "Id_Equipa");

            migrationBuilder.CreateIndex(
                name: "IX_Equipa_Jogador_Id_Jogador",
                table: "Equipa_Jogador",
                column: "Id_Jogador");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_UC_Id_Exercicio",
                table: "Exercicio_UC",
                column: "Id_Exercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_UC_Id_UC",
                table: "Exercicio_UC",
                column: "Id_UC");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Aluno_Id_Turma",
                table: "Turma_Aluno",
                column: "Id_Turma");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_Aluno_NMecanograficoAluno",
                table: "Turma_Aluno",
                column: "NMecanograficoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_UC_Id_Turma",
                table: "Turma_UC",
                column: "Id_Turma");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_UC_Id_UC",
                table: "Turma_UC",
                column: "Id_UC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno_Campeonato");

            migrationBuilder.DropTable(
                name: "Aluno_Equipa");

            migrationBuilder.DropTable(
                name: "Campeonato_Equipa");

            migrationBuilder.DropTable(
                name: "Campeonato_Jogo");

            migrationBuilder.DropTable(
                name: "Docente_UC");

            migrationBuilder.DropTable(
                name: "Equipa_Jogador");

            migrationBuilder.DropTable(
                name: "Exercicio_UC");

            migrationBuilder.DropTable(
                name: "Turma_Aluno");

            migrationBuilder.DropTable(
                name: "Turma_UC");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Equipa");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "UC");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
