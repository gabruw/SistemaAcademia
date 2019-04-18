
package Repository;

import Model.Serie;
import org.springframework.data.jpa.repository.JpaRepository;


public interface SerieRep extends JpaRepository<Serie, Integer>{
    
    public Serie findByIdSerie(int idSerie);
    public Serie findByIdExercicio(int idExercicio);
    public Serie findByIdFicha(int idFicha);
    public Serie findByNome(String nome);
}
