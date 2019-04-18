
package Repository;

import Model.Avaliacao;
import org.springframework.data.jpa.repository.JpaRepository;


public interface AvaliacaoRep extends JpaRepository<Avaliacao, Integer>{
    
    public Avaliacao findByIdAvaliacao(int idAvaliacao);
    public Avaliacao findByIdAluno(int idAluno);
    public Avaliacao findByIdProfessor(int idProfessor);
    
}
