package Repository;

import Model.Unidade;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UnidadeRep extends JpaRepository<Unidade, Integer>{  
    public Unidade findByIdUnidade(int IdUnidade);
    
    public Unidade findByIdProfessor(int IdProfessor);
    
    public Unidade findByNome(String Nome);
    
    public Unidade findByRua(String Rua);
    
    public Unidade findByBairro(String Bairro);   
}