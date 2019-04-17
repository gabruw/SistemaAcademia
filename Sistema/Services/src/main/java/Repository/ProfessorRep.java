package Repository;

import Model.Professor;
import java.util.Date;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProfessorRep extends JpaRepository<Professor, Integer>{
    public Professor findByIdProfessor(int IdProfessor);
    
    public Professor findByCref(String Cref);
    
    public Professor findByNome(String Nome);
    
    public Professor findByCpf(int Cpf);
    
    public Professor findByDataAdmissao(Date DataAdmissao);
    
    public Professor findBySexo(int Sexo);
    
    public Professor findByEmailAndSenha(String Email, String Senha);
}