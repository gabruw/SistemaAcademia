package Resource;

import DTO.AlunoDTO;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

public class AlunoRes {
    @Autowired
    AlunoRes Alunos;

    @PersistenceContext
    EntityManager EntityM;
    
    @PostMapping("/login")
    public AlunoRes getAllUsers(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.Email = :email " + "and u.Senha = :senha");
            query.setParameter("email", aluno.getEmail());
            query.setParameter("senha", aluno.getSenha());

            return (AlunoRes) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
}
