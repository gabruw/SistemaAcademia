-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 16-Abr-2019 às 23:24
-- Versão do servidor: 10.1.38-MariaDB
-- versão do PHP: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_smartgym`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `agenda`
--

CREATE TABLE `agenda` (
  `IdAgenda` int(11) NOT NULL,
  `IdProfessor` int(11) NOT NULL,
  `IdAluno` int(11) NOT NULL,
  `Data` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno`
--

CREATE TABLE `aluno` (
  `IdAluno` int(11) NOT NULL,
  `IdAvaliacao` int(11) NOT NULL,
  `IdFicha` int(11) NOT NULL,
  `Permissao` int(1) NOT NULL DEFAULT '2',
  `Email` varchar(80) NOT NULL,
  `Senha` varchar(20) NOT NULL,
  `Matricula` varchar(9) NOT NULL,
  `Nome` varchar(250) NOT NULL,
  `Cpf` int(11) NOT NULL,
  `DataNascimento` datetime(6) NOT NULL,
  `Telefone` int(10) NOT NULL,
  `Celular` int(11) NOT NULL,
  `Sexo` int(1) NOT NULL,
  `Rua` varchar(200) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Numero` int(10) NOT NULL,
  `Complemento` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aparelho`
--

CREATE TABLE `aparelho` (
  `IdAparelho` int(11) NOT NULL,
  `Nome` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `avaliacao`
--

CREATE TABLE `avaliacao` (
  `IdAvaliacao` int(11) NOT NULL,
  `IdAluno` int(11) NOT NULL,
  `IdProfessor` int(11) NOT NULL,
  `Data` datetime(6) NOT NULL,
  `Altura` decimal(4,0) NOT NULL,
  `Peso` decimal(4,0) NOT NULL,
  `Imc` decimal(4,0) NOT NULL,
  `BracoDireito` decimal(4,0) NOT NULL,
  `BracoEsquerdo` decimal(4,0) NOT NULL,
  `Peitoral` decimal(4,0) NOT NULL,
  `Abdomem` decimal(4,0) NOT NULL,
  `Quadril` decimal(4,0) NOT NULL,
  `QuadricepsDireito` decimal(4,0) NOT NULL,
  `QuadricepsEsquerdo` decimal(4,0) NOT NULL,
  `PanturrilhaDireita` decimal(4,0) NOT NULL,
  `PanturrilhaEsqueda` decimal(4,0) NOT NULL,
  `DobraCutaneaPeito` decimal(4,0) NOT NULL,
  `DobraCutaneaTriceps` decimal(4,0) NOT NULL,
  `DobraCutaneaAbdomem` decimal(4,0) NOT NULL,
  `DobraCutaneaQuadril` decimal(4,0) NOT NULL,
  `DobraCutaneaPanturrilha` decimal(4,0) NOT NULL,
  `DobraCutaneaCoxa` decimal(4,0) NOT NULL,
  `PercentualGordura` decimal(4,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `exercicio`
--

CREATE TABLE `exercicio` (
  `IdExercicio` int(11) NOT NULL,
  `IdAparelho` int(11) NOT NULL,
  `Nome` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `ficha`
--

CREATE TABLE `ficha` (
  `IdFicha` int(11) NOT NULL,
  `IdExercicio` int(11) NOT NULL,
  `IdProfessor` int(11) NOT NULL,
  `IdAluno` int(11) NOT NULL,
  `IdSerie` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `professor`
--

CREATE TABLE `professor` (
  `IdProfessor` int(11) NOT NULL,
  `IdAgenda` int(11) NOT NULL,
  `IdUnidade` int(11) NOT NULL,
  `Permissao` int(1) NOT NULL DEFAULT '1',
  `Email` varchar(80) NOT NULL,
  `Senha` varchar(20) NOT NULL,
  `Cref` varchar(9) NOT NULL,
  `Nome` varchar(250) NOT NULL,
  `Cpf` int(11) NOT NULL,
  `DataNascimento` datetime(6) NOT NULL,
  `DataAdmissao` datetime(6) NOT NULL,
  `Telefone` int(10) NOT NULL,
  `Celular` int(11) NOT NULL,
  `Sexo` int(1) NOT NULL,
  `Rua` varchar(200) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Numero` int(10) NOT NULL,
  `Complemento` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `serie`
--

CREATE TABLE `serie` (
  `IdSerie` int(11) NOT NULL,
  `IdExercicio` int(11) NOT NULL,
  `IdFicha` int(11) NOT NULL,
  `Nome` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `unidade`
--

CREATE TABLE `unidade` (
  `IdUnidade` int(11) NOT NULL,
  `IdProfessor` int(11) NOT NULL,
  `Nome` varchar(250) NOT NULL,
  `Rua` varchar(200) NOT NULL,
  `Bairro` varchar(50) NOT NULL,
  `Numero` int(10) NOT NULL,
  `Complemento` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agenda`
--
ALTER TABLE `agenda`
  ADD PRIMARY KEY (`IdAgenda`),
  ADD KEY `IdAluno` (`IdAluno`),
  ADD KEY `IdProfessor` (`IdProfessor`);

--
-- Indexes for table `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`IdAluno`,`Cpf`,`Email`,`Matricula`),
  ADD KEY `IdAvaliacao` (`IdAvaliacao`),
  ADD KEY `IdFicha` (`IdFicha`);

--
-- Indexes for table `aparelho`
--
ALTER TABLE `aparelho`
  ADD PRIMARY KEY (`IdAparelho`);

--
-- Indexes for table `avaliacao`
--
ALTER TABLE `avaliacao`
  ADD PRIMARY KEY (`IdAvaliacao`),
  ADD KEY `IdAluno` (`IdAluno`),
  ADD KEY `IdProfessor` (`IdProfessor`);

--
-- Indexes for table `exercicio`
--
ALTER TABLE `exercicio`
  ADD PRIMARY KEY (`IdExercicio`),
  ADD KEY `IdAparelho` (`IdAparelho`);

--
-- Indexes for table `ficha`
--
ALTER TABLE `ficha`
  ADD PRIMARY KEY (`IdFicha`),
  ADD KEY `IdAluno` (`IdAluno`),
  ADD KEY `IdProfessor` (`IdProfessor`),
  ADD KEY `IdExercicio` (`IdExercicio`),
  ADD KEY `IdSerie` (`IdSerie`);

--
-- Indexes for table `professor`
--
ALTER TABLE `professor`
  ADD PRIMARY KEY (`IdProfessor`,`Cpf`,`Cref`,`Email`),
  ADD KEY `IdAgenda` (`IdAgenda`),
  ADD KEY `IdUnidade` (`IdUnidade`);

--
-- Indexes for table `serie`
--
ALTER TABLE `serie`
  ADD PRIMARY KEY (`IdSerie`),
  ADD KEY `IdFicha` (`IdFicha`),
  ADD KEY `IdExercicio` (`IdExercicio`);

--
-- Indexes for table `unidade`
--
ALTER TABLE `unidade`
  ADD PRIMARY KEY (`IdUnidade`),
  ADD KEY `IdProfessor` (`IdProfessor`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agenda`
--
ALTER TABLE `agenda`
  MODIFY `IdAgenda` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aluno`
--
ALTER TABLE `aluno`
  MODIFY `IdAluno` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aparelho`
--
ALTER TABLE `aparelho`
  MODIFY `IdAparelho` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `avaliacao`
--
ALTER TABLE `avaliacao`
  MODIFY `IdAvaliacao` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `exercicio`
--
ALTER TABLE `exercicio`
  MODIFY `IdExercicio` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ficha`
--
ALTER TABLE `ficha`
  MODIFY `IdFicha` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `professor`
--
ALTER TABLE `professor`
  MODIFY `IdProfessor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `serie`
--
ALTER TABLE `serie`
  MODIFY `IdSerie` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `unidade`
--
ALTER TABLE `unidade`
  MODIFY `IdUnidade` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `agenda`
--
ALTER TABLE `agenda`
  ADD CONSTRAINT `agenda_ibfk_1` FOREIGN KEY (`IdAluno`) REFERENCES `aluno` (`IdAluno`),
  ADD CONSTRAINT `agenda_ibfk_2` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`);

--
-- Limitadores para a tabela `aluno`
--
ALTER TABLE `aluno`
  ADD CONSTRAINT `aluno_ibfk_2` FOREIGN KEY (`IdAvaliacao`) REFERENCES `avaliacao` (`IdAvaliacao`),
  ADD CONSTRAINT `aluno_ibfk_3` FOREIGN KEY (`IdFicha`) REFERENCES `ficha` (`IdFicha`);

--
-- Limitadores para a tabela `avaliacao`
--
ALTER TABLE `avaliacao`
  ADD CONSTRAINT `avaliacao_ibfk_1` FOREIGN KEY (`IdAluno`) REFERENCES `aluno` (`IdAluno`),
  ADD CONSTRAINT `avaliacao_ibfk_2` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`);

--
-- Limitadores para a tabela `exercicio`
--
ALTER TABLE `exercicio`
  ADD CONSTRAINT `exercicio_ibfk_1` FOREIGN KEY (`IdAparelho`) REFERENCES `aparelho` (`IdAparelho`);

--
-- Limitadores para a tabela `ficha`
--
ALTER TABLE `ficha`
  ADD CONSTRAINT `ficha_ibfk_1` FOREIGN KEY (`IdAluno`) REFERENCES `aluno` (`IdAluno`),
  ADD CONSTRAINT `ficha_ibfk_2` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`),
  ADD CONSTRAINT `ficha_ibfk_3` FOREIGN KEY (`IdExercicio`) REFERENCES `exercicio` (`IdExercicio`),
  ADD CONSTRAINT `ficha_ibfk_4` FOREIGN KEY (`IdSerie`) REFERENCES `serie` (`IdSerie`);

--
-- Limitadores para a tabela `professor`
--
ALTER TABLE `professor`
  ADD CONSTRAINT `professor_ibfk_1` FOREIGN KEY (`IdAgenda`) REFERENCES `agenda` (`IdAgenda`),
  ADD CONSTRAINT `professor_ibfk_2` FOREIGN KEY (`IdUnidade`) REFERENCES `unidade` (`IdUnidade`);

--
-- Limitadores para a tabela `serie`
--
ALTER TABLE `serie`
  ADD CONSTRAINT `serie_ibfk_1` FOREIGN KEY (`IdFicha`) REFERENCES `ficha` (`IdFicha`),
  ADD CONSTRAINT `serie_ibfk_2` FOREIGN KEY (`IdExercicio`) REFERENCES `exercicio` (`IdExercicio`);

--
-- Limitadores para a tabela `unidade`
--
ALTER TABLE `unidade`
  ADD CONSTRAINT `unidade_ibfk_1` FOREIGN KEY (`IdProfessor`) REFERENCES `professor` (`IdProfessor`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
