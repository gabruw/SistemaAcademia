package Repository;

import Model.Aluno;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AlunoRep extends JpaRepository<Aluno, Integer>{
    public Aluno findByEmailAndSenha(String Email, String Senha);
}
