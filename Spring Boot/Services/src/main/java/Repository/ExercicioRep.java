package Repository;

import Model.Exercicio;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ExercicioRep extends JpaRepository<Exercicio, Integer>{ 
    public Exercicio findByIdExercicio(int IdExercicio);
    
    public Exercicio findByIdAparelho(int IdAparelho);
    
    public Exercicio findByNome(String Nome);    
}