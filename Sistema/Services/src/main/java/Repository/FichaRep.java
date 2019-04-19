package Repository;

import Model.Ficha;
import org.springframework.data.jpa.repository.JpaRepository;

public interface FichaRep extends JpaRepository<Ficha, Integer>{
    public Ficha findByIdFicha(int IdFicha);
    
    public Ficha findByIdExercicio(int IdExercicio);
    
    public Ficha findByIdSerie(int IdSerie);
    
    public Ficha findByIdAluno(int IdAluno);
    
    public Ficha findByIdProfessor(int IdProfessor);   
}