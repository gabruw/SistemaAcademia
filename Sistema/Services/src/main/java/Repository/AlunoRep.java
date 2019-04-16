package Repository;

import org.springframework.data.jpa.repository.JpaRepository;

public interface AlunoRep extends JpaRepository<AlunoRep, Integer>{
    public AlunoRep findByEmailAndSenha(String Email, String Senha);
}
