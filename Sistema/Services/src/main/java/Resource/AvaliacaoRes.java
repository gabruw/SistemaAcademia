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
    
    @PostMapping("/search")
    public Avaliacao getAllAvaliacao(@RequestBody AvaliacaoDTO avaliacao) {
        try {
            Query query = EntityM.createQuery("SELECT * FROM Avaliacao");
            
            return (Avaliacao) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public Aluno getAlunoByAvaliacao(@RequestBody AvaliacaoDTO avaliacao) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Avaliacao u WHERE u.IdAluno = :idAluno "
                    + "INNER JOIN Aluno k ON k.IdAvaliacao = u.IdAvaliacao "
                    + "WHERE k.IdAvaliacao = u.idAvaliacao");
            query.setParameter("idAluno", avaliacao.getIdAluno());
            query.setParameter("idAvaliacao", avaliacao.getIdAvaliacao());

            return (Aluno) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
    public boolean includeAvaliacao(@RequestBody AvaliacaoDTO avaliacao) {
        try {
            Query query = EntityM.createQuery("INSERT INTO Avaliacao(IdAluno, IdProfessor, Data, Altura," + 
                            " Peso, Imc, BracoDireito, BracoEsquerdo, Peitoral, Abdomem, Quadril," +
                            " QuadricepsDireito, QuadrcepsEsquerdo, PanturrilhaDireita, PanturrilhaEsquerda," +
                            " DobraCutaneaPeito, DobraCutaneaCoxa, DobraCutaneaTriceps, DobraCutaneaAbdomem," +
                            " DobraCutaneaQuadril, DobraCutaneaPanurrilha, PercentualGordura, Observacao) VALUES("+
                            " :IdAluno, :IdProfessor, :Data, :Altura," + 
                            " :Peso, :Imc, :BracoDireito, :BracoEsquerdo, :Peitoral, :Abdomem, :Quadril," +
                            " :QuadricepsDireito, :QuadrcepsEsquerdo, :PanturrilhaDireita, :PanturrilhaEsquerda," +
                            " :DobraCutaneaPeito, :DobraCutaneaCoxa, :DobraCutaneaTriceps, :DobraCutaneaAbdomem," +
                            " :DobraCutaneaQuadril, :DobraCutaneaPanurrilha, :PercentualGordura, :Observacao)")
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

            return true;
        } catch (NoResultException e) {
            return false;
        }
    }
}
