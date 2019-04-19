
package Repository;

import Model.Agenda;
import java.util.Date;
import org.springframework.data.jpa.repository.JpaRepository;


public interface AgendaRep extends JpaRepository<Agenda, Integer>{
    
    public Agenda findByIdAgenda(int idAgenda);
    public Agenda findByIdProfessor(int idProfessor);
    public Agenda findByIdALuno(int idAluno);
    
}
