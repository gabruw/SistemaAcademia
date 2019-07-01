package Resource;

import Model.Aluno;
import Model.Avaliacao;
import DTO.AlunoDTO;

import java.util.ArrayList;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.websocket.server.PathParam;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
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

    private String email;
   



    @GetMapping("/{id}")
    public Aluno getAlunoById(@PathVariable int id) {
        try {

            Query query = EntityM.createQuery("SELECT u FROM Aluno u "+
            " WHERE u.IdAluno = :id ");
            query.setParameter("id", id);

            return (Aluno) query.getSingleResult();

        } catch (NoResultException e) {
            return null;
        }
    }

    @GetMapping("/{nome}")
    public Aluno getAlunoByNome(@PathVariable String nome){
        try {

            Query query = EntityM.createQuery("Select u FROM Aluno u "+
                "WHERE u.Nome = :nome"
            );
            query.setParameter("nome", nome);

            return (Aluno) query.getSingleResult();
            
        } catch (NoResultException e) {
            return null;
        }
    }

    @GetMapping("/{email}")
    public Aluno getAlunoByEmail(@PathVariable String email){
        try {

            Query query = EntityM.createQuery("Select u FROM Aluno u "+
                "WHERE u.Email = :email"
            );
            query.setParameter("email", email);

            return (Aluno) query.getSingleResult();
            
        } catch (NoResultException e) {
            return null;
        }
    }

    @GetMapping("/{matricula}")
    public Aluno getAlunoByMatricula(@PathVariable String matricula){
        try {

            Query query = EntityM.createQuery("Select u FROM Aluno u "+
                "WHERE u.Matricula = :matricula"
            );
            query.setParameter("matricula", matricula);

            return (Aluno) query.getSingleResult();
            
        } catch (NoResultException e) {
            return null;
        }
    }

    /*@PostMapping("/login")
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
    public Aluno getAllAluno(@RequestBody AlunoDTO aluno) {
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

            return (Avaliacao) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }
    
     public Ficha getFichaByAluno(@RequestBody AlunoDTO aluno) {
        try {
            Query query = EntityM.createQuery("SELECT u FROM Aluno u WHERE u.IdAluno = :idAluno "
                    + "INNER JOIN Ficha k ON k.IdFicha = u.IdFicha "
                    + "WHERE k.IdFicha = u.idFicha");
            query.setParameter("idAluno", aluno.getIdAluno());
            query.setParameter("idFicha", aluno.getIdFicha());

            return (Ficha) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    public boolean includeAluno(@RequestBody AlunoDTO aluno){
        try {

            Query query = EntityM.createQuery("INSERT INTO Aluno(IdFicha, IdAvaliacao, Permissao, Email, " +
                    "Senha, Matricula, Nome, Cpf, DataNascimento, Telefone, Celular, Sexo, Rua, Bairro, " +
                    "Numero, Complemento, Imagem) values(:IdFicha, :IdAvaliacao, :Permissao, :Email, " +
                    ":Senha, :Matricula, :Nome, :Cpf, :DataNascimento, :Telefone, :Celular, :Sexo, :Rua, :Bairro, " +
                    ":Numero, :Complemento, :Imagem)"
            );

            query.setParameter("IdFicha", avaliacao.getIdFicha());
            query.setParameter("IdAvaliacao", avaliacao.getIdAvaliacao());
            query.setParameter("Permissao", avaliacao.getPermissao());
            query.setParameter("Email", avaliacao.getEmail());
            query.setParameter("Senha", avaliacao.getSenha());
            query.setParameter("Matricula", avaliacao.getMatricula());
            query.setParameter("Nome", avaliacao.getNome());
            query.setParameter("Cpf", avaliacao.getCpf());
            query.setParameter("DataNascimento", avaliacao.getDataNascimento());
            query.setParameter("Telefone", avaliacao.getTelefone());
            query.setParameter("Celular", avaliacao.getCelular());
            query.setParameter("Sexo", avaliacao.getSexo());
            query.setParameter("Rua", avaliacao.getRua());
            query.setParameter("Bairro", avaliacao.getBairro());
            query.setParameter("Numero", avaliacao.getNumero());
            query.setParameter("Complemento", avaliacao.getComplemento());
            query.setParameter("Imagem", avaliacao.getImagem());

            return true;
            
        } catch (NoResultException e) {
            return false;
        }
    }*/
}
