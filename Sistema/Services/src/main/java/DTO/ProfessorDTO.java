package DTO;

import java.util.Date;
import lombok.Data;

@Data
public class ProfessorDTO {
    private int IdProfessor;
    private int IdUnidade;
    private int IdAgenda;
    private int Permissao;
    private String Email;
    private String Senha;
    private String Cref;
    private String Nome; 
    private int Cpf;
    private Date DataNascimento;
    private Date DataAdmissao;
    private int Telefone;
    private int Celular;
    private int Sexo;
    private String Rua;
    private String Bairro;
    private int Numero;
    private int Complemento;
    private String Imagem;
}