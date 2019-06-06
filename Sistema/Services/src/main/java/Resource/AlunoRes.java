package Resource;

import Model.Aluno;
import DTO.AlunoDTO;

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
@RequestMapping("/aluno")
public class AlunoRes {
    @Autowired
    AlunoRes Alunos;

    @PersistenceContext
    EntityManager EntityM;
    
    @PostMapping("/login")
    public Aluno getAlunoByEmail(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.email = :email");
            query.setParameter("email", aluno.getEmail());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Aluno getAlunoByEmailAndSenha(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.email = :email AND u.senha = :senha");
            query.setParameter("email", aluno.getEmail());
            query.setParameter("senha", aluno.getSenha());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    @PostMapping("/search")
    public Aluno getAllUsers(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT * FROM Aluno");
            
            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Aluno getAlunoById(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.IdAluno = :idAluno");
            query.setParameter("idAluno", aluno.getIdAluno());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Aluno getAlunoByCpf(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.cpf = :cpf");
            query.setParameter("cpf", aluno.getCpf());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Avaliacao getAvaliacaoByAluno(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.IdAluno = :idAluno "
                    + "INNER JOIN Avaliacao k ON k.IdAvaliacao = u.IdAvaliacao "
                    + "WHERE k.IdAvaliacao = u.idAvaliacao");
            query.setParameter("idAluno", aluno.getIdAluno());
            query.setParameter("idAvaliacao", aluno.getIdAvaliacao());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
}
