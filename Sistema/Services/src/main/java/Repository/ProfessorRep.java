package Repository;

import Model.Professor;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ProfessorRep extends JpaRepository<Professor, Integer>{
    public Professor findByEmailAndSenha(String Email, String Senha);
}
