package Repository;

import Model.Aluno;
import org.springframework.data.jpa.repository.JpaRepository;

public interface AlunoRep extends JpaRepository<Aluno, Integer>{
    public Aluno findByIdAluno(int IdAluno);
    
    public Aluno findByMatricula(String Matricula);
    
    public Aluno findByNome(String Nome);
    
    public Aluno findBySexo(int Sexo);
    
    public Aluno findByCpf(int Cpf);
    
    public Aluno findByEmail(String Email);
    
    public Aluno findByEmailAndSenha(String Email, String Senha);
}