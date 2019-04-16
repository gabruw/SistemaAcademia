package DTO;

import lombok.Data;

@Data
public class UnidadeDTO {
    private int IdUnidade;
    private int IdProfessor;
    private String Rua;
    private String Bairro;
    private int Numero;
    private int Complemento;
    private int Cep;
}
