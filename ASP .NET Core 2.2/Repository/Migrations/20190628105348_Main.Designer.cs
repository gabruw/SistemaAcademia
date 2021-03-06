﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(SmartgymContext))]
    [Migration("20190628105348_Main")]
    partial class Main
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.DTO.Agenda", b =>
                {
                    b.Property<long>("IdAgenda")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAgenda");

                    b.Property<long>("IdAlunoAgenda");

                    b.Property<long>("IdProfessorAgenda");

                    b.HasKey("IdAgenda");

                    b.HasIndex("DataAgenda")
                        .IsUnique();

                    b.HasIndex("IdAlunoAgenda");

                    b.HasIndex("IdProfessorAgenda");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("Domain.DTO.Aluno", b =>
                {
                    b.Property<long>("IdAluno")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CelularAluno")
                        .HasColumnType("bigint(11)")
                        .HasMaxLength(11);

                    b.Property<long>("CpfAluno");

                    b.Property<DateTime>("DataNascimentoAluno")
                        .HasColumnType("date");

                    b.Property<long>("IdContaAluno");

                    b.Property<long>("IdEnderecoAluno");

                    b.Property<string>("ImagemAluno")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("MatriculaAluno");

                    b.Property<string>("NomeAluno")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("PermissaoAluno")
                        .HasColumnType("int(1)")
                        .HasMaxLength(1);

                    b.Property<int>("SexoAluno")
                        .HasColumnType("int(1)")
                        .HasMaxLength(1);

                    b.Property<long>("TelefoneAluno")
                        .HasColumnType("bigint(10)")
                        .HasMaxLength(10);

                    b.HasKey("IdAluno");

                    b.HasIndex("CpfAluno")
                        .IsUnique();

                    b.HasIndex("IdContaAluno");

                    b.HasIndex("IdEnderecoAluno");

                    b.HasIndex("MatriculaAluno")
                        .IsUnique();

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Domain.DTO.Aparelho", b =>
                {
                    b.Property<long>("IdAparelho")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NomeAparelho");

                    b.HasKey("IdAparelho");

                    b.HasIndex("NomeAparelho")
                        .IsUnique();

                    b.ToTable("Aparelho");
                });

            modelBuilder.Entity("Domain.DTO.Avaliacao", b =>
                {
                    b.Property<long>("IdAvaliacao")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AbdomemAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("AlturaAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<long?>("AlunoIdAluno");

                    b.Property<decimal>("BracoDireitoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("BracoEsquerdoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("date");

                    b.Property<decimal>("DobraCutaneaAbdomemAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("DobraCutaneaCoxaAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("DobraCutaneaPanturrilhaAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("DobraCutaneaPeitoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("DobraCutaneaQuadrilAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("DobraCutaneaTricepsAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<long>("IdAlunoAvaliacao");

                    b.Property<long>("IdProfessorAvaliacao");

                    b.Property<decimal>("ImcAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<string>("ObservacaoAvaliacao")
                        .IsRequired()
                        .HasColumnType("varchar(800)")
                        .HasMaxLength(800);

                    b.Property<decimal>("PanturrilhaDireitaAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("PanturrilhaEsquerdaAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("PeitoralAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("PercentualGorduraAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("PesoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("QuadrcepsEsquerdoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("QuadricepsDireitoAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.Property<decimal>("QuadrilAvaliacao")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal")
                        .HasMaxLength(4);

                    b.HasKey("IdAvaliacao");

                    b.HasIndex("AlunoIdAluno");

                    b.HasIndex("IdAlunoAvaliacao");

                    b.HasIndex("IdProfessorAvaliacao");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Domain.DTO.Conta", b =>
                {
                    b.Property<long>("IdConta")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailConta");

                    b.Property<string>("SenhaConta")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdConta");

                    b.HasIndex("EmailConta")
                        .IsUnique();

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("Domain.DTO.Endereco", b =>
                {
                    b.Property<long>("IdEndereco")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BairroEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("CepEndereco")
                        .HasColumnType("int(8)")
                        .HasMaxLength(8);

                    b.Property<int>("ComplementoEndereco")
                        .HasColumnType("int(5)")
                        .HasMaxLength(5);

                    b.Property<int>("NumeroEndereco")
                        .HasColumnType("int(5)")
                        .HasMaxLength(5);

                    b.Property<string>("RuaEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("IdEndereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Domain.DTO.Exercicio", b =>
                {
                    b.Property<long>("IdExercicio")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdAparelhoExercicio");

                    b.Property<string>("NomeExercicio")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ObservacaoExercicio")
                        .IsRequired()
                        .HasColumnType("varchar(800)")
                        .HasMaxLength(800);

                    b.HasKey("IdExercicio");

                    b.HasIndex("IdAparelhoExercicio");

                    b.ToTable("Exercicio");
                });

            modelBuilder.Entity("Domain.DTO.ExercicioSerie", b =>
                {
                    b.Property<long>("IdExercicioSerie")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdExercicioExercicioSerie");

                    b.Property<long>("IdSerieExercicioSerie");

                    b.Property<int>("RepeticoesExercicioSerie")
                        .HasColumnType("int(3)")
                        .HasMaxLength(3);

                    b.HasKey("IdExercicioSerie");

                    b.HasIndex("IdExercicioExercicioSerie");

                    b.HasIndex("IdSerieExercicioSerie");

                    b.ToTable("ExercicioSerie");
                });

            modelBuilder.Entity("Domain.DTO.Ficha", b =>
                {
                    b.Property<long>("IdFicha")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AlunoIdAluno");

                    b.Property<long>("IdAlunoFicha");

                    b.Property<long>("IdProfessorFicha");

                    b.HasKey("IdFicha");

                    b.HasIndex("AlunoIdAluno");

                    b.HasIndex("IdAlunoFicha");

                    b.HasIndex("IdProfessorFicha");

                    b.ToTable("Ficha");
                });

            modelBuilder.Entity("Domain.DTO.Professor", b =>
                {
                    b.Property<long>("IdProfessor")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CelularProfessor")
                        .HasColumnType("bigint(11)")
                        .HasMaxLength(11);

                    b.Property<long>("CpfProfessor");

                    b.Property<string>("CrefProfessor");

                    b.Property<DateTime>("DataAdmissaoProfessor")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataNascimentoProfessor")
                        .HasColumnType("date");

                    b.Property<long?>("IdAgendaProfessor");

                    b.Property<long>("IdContaProfessor");

                    b.Property<long>("IdEnderecoProfessor");

                    b.Property<long>("IdUnidadeProfessor");

                    b.Property<string>("ImagemProfessor")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NomeProfessor")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("PermissaoProfessor")
                        .HasColumnType("int(1)")
                        .HasMaxLength(1);

                    b.Property<int>("SexoProfessor")
                        .HasColumnType("int(1)")
                        .HasMaxLength(1);

                    b.Property<long>("TelefoneProfessor")
                        .HasColumnType("bigint(10)")
                        .HasMaxLength(10);

                    b.HasKey("IdProfessor");

                    b.HasIndex("CpfProfessor")
                        .IsUnique();

                    b.HasIndex("CrefProfessor")
                        .IsUnique();

                    b.HasIndex("IdAgendaProfessor");

                    b.HasIndex("IdContaProfessor");

                    b.HasIndex("IdEnderecoProfessor");

                    b.HasIndex("IdUnidadeProfessor");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Domain.DTO.Serie", b =>
                {
                    b.Property<long>("IdSerie")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FichaIdFicha");

                    b.Property<long>("IdFichaSerie");

                    b.Property<string>("NomeSerie")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("ObservacaoSerie")
                        .HasColumnType("varchar(800)")
                        .HasMaxLength(800);

                    b.Property<int?>("RepeticoesSerie")
                        .HasColumnType("int(3)")
                        .HasMaxLength(3);

                    b.HasKey("IdSerie");

                    b.HasIndex("FichaIdFicha");

                    b.HasIndex("IdFichaSerie");

                    b.ToTable("Serie");
                });

            modelBuilder.Entity("Domain.DTO.Unidade", b =>
                {
                    b.Property<long>("IdUnidade")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("IdEnderecoUnidade");

                    b.Property<string>("ImagemUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("NomeUnidade")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("IdUnidade");

                    b.HasIndex("IdEnderecoUnidade");

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("Domain.DTO.Agenda", b =>
                {
                    b.HasOne("Domain.DTO.Aluno", "AlunoAgenda")
                        .WithMany()
                        .HasForeignKey("IdAlunoAgenda")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Professor", "ProfessorAgenda")
                        .WithMany()
                        .HasForeignKey("IdProfessorAgenda")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Aluno", b =>
                {
                    b.HasOne("Domain.DTO.Conta", "ContaAluno")
                        .WithMany()
                        .HasForeignKey("IdContaAluno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Endereco", "EnderecoAluno")
                        .WithMany()
                        .HasForeignKey("IdEnderecoAluno")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Avaliacao", b =>
                {
                    b.HasOne("Domain.DTO.Aluno")
                        .WithMany("AvaliacaoAluno")
                        .HasForeignKey("AlunoIdAluno");

                    b.HasOne("Domain.DTO.Aluno", "AlunoAvaliacao")
                        .WithMany()
                        .HasForeignKey("IdAlunoAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Professor", "ProfessorAvaliacao")
                        .WithMany()
                        .HasForeignKey("IdProfessorAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Exercicio", b =>
                {
                    b.HasOne("Domain.DTO.Aparelho", "AparelhoExercicio")
                        .WithMany()
                        .HasForeignKey("IdAparelhoExercicio")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.ExercicioSerie", b =>
                {
                    b.HasOne("Domain.DTO.Exercicio", "ExercicioExercicioSerie")
                        .WithMany()
                        .HasForeignKey("IdExercicioExercicioSerie")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Serie", "SerieExercicioSerie")
                        .WithMany("ExercicioExercicioSerie")
                        .HasForeignKey("IdSerieExercicioSerie")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Ficha", b =>
                {
                    b.HasOne("Domain.DTO.Aluno")
                        .WithMany("FichaAluno")
                        .HasForeignKey("AlunoIdAluno");

                    b.HasOne("Domain.DTO.Aluno", "AlunoFicha")
                        .WithMany()
                        .HasForeignKey("IdAlunoFicha")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Professor", "ProfessorFicha")
                        .WithMany()
                        .HasForeignKey("IdProfessorFicha")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Professor", b =>
                {
                    b.HasOne("Domain.DTO.Agenda", "AgendaProfessor")
                        .WithMany()
                        .HasForeignKey("IdAgendaProfessor");

                    b.HasOne("Domain.DTO.Conta", "ContaProfessor")
                        .WithMany()
                        .HasForeignKey("IdContaProfessor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Endereco", "EnderecoProfessor")
                        .WithMany()
                        .HasForeignKey("IdEnderecoProfessor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.DTO.Unidade", "UnidadeProfessor")
                        .WithMany()
                        .HasForeignKey("IdUnidadeProfessor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Serie", b =>
                {
                    b.HasOne("Domain.DTO.Ficha")
                        .WithMany("SerieFicha")
                        .HasForeignKey("FichaIdFicha");

                    b.HasOne("Domain.DTO.Ficha", "FichaSerie")
                        .WithMany()
                        .HasForeignKey("IdFichaSerie")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.DTO.Unidade", b =>
                {
                    b.HasOne("Domain.DTO.Endereco", "EnderecoUnidade")
                        .WithMany()
                        .HasForeignKey("IdEnderecoUnidade")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
