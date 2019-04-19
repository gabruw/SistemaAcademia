package Repository;

import Model.Agenda;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AgendaRep extends JpaRepository<Agenda, Integer>{  
    public Agenda findByIdAgenda(int IdAgenda);
    
    public Agenda findByIdProfessor(int IdProfessor);
    
    public Agenda findByIdALuno(int IdAluno);   
}