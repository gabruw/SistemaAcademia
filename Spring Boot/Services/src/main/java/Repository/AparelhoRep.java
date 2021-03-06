package Repository;

import Model.Aparelho;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AparelhoRep extends JpaRepository<Aparelho, Integer>{
    public Aparelho findByIdAparelho(int IdAparelho);
    
    public Aparelho findByNome(String Nome);   
}