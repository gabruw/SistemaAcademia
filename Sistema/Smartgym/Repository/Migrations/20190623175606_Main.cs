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
                    IdAparelho = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeAparelho = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aparelho", x => x.IdAparelho);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    IdConta = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailConta = table.Column<string>(nullable: true),
                    SenhaConta = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<long>(nullable: false)
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
                    IdAluno = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContaAluno = table.Column<long>(nullable: false),
                    IdEnderecoAluno = table.Column<long>(nullable: false),
                    PermissaoAluno = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    MatriculaAluno = table.Column<string>(nullable: true),
                    NomeAluno = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CpfAluno = table.Column<long>(nullable: false),
                    DataNascimentoAluno = table.Column<DateTime>(type: "date", nullable: false),
                    TelefoneAluno = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    CelularAluno = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    SexoAluno = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    ImagemAluno = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Conta_IdContaAluno",
                        column: x => x.IdContaAluno,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
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
                    IdUnidade = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEnderecoUnidade = table.Column<long>(nullable: false),
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
                    IdProfessor = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdContaProfessor = table.Column<long>(nullable: false),
                    IdEnderecoProfessor = table.Column<long>(nullable: false),
                    IdUnidadeProfessor = table.Column<long>(nullable: false),
                    IdAgendaProfessor = table.Column<long>(nullable: true),
                    PermissaoProfessor = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    CrefProfessor = table.Column<string>(nullable: true),
                    NomeProfessor = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CpfProfessor = table.Column<long>(nullable: false),
                    DataNascimentoProfessor = table.Column<DateTime>(type: "date", nullable: false),
                    DataAdmissaoProfessor = table.Column<DateTime>(type: "date", nullable: false),
                    TelefoneProfessor = table.Column<long>(type: "bigint", maxLength: 10, nullable: false),
                    CelularProfessor = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    SexoProfessor = table.Column<int>(type: "int(1)", maxLength: 1, nullable: false),
                    ImagemProfessor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.IdProfessor);
                    table.ForeignKey(
                        name: "FK_Professor_Conta_IdContaProfessor",
                        column: x => x.IdContaProfessor,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Cascade);
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
                    IdAgenda = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfessorAgenda = table.Column<long>(nullable: false),
                    IdAlunoAgenda = table.Column<long>(nullable: false),
                    DataAgenda = table.Column<DateTime>(nullable: false)
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
                    IdAvaliacao = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAlunoAvaliacao = table.Column<long>(nullable: false),
                    IdProfessorAvaliacao = table.Column<long>(nullable: false),
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
                    AlunoIdAluno = table.Column<long>(nullable: true)
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
                    IdFicha = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProfessorFicha = table.Column<long>(nullable: false),
                    IdAlunoFicha = table.Column<long>(nullable: false),
                    AlunoIdAluno = table.Column<long>(nullable: true)
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
                    IdSerie = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFichaSerie = table.Column<long>(nullable: true),
                    NomeSerie = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ObservacaoSerie = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: true),
                    FichaIdFicha = table.Column<long>(nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    IdExercicio = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdAparelhoExercicio = table.Column<long>(nullable: false),
                    IdSerieExercicio = table.Column<long>(nullable: true),
                    NomeExercicio = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ObservacaoExercicio = table.Column<string>(type: "varchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.IdExercicio);
                    table.ForeignKey(
                        name: "FK_Exercicio_Aparelho_IdAparelhoExercicio",
                        column: x => x.IdAparelhoExercicio,
                        principalTable: "Aparelho",
                        principalColumn: "IdAparelho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicio_Serie_IdExercicio",
                        column: x => x.IdExercicio,
                        principalTable: "Serie",
                        principalColumn: "IdSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UniqueKey_DataAgenda",
                table: "Agenda",
                column: "DataAgenda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdAlunoAgenda",
                table: "Agenda",
                column: "IdAlunoAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_IdProfessorAgenda",
                table: "Agenda",
                column: "IdProfessorAgenda");

            migrationBuilder.CreateIndex(
                name: "UniqueKey_CpfAluno",
                table: "Aluno",
                column: "CpfAluno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdContaAluno",
                table: "Aluno",
                column: "IdContaAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdEnderecoAluno",
                table: "Aluno",
                column: "IdEnderecoAluno");

            migrationBuilder.CreateIndex(
                name: "UniqueKey_MatriculaAluno",
                table: "Aluno",
                column: "MatriculaAluno",
                unique: true);

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
                name: "UniqueKey_EmailConta",
                table: "Conta",
                column: "EmailConta",
                unique: true);

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
                name: "UniqueKey_CpfProfessor",
                table: "Professor",
                column: "CpfProfessor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UniqueKey_CrefProfessor",
                table: "Professor",
                column: "CrefProfessor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professor_IdAgendaProfessor",
                table: "Professor",
                column: "IdAgendaProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_IdContaProfessor",
                table: "Professor",
                column: "IdContaProfessor");

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
                onDelete: ReferentialAction.Restrict);
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
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Aparelho");

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
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
