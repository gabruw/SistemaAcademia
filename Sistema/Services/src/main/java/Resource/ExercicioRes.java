package Resource;

import Model.Exercicio;
import DTO.ExercicioDTO;

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
@RequestMapping("/exercicio")
public class ExercicioRes {
    @Autowired
    ExercicioRes Exercicio;

    @PersistenceContext
    EntityManager EntityM;
    
    @PostMapping("/search")
    public Exercicio getAllExercicio(@RequestBody ExercicioDTO exercicio) {
        try {
            Query query = EntityM.createQuery("SELECT * FROM Exercicio");
            
            return (Exercicio) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Exercicio getExercicioById(@RequestBody ExercicioDTO exercicio) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Exercicio u WHERE u.IdExercicio = :idExercicio");
            query.setParameter("idExercicio", exercicio.getIdExercicio());

            return (Exercicio) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Aparelho getAparelhoByExercicio(@RequestBody ExercicioDTO exercicio) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Exercicio u WHERE u.IdExercicio = :idExercicio "
                    + "INNER JOIN Aparelho k ON k.IdAparelho = u.IdAparelho "
                    + "WHERE k.IdAparelho = u.idAparelho");
            query.setParameter("idExercicio", exercicio.getIdExercicio());
            query.setParameter("idAparelho", exercicio.getIdAparelho());

            return (Aparelho) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    public boolean includeExercicio(@RequestBody ExercicioDTO exercicio){
        try {

            Query query = EntityM.createQuery("INSERT INTO Exercicio(IdAparelho, Nome, Observacao)" + 
                            " values(:IdAparelho, :Nome, :Observacao)"
            );

            query.setParameter("IdAparelho", avaliacao.getIdAparelho());
            query.setParameter("Nome", avaliacao.getNome());
            query.setParameter("Observacao", avaliacao.getObservacao());

            return true;
            
        } catch (NoResultException e) {
            return false;
        }
    }
}
