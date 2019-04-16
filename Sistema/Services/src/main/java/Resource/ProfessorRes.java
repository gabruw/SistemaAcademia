package Resource;

import Model.Professor;
import DTO.ProfessorDTO;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/professor")
public class ProfessorRes {
    @Autowired
    ProfessorRes Professores;

    @PersistenceContext
    EntityManager EntityM;
    
    @PostMapping("/login")
    public Professor getAllUsers(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.Email = :email " + "and u.Senha = :senha");
            query.setParameter("email", professor.getEmail());
            query.setParameter("senha", professor.getSenha());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
}
