package Repository;

import Model.Avaliacao;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AvaliacaoRep extends JpaRepository<Avaliacao, Integer>{
    public Avaliacao findByIdAvaliacao(int IdAvaliacao);
    
    public Avaliacao findByIdAluno(int IdAluno);
    
    public Avaliacao findByIdProfessor(int IdProfessor);   
}