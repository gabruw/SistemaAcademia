package Resource;

import Model.Aluno;
import Model.Avaliacao;
import Model.Professor;
import antlr.collections.List;
import DTO.AvaliacaoDTO;

import java.util.ArrayList;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/avaliacao")
public class AvaliacaoRes {
    @Autowired
    AvaliacaoRes Avaliacao;

    @PersistenceContext
    EntityManager EntityM;
    
    


    //localhost:8080/avaliacao/aluno/1
    @GetMapping("/aluno/{idAluno}")
    public List<Avaliacao> getAvaliacaoByAluno(@PathVariable int idAluno) {
        Query query = EntityM.createQuery("SELECT u FROM Avaliacao u "+
        " WHERE u.idAluno.idAluno = :idAluno ");
        query.setParameter("idAluno", idAluno);

        return query.getListResult();
    }

    @GetMapping("/{id}")
    public Aluno getAlunoByAvaliacao(@PathVariable int id) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u "+
            " WHERE u.Aluno.IdAluno = :id ");
            //query.setParameter("idAluno", avaliacao.getIdAluno());
            query.setParameter("id", id);

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    
    @PostMapping
    public boolean includeAvaliacao(@RequestBody AvaliacaoDTO avaliacao) {
        try {

            Aluno a = new Aluno();
            a.setIdAluno(avaliacao.getIdAluno());

            Professor p = new Professor();
            a.setIdProfessor(avaliacao.getIdProfessor());


            Avaliacao ava = new Avaliacao();
            ava.setIdAluno( a );
            ava.setNome( p );
            ava.setDate( avaliacao.getData() );
            ava.setAltura( avaliacao.getAltura() );
            ava.setPeso( avaliacao.getPeso() );
            ava.setImc( avaliacao.getImc() );
            ava.setBracoDireito( avaliacao.getBracoDireito() );
            ava.setBracoEsquerdo( avaliacao.getBracoEsquerdo() );
            ava.setPeitoral( avaliacao.getPeitoral() );
            ava.setAbdomem( avaliacao.getAbdomem() );
            ava.setQuadril( avaliacao.getQuadril() );
            ava.setQuadricepsDireito( avaliacao.getQuadricepsDireito() );
            ava.setQuadricepsEsquerdo( avaliacao.getQuadricepsEsquerdo() );
            ava.setPanturrilhaDireita( avaliacao.getPanturrilhaDireita() );
            ava.setPanturrilhaEsqueda( avaliacao.getPanturrilhaEsqueda() );
            ava.setDobraCutaneaPeito( avaliacao.getDobraCutaneaPeito() );
            ava.setDobraCutaneaTriceps( avaliacao.getDobraCutaneaTriceps() );
            ava.setDobraCutaneaAbdomem( avaliacao.getDobraCutaneaAbdomem() );
            ava.setDobraCutaneaQuadril( avaliacao.getDobraCutaneaQuadril() );
            ava.setDobraCutaneaPanturrilha( avaliacao.getDobraCutaneaPanturrilha() );
            ava.setDobraCutaneaCoxa( avaliacao.getDobraCutaneaCoxa() );
            ava.setPercentualGordura( avaliacao.getPercentualGordura() );
            ava.setObservacao( avaliacao.getObservacao() );
 
           

            EntityM.persite(ava);

            return true;
        } catch (NoResultException e) {
            return false;
        }
    }
}
