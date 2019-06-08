package Resource;

import Model.Avaliacao;
import DTO.AvaliacaoDTO;

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
@RequestMapping("/avaliacao")
public class AvaliacaoRes {
    @Autowired
    AvaliacaoRes Avaliacao;

    @PersistenceContext
    EntityManager EntityM;
    
    //localhost:8080/avaliacao/all
    @GetMapping("/all")
    public List<Avaliacao> getAllAvaliacao() {
            Query query = EntityM.createQuery("SELECT a FROM Avaliacao a");
            
            return query.getListResult();
            return null;
    }
    


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
            Query query = EntityM.createQuery("SELECT u.IdAluno FROM Avaliacao u "+
            " WHERE u.idAvaliacao = :idAvaliacao ");
            //query.setParameter("idAluno", avaliacao.getIdAluno());
            query.setParameter("idAvaliacao", id);

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
/*
            Query query = EntityM.createQuery("INSERT INTO Avaliacao(IdAluno, IdProfessor, Data, Altura," + 
                            " Peso, Imc, BracoDireito, BracoEsquerdo, Peitoral, Abdomem, Quadril," +
                            " QuadricepsDireito, QuadrcepsEsquerdo, PanturrilhaDireita, PanturrilhaEsquerda," +
                            " DobraCutaneaPeito, DobraCutaneaCoxa, DobraCutaneaTriceps, DobraCutaneaAbdomem," +
                            " DobraCutaneaQuadril, DobraCutaneaPanurrilha, PercentualGordura, Observacao) VALUES("+
                            " :IdAluno, :IdProfessor, :Data, :Altura," + 
                            " :Peso, :Imc, :BracoDireito, :BracoEsquerdo, :Peitoral, :Abdomem, :Quadril," +
                            " :QuadricepsDireito, :QuadrcepsEsquerdo, :PanturrilhaDireita, :PanturrilhaEsquerda," +
                            " :DobraCutaneaPeito, :DobraCutaneaCoxa, :DobraCutaneaTriceps, :DobraCutaneaAbdomem," +
                            " :DobraCutaneaQuadril, :DobraCutaneaPanurrilha, :PercentualGordura, :Observacao)"
            );
            query.setParameter("IdAluno", avaliacao.getIdAluno());
            query.setParameter("IdProfessor", avaliacao.getIdProfessor());
            query.setParameter("Data", avaliacao.getData());
            query.setParameter("Altura", avaliacao.getAltura());
            query.setParameter("Peso", avaliacao.getPeso());
            query.setParameter("Imc", avaliacao.getImc());
            query.setParameter("BracoDireito", avaliacao.getBracoDireito());
            query.setParameter("BracoEsquerdo", avaliacao.getBracoEsquerdo());
            query.setParameter("Peitoral", avaliacao.getPeitoral());
            query.setParameter("Abdomem", avaliacao.getAbdomem());
            query.setParameter("Quadril", avaliacao.getQuadril());
            query.setParameter("QuadricepsDireito", avaliacao.getQuadricepsDireito());
            query.setParameter("QuadrcepsEsquerdo", avaliacao.getQuadrcepsEsquerdo());
            query.setParameter("PanturrilhaDireita", avaliacao.getPanturrilhaDireita());
            query.setParameter("PanturrilhaEsquerda", avaliacao.getPanturrilhaEsquerda());
            query.setParameter("DobraCutaneaPeito", avaliacao.getDobraCutaneaPeito());
            query.setParameter("DobraCutaneaCoxa", avaliacao.getDobraCutaneaCoxa());
            query.setParameter("DobraCutaneaTriceps", avaliacao.getDobraCutaneaTriceps());
            query.setParameter("DobraCutaneaAbdomem", avaliacao.getDobraCutaneaAbdomem());
            query.setParameter("DobraCutaneaQuadril", avaliacao.getDobraCutaneaQuadril());
            query.setParameter("DobraCutaneaPanurrilha", avaliacao.getDobraCutaneaPanurrilha());
            query.setParameter("PercentualGordura", avaliacao.getPercentualGordura());
            query.setParameter("Observacao", avaliacao.getObservacao());
*/
            return true;
        } catch (NoResultException e) {
            return false;
        }
    }
}
