-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db_smartgym
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20190621164456_Main','2.2.4-servicing-10062');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `agenda`
--

DROP TABLE IF EXISTS `agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `agenda` (
  `IdAgenda` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdProfessorAgenda` bigint(20) NOT NULL,
  `IdAlunoAgenda` bigint(20) NOT NULL,
  `DataAgenda` date NOT NULL,
  PRIMARY KEY (`IdAgenda`),
  KEY `IX_Agenda_IdAlunoAgenda` (`IdAlunoAgenda`),
  KEY `IX_Agenda_IdProfessorAgenda` (`IdProfessorAgenda`),
  CONSTRAINT `FK_Agenda_Aluno_IdAlunoAgenda` FOREIGN KEY (`IdAlunoAgenda`) REFERENCES `aluno` (`IdAluno`) ON DELETE CASCADE,
  CONSTRAINT `FK_Agenda_Professor_IdProfessorAgenda` FOREIGN KEY (`IdProfessorAgenda`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agenda`
--

LOCK TABLES `agenda` WRITE;
/*!40000 ALTER TABLE `agenda` DISABLE KEYS */;
/*!40000 ALTER TABLE `agenda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aluno`
--

DROP TABLE IF EXISTS `aluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aluno` (
  `IdAluno` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdContaAluno` bigint(20) NOT NULL,
  `IdEnderecoAluno` bigint(20) NOT NULL,
  `PermissaoAluno` int(1) NOT NULL,
  `MatriculaAluno` varchar(8) NOT NULL,
  `NomeAluno` varchar(120) NOT NULL,
  `CpfAluno` bigint(20) NOT NULL,
  `DataNascimentoAluno` date NOT NULL,
  `TelefoneAluno` bigint(20) NOT NULL,
  `CelularAluno` bigint(20) NOT NULL,
  `SexoAluno` int(1) NOT NULL,
  `ImagemAluno` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`IdAluno`),
  KEY `IX_Aluno_IdContaAluno` (`IdContaAluno`),
  KEY `IX_Aluno_IdEnderecoAluno` (`IdEnderecoAluno`),
  CONSTRAINT `FK_Aluno_Conta_IdContaAluno` FOREIGN KEY (`IdContaAluno`) REFERENCES `conta` (`IdConta`) ON DELETE CASCADE,
  CONSTRAINT `FK_Aluno_Endereco_IdEnderecoAluno` FOREIGN KEY (`IdEnderecoAluno`) REFERENCES `endereco` (`IdEndereco`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aluno`
--

LOCK TABLES `aluno` WRITE;
/*!40000 ALTER TABLE `aluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `aluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aparelho`
--

DROP TABLE IF EXISTS `aparelho`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aparelho` (
  `IdAparelho` bigint(20) NOT NULL AUTO_INCREMENT,
  `NomeAparelho` varchar(60) NOT NULL,
  PRIMARY KEY (`IdAparelho`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aparelho`
--

LOCK TABLES `aparelho` WRITE;
/*!40000 ALTER TABLE `aparelho` DISABLE KEYS */;
/*!40000 ALTER TABLE `aparelho` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `avaliacao` (
  `IdAvaliacao` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdAlunoAvaliacao` bigint(20) NOT NULL,
  `IdProfessorAvaliacao` bigint(20) NOT NULL,
  `DataAvaliacao` date NOT NULL,
  `AlturaAvaliacao` decimal(10,0) NOT NULL,
  `PesoAvaliacao` decimal(10,0) NOT NULL,
  `ImcAvaliacao` decimal(10,0) NOT NULL,
  `BracoDireitoAvaliacao` decimal(10,0) NOT NULL,
  `BracoEsquerdoAvaliacao` decimal(10,0) NOT NULL,
  `PeitoralAvaliacao` decimal(10,0) NOT NULL,
  `AbdomemAvaliacao` decimal(10,0) NOT NULL,
  `QuadrilAvaliacao` decimal(10,0) NOT NULL,
  `QuadricepsDireitoAvaliacao` decimal(10,0) NOT NULL,
  `QuadrcepsEsquerdoAvaliacao` decimal(10,0) NOT NULL,
  `PanturrilhaDireitaAvaliacao` decimal(10,0) NOT NULL,
  `PanturrilhaEsquerdaAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaPeitoAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaCoxaAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaTricepsAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaAbdomemAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaQuadrilAvaliacao` decimal(10,0) NOT NULL,
  `DobraCutaneaPanturrilhaAvaliacao` decimal(10,0) NOT NULL,
  `PercentualGorduraAvaliacao` decimal(10,0) NOT NULL,
  `ObservacaoAvaliacao` varchar(800) NOT NULL,
  `AlunoIdAluno` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`IdAvaliacao`),
  KEY `IX_Avaliacao_AlunoIdAluno` (`AlunoIdAluno`),
  KEY `IX_Avaliacao_IdAlunoAvaliacao` (`IdAlunoAvaliacao`),
  KEY `IX_Avaliacao_IdProfessorAvaliacao` (`IdProfessorAvaliacao`),
  CONSTRAINT `FK_Avaliacao_Aluno_AlunoIdAluno` FOREIGN KEY (`AlunoIdAluno`) REFERENCES `aluno` (`IdAluno`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Avaliacao_Aluno_IdAlunoAvaliacao` FOREIGN KEY (`IdAlunoAvaliacao`) REFERENCES `aluno` (`IdAluno`) ON DELETE CASCADE,
  CONSTRAINT `FK_Avaliacao_Professor_IdProfessorAvaliacao` FOREIGN KEY (`IdProfessorAvaliacao`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `avaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `conta`
--

DROP TABLE IF EXISTS `conta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `conta` (
  `IdConta` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdAlunoConta` bigint(20) NOT NULL,
  `IdProfessorConta` bigint(20) NOT NULL,
  `EmailConta` varchar(60) NOT NULL,
  `SenhaConta` varchar(40) NOT NULL,
  PRIMARY KEY (`IdConta`),
  KEY `IX_Conta_IdAlunoConta` (`IdAlunoConta`),
  KEY `IX_Conta_IdProfessorConta` (`IdProfessorConta`),
  CONSTRAINT `FK_Conta_Aluno_IdAlunoConta` FOREIGN KEY (`IdAlunoConta`) REFERENCES `aluno` (`IdAluno`) ON DELETE CASCADE,
  CONSTRAINT `FK_Conta_Professor_IdProfessorConta` FOREIGN KEY (`IdProfessorConta`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conta`
--

LOCK TABLES `conta` WRITE;
/*!40000 ALTER TABLE `conta` DISABLE KEYS */;
/*!40000 ALTER TABLE `conta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endereco`
--

DROP TABLE IF EXISTS `endereco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `endereco` (
  `IdEndereco` bigint(20) NOT NULL AUTO_INCREMENT,
  `CepEndereco` int(8) NOT NULL,
  `RuaEndereco` varchar(80) NOT NULL,
  `BairroEndereco` varchar(80) NOT NULL,
  `NumeroEndereco` int(5) NOT NULL,
  `ComplementoEndereco` int(5) NOT NULL,
  PRIMARY KEY (`IdEndereco`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endereco`
--

LOCK TABLES `endereco` WRITE;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;
/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exercicio`
--

DROP TABLE IF EXISTS `exercicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `exercicio` (
  `IdExercicio` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdAparelhoExercicio` bigint(20) NOT NULL,
  `IdSerieExercicio` bigint(20) NOT NULL,
  `NomeExercicio` varchar(60) NOT NULL,
  `ObservacaoExercicio` varchar(800) NOT NULL,
  PRIMARY KEY (`IdExercicio`),
  KEY `IX_Exercicio_IdAparelhoExercicio` (`IdAparelhoExercicio`),
  CONSTRAINT `FK_Exercicio_Exercicio_IdAparelhoExercicio` FOREIGN KEY (`IdAparelhoExercicio`) REFERENCES `exercicio` (`IdExercicio`) ON DELETE CASCADE,
  CONSTRAINT `FK_Exercicio_Serie_IdExercicio` FOREIGN KEY (`IdExercicio`) REFERENCES `serie` (`IdSerie`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exercicio`
--

LOCK TABLES `exercicio` WRITE;
/*!40000 ALTER TABLE `exercicio` DISABLE KEYS */;
/*!40000 ALTER TABLE `exercicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ficha`
--

DROP TABLE IF EXISTS `ficha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ficha` (
  `IdFicha` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdProfessorFicha` bigint(20) NOT NULL,
  `IdAlunoFicha` bigint(20) NOT NULL,
  `AlunoIdAluno` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`IdFicha`),
  KEY `IX_Ficha_AlunoIdAluno` (`AlunoIdAluno`),
  KEY `IX_Ficha_IdAlunoFicha` (`IdAlunoFicha`),
  KEY `IX_Ficha_IdProfessorFicha` (`IdProfessorFicha`),
  CONSTRAINT `FK_Ficha_Aluno_AlunoIdAluno` FOREIGN KEY (`AlunoIdAluno`) REFERENCES `aluno` (`IdAluno`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Ficha_Aluno_IdAlunoFicha` FOREIGN KEY (`IdAlunoFicha`) REFERENCES `aluno` (`IdAluno`) ON DELETE CASCADE,
  CONSTRAINT `FK_Ficha_Professor_IdProfessorFicha` FOREIGN KEY (`IdProfessorFicha`) REFERENCES `professor` (`IdProfessor`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ficha`
--

LOCK TABLES `ficha` WRITE;
/*!40000 ALTER TABLE `ficha` DISABLE KEYS */;
/*!40000 ALTER TABLE `ficha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professor`
--

DROP TABLE IF EXISTS `professor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `professor` (
  `IdProfessor` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdContaProfessor` bigint(20) NOT NULL,
  `IdEnderecoProfessor` bigint(20) NOT NULL,
  `IdUnidadeProfessor` bigint(20) NOT NULL,
  `IdAgendaProfessor` bigint(20) NOT NULL,
  `PermissaoProfessor` int(1) NOT NULL,
  `CrefProfessor` varchar(9) NOT NULL,
  `NomeProfessor` varchar(120) NOT NULL,
  `CpfProfessor` bigint(20) NOT NULL,
  `DataNascimentoProfessor` date NOT NULL,
  `DataAdmissaoProfessor` date NOT NULL,
  `TelefoneProfessor` bigint(20) NOT NULL,
  `CelularProfessor` bigint(20) NOT NULL,
  `SexoProfessor` int(1) NOT NULL,
  `ImagemProfessor` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`IdProfessor`),
  KEY `IX_Professor_IdAgendaProfessor` (`IdAgendaProfessor`),
  KEY `IX_Professor_IdContaProfessor` (`IdContaProfessor`),
  KEY `IX_Professor_IdEnderecoProfessor` (`IdEnderecoProfessor`),
  CONSTRAINT `FK_Professor_Agenda_IdAgendaProfessor` FOREIGN KEY (`IdAgendaProfessor`) REFERENCES `agenda` (`IdAgenda`) ON DELETE CASCADE,
  CONSTRAINT `FK_Professor_Conta_IdContaProfessor` FOREIGN KEY (`IdContaProfessor`) REFERENCES `conta` (`IdConta`) ON DELETE CASCADE,
  CONSTRAINT `FK_Professor_Endereco_IdEnderecoProfessor` FOREIGN KEY (`IdEnderecoProfessor`) REFERENCES `endereco` (`IdEndereco`) ON DELETE CASCADE,
  CONSTRAINT `FK_Professor_Unidade_IdProfessor` FOREIGN KEY (`IdProfessor`) REFERENCES `unidade` (`IdUnidade`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professor`
--

LOCK TABLES `professor` WRITE;
/*!40000 ALTER TABLE `professor` DISABLE KEYS */;
/*!40000 ALTER TABLE `professor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serie`
--

DROP TABLE IF EXISTS `serie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `serie` (
  `IdSerie` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdFichaSerie` bigint(20) NOT NULL,
  `NomeSerie` varchar(60) NOT NULL,
  `ObservacaoSerie` varchar(800) DEFAULT NULL,
  `FichaIdFicha` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`IdSerie`),
  KEY `IX_Serie_FichaIdFicha` (`FichaIdFicha`),
  KEY `IX_Serie_IdFichaSerie` (`IdFichaSerie`),
  CONSTRAINT `FK_Serie_Ficha_FichaIdFicha` FOREIGN KEY (`FichaIdFicha`) REFERENCES `ficha` (`IdFicha`) ON DELETE RESTRICT,
  CONSTRAINT `FK_Serie_Ficha_IdFichaSerie` FOREIGN KEY (`IdFichaSerie`) REFERENCES `ficha` (`IdFicha`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serie`
--

LOCK TABLES `serie` WRITE;
/*!40000 ALTER TABLE `serie` DISABLE KEYS */;
/*!40000 ALTER TABLE `serie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidade`
--

DROP TABLE IF EXISTS `unidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `unidade` (
  `IdUnidade` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdEnderecoUnidade` bigint(20) NOT NULL,
  `NomeUnidade` varchar(120) NOT NULL,
  `ImagemUnidade` varchar(64) NOT NULL,
  PRIMARY KEY (`IdUnidade`),
  KEY `IX_Unidade_IdEnderecoUnidade` (`IdEnderecoUnidade`),
  CONSTRAINT `FK_Unidade_Endereco_IdEnderecoUnidade` FOREIGN KEY (`IdEnderecoUnidade`) REFERENCES `endereco` (`IdEndereco`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidade`
--

LOCK TABLES `unidade` WRITE;
/*!40000 ALTER TABLE `unidade` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidade` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-21 13:48:08
