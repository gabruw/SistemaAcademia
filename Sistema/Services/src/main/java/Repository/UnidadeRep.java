
package Repository;

import Model.Unidade;
import org.springframework.data.jpa.repository.JpaRepository;


public interface UnidadeRep extends JpaRepository<Unidade, Integer>{
    
    public Unidade findByIdUnidade(int idUnidade);
    public Unidade findByIdProfessor(int idProfessor);
    public Unidade findByNome(String nome);
    public Unidade findByRua(String rua);
    public Unidade findByBairro(String bairro);
    
}
