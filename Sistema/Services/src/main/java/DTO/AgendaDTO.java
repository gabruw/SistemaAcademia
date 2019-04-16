package DTO;

import java.util.Date;
import lombok.Data;

@Data
public class AgendaDTO {
    private int IdAgenda;
    private int IdProfessor;
    private int IdAluno;
    private String NomeAluno;
    private String NomeProfessor;
    private Date Data;
}