
package Repository;

import Model.Ficha;
import org.springframework.data.jpa.repository.JpaRepository;


public interface FichaRep extends JpaRepository<Ficha, Integer>{
    
    public Ficha findByIdFicha(int idFicha);
    public Ficha findByIdExercicio(int idExercicio);
    public Ficha findByIdSerie(int idSerie);
    public Ficha findByIdAluno(int idAluno);
    public Ficha findByIdProfessor(int idProfessor);
    
}
