package Repository;

import Model.Serie;
import org.springframework.data.jpa.repository.JpaRepository;

public interface SerieRep extends JpaRepository<Serie, Integer>{  
    public Serie findByIdSerie(int IdSerie);
    
    public Serie findByIdExercicio(int IdExercicio);
    
    public Serie findByIdFicha(int IdFicha);
    
    public Serie findByNome(String Nome);
}