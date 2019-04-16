package DTO;

import java.util.Date;
import lombok.Data;

@Data
public class AlunoDTO {
    private int IdAluno;
    private int IdFicha;
    private int IdAvaliacao;
    private int Permissao;
    private String Matricula;
    private String Nome; 
    private String Email;
    private String Senha;
    private String Rua;
    private String Bairro;
    private Date DataNascimento;
    private int Numero;
    private int Complemento;
    private int Cep;
    private int Cpf;
    private int Telefone;
    private int Celular;
    private int Sexo;
}