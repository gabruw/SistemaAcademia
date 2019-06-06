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
    public Professor getProfessorByEmail(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.email = :email");
            query.setParameter("email", perofessor.getEmail());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Professor getProfessorByEmailAndSenha(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.Email = :email AND u.Senha = :senha");
            query.setParameter("email", professor.getEmail());
            query.setParameter("senha", professor.getSenha());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    @PostMapping("/search")
    public Professor getAllUsers(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT * FROM Professor");
            
            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Professor getProfessorById(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.idProfessor = :idProfessor");
            query.setParameter("idProfessor", professor.getIdProfessor());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Professor getProfessorByCpf(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.cpf = :cpf");
            query.setParameter("cpf", professor.getCpf());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Professor getProfessorByCref(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.cref = :cref");
            query.setParameter("cref", professor.getCref());

            return (Professor) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Agenda getAgendaByProfessor(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.IdProfessor = :IdProfessor "
                    + "INNER JOIN Agenda k ON k.IdAgenda = u.IdAgenda "
                    + "WHERE k.IdAgenda = u.idAgenda");
            query.setParameter("idProfessor", professor.getIdProfessor());
            query.setParameter("idAgenda", professor.getIdAgenda());

            return (Agenda) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
     public Unidade getUnidadeByProfessor(@RequestBody ProfessorDTO professor) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Professor u WHERE u.IdProfessor = :IdProfessor "
                    + "INNER JOIN Unidade k ON k.IdUnidade = u.IdUnidade "
                    + "WHERE k.IdUnidade = u.idUnidade");
            query.setParameter("idProfessor", professor.getIdProfessor());
            query.setParameter("idUnidade", professor.getIdUnidade());

            return (Unidade) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
}
