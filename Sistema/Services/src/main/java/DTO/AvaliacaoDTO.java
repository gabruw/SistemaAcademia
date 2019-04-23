package DTO;

import java.util.Date;
import lombok.Data;

@Data
public class AvaliacaoDTO {
    private int IdAvaliacao;
    private int IdAluno;
    private int IdProfessor;
    private Date Data;
    private double Altura;
    private double Peso;
    private double Imc;
    private double BracoDireito;
    private double BracoEsquerdo;
    private double Peitoral;
    private double Abdomem;
    private double Quadril;
    private double QuadricepsDireito;
    private double QuadrcepsEsquerdo;
    private double PanturrilhaDireita;
    private double PanturrilhaEsquerda;
    private double DobraCutaneaPeito;
    private double DobraCutaneaCoxa;
    private double DobraCutaneaTriceps;
    private double DobraCutaneaAbdomem;
    private double DobraCutaneaQuadril;
    private double DobraCutaneaPanurrilha;
    private double PercentualGordura;
    private String Observacao;
}