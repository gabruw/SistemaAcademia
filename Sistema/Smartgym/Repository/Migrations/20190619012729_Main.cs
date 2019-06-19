using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aparelho",
                columns: table => new
                {
                    IdAparelho = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeAparelho = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aparelho", x => x.IdAparelho);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CepEndereco = table.Column<int>(type: "int(8)", maxLength: 8, nullable: false),
                    RuaEndereco = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    BairroEndereco = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    NumeroEndereco = table.Column<int>(type: "int(5)", maxLength: 5, nullable: false),
                    ComplementoEndereco = table.Column<int>(type: "int(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEnderecoAluno = table.Column<int>(nullable: false),
                    PermissaoAluno = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    EmailAluno = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    SenhaAluno = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    MatriculaAluno = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    NomeAluno = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CpfAluno = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DataNascimentoAluno = table.Column<DateTime>(type: "date", nullable: false),
                    TelefoneAluno = table.Column<int>(type: "int(11)", maxLength: 11, nullable: false),
                    CelularAluno = table.Column<int>(type: "int(11)", maxLength: 11, nullable: false),
                    SexoAluno = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    ImagemAluno = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Endereco_IdEnderecoAluno",
                        column: x => x.IdEnderecoAluno,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    IdUnidade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEnderecoUnidade = table.Column<int>(nullable: false),
                    NomeUnidade = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    ImagemUnidade = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.IdUnidade);
                    table.ForeignKey(
                        name: "FK_Unidade_Endereco_IdEnderecoUnidade",
                        column: x => x.IdEnderecoUnidade,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    IdProfessor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEnderecoProfessor = table.Column<int>(nullable: false),
                    IdUnidadeProfessor = table.Column<int>(nullable: false),
                    IdAgendaProfessor = table.Column<int>(nullable: false),
                    PermissaoProfessor = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    EmailProfessor = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    SenhaProfessor = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    CrefProfessor = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    NomeProfessor = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CpfProfessor = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    DataNascimentoProfessor = table.Column<DateTime>(type: "date", nullable: false),
                    DataAdmissaoProfessor = table.Column<DateTime>(type: "date", nullable: false),
                    TelefoneProfessor = table.Column<int>(type: "int(11)", maxLength: 11, nullable: false),
                    CelularProfessor = table.Column<int>(type: "int(11)", maxLength: 11, nullable: false),
                    SexoProfessor = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    ImagemProfessor = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.IdProfessor);
                    table.ForeignKey(
                        name: "FK_Professor_Endereco_IdEnderecoProfessor",
                        column: x => x.IdEnderecoProfessor,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_Unidade_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Unidade",
                        principalColumn: "IdUnidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfessorAgenda = table.Column<int>(nullable: false),
                    IdAlunoAgenda = table.Column<int>(nullable: false),
                    DataAgenda = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_Agenda_Aluno_IdAlunoAgenda",
                        column: x => x.IdAlunoAgenda,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Professor_IdProfessorAgenda",
                        column: x => x.IdProfessorAgenda,
                        principalTable: "Professor",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAlunoAvaliacao = table.Column<int>(nullable: false),
                    IdProfessorAvaliacao = table.Column<int>(nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "date", nullable: false),
                    AlturaAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    PesoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    ImcAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    BracoDireitoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    BracoEsquerdoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    PeitoralAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    AbdomemAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    QuadrilAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    QuadricepsDireitoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    QuadrcepsEsquerdoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    PanturrilhaDireitaAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    PanturrilhaEsquerdaAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaPeitoAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaCoxaAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaTricepsAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaAbdomemAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaQuadrilAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    DobraCutaneaPanturrilhaAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    PercentualGorduraAvaliacao = table.Column<decimal>(type: "decimal", maxLength: 4, nullable: false),
                    ObservacaoAvaliacao = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false),
                    AlunoIdAluno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Aluno_AlunoIdAluno",
                        column: x => x.AlunoIdAluno,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Aluno_IdAlunoAvaliacao",
                        column: x => x.IdAlunoAvaliacao,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Professor_IdProfessorAvaliacao",
                        column: x => x.IdProfessorAvaliacao,
                        principalTable: "Professor",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    IdFicha = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfessorFicha = table.Column<int>(nullable: false),
                    IdAlunoFicha = table.Column<int>(nullable: false),
                    AlunoIdAluno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.IdFicha);
                    table.ForeignKey(
                        name: "FK_Ficha_Aluno_AlunoIdAluno",
                        column: x => x.AlunoIdAluno,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ficha_Aluno_IdAlunoFicha",
                        column: x => x.IdAlunoFicha,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ficha_Professor_IdProfessorFicha",
                        column: x => x.IdProfessorFicha,
                        principalTable: "Professor",
                        principalColumn: "IdProfessor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    IdSerie = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFichaSerie = table.Column<int>(nullable: false),
                    NomeSerie = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ObservacaoSerie = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: true),
                    FichaIdFicha = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.IdSerie);
                    table.ForeignKey(
                        name: "FK_Serie_Ficha_FichaIdFicha",
                        column: x => x.FichaIdFicha,
                        principalTable: "Ficha",
                        principalColumn: "IdFicha",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Serie_Ficha_IdFichaSerie",
                        column: x => x.IdFichaSerie,
                        principalTable: "Ficha",
                        principalColumn: "IdFicha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    IdExercicio = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAparelhoExercicio = table.Column<int>(nullable: false),
                    IdSerieExercicio = table.Column<int>(nullable: false),
                    NomeExercicio = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ObservacaoExercicio = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.IdExercicio);
                    table.ForeignKey(
                        name: "FK_Exercicio_Exercicio_IdAparelhoExercicio",
                        column: x => x.IdAparelhoExercicio,
                        principalTable: "Exercicio",
                        principalColumn: "IdExercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicio_Serie_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "Serie",
                        principalColumn: "IdSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdAlunoAgenda",
                table: "Agenda",
                column: "IdAlunoAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdProfessorAgenda",
                table: "Agenda",
                column: "IdProfessorAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdEnderecoAluno",
                table: "Aluno",
                column: "IdEnderecoAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_AlunoIdAluno",
                table: "Avaliacao",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdAlunoAvaliacao",
                table: "Avaliacao",
                column: "IdAlunoAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdProfessorAvaliacao",
                table: "Avaliacao",
                column: "IdProfessorAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_IdAparelhoExercicio",
                table: "Exercicio",
                column: "IdAparelhoExercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_AlunoIdAluno",
                table: "Ficha",
                column: "AlunoIdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_IdAlunoFicha",
                table: "Ficha",
                column: "IdAlunoFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Ficha_IdProfessorFicha",
                table: "Ficha",
                column: "IdProfessorFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_IdAgendaProfessor",
                table: "Professor",
                column: "IdAgendaProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_IdEnderecoProfessor",
                table: "Professor",
                column: "IdEnderecoProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_FichaIdFicha",
                table: "Serie",
                column: "FichaIdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_IdFichaSerie",
                table: "Serie",
                column: "IdFichaSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdEnderecoUnidade",
                table: "Unidade",
                column: "IdEnderecoUnidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Agenda_IdAgendaProfessor",
                table: "Professor",
                column: "IdAgendaProfessor",
                principalTable: "Agenda",
                principalColumn: "IdAgenda",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Aluno_IdAlunoAgenda",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Professor_IdProfessorAgenda",
                table: "Agenda");

            migrationBuilder.DropTable(
                name: "Aparelho");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Ficha");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
