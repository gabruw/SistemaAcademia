package DTO;

import lombok.Data;

@Data
public class Professor {
    private int IdProfessor;
    private int IdUnidade;  
    private String Rua;
    private String Bairro;
    private int Numero;
    private int Complemento;
    private int Cep;
    private int Cpf;
    private String Cref;
    private String Nome;
    private String Email;
    private String Senha;    
}