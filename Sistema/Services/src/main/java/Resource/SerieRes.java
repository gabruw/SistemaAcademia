package Resource;

import Model.Serie;
import DTO.SerieDTO;

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
@RequestMapping("/serie")
public class SerieRes {
    @Autowired
    SerieRes Series;

    @PersistenceContext
    EntityManager EntityM;

    public boolean includeSerie(@RequestBody SerieDTO serie){

        try {

            Query query = EntityM.createQuery("INSERT INTO Serie(IdExercicio, IdFicha, Nome, Observacao) " +
                    "values (:IdExercicio, :IdFicha, :Nome, :Observacao)"
            );

            query.setParameter("IdExercicio", avaliacao.getIdExercicio());
            query.setParameter("IdFicha", avaliacao.getIdFicha());
            query.setParameter("Nome", avaliacao.getNome());
            query.setParameter("Observacao", avaliacao.getObservacao());

            return true;
            
        } catch (NoResultException e) {
            return false;
        }

    }
}