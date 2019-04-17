package Model;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import lombok.Data;

@Entity
@Table(name = "professor")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Professor.findAll", query = "SELECT u FROM Professor u"),
    @NamedQuery(name = "Professor.findByIdAluno", query = "SELECT u FROM Professor u WHERE u.IdProfessor = :IdProfessor"),
    @NamedQuery(name = "Professor.findByMatricula", query = "SELECT u FROM Professor u WHERE u.Cref = :Cref"),
    @NamedQuery(name = "Professor.findByNome", query = "SELECT u FROM Professor u WHERE u.Nome = :Nome"),
    @NamedQuery(name = "Professor.findBySexo", query = "SELECT u FROM Professor u WHERE u.Sexo = :Sexo"),
    @NamedQuery(name = "Professor.findByCpf", query = "SELECT u FROM Professor u WHERE u.Cpf = :Cpf"),
    @NamedQuery(name = "Professor.findByEmail", query = "SELECT u FROM Professor u WHERE u.Email = :Email"),
    @NamedQuery(name = "Professor.findByEmailAndSenha", query = "SELECT u FROM Professor u WHERE u.Email = :Email AND u.Senha = :Senha")
})

@Data
public class Professor implements Serializable {
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdProfessor")
    private int IdProfessor;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdUnidade")
    private Unidade IdUnidade;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdAgenda")
    private Agenda IdAgenda;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 1)
    @Column(name = "Permissao")
    private int Permissao = 1;

    @Basic(optional = false)
    @NotNull
    @Size(min = 5, max = 80)
    @Column(name = "Email")
    private String Email;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 6, max = 20)
    @Column(name = "Senha")
    private String Senha;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 9, max = 9)
    @Column(name = "Cref")
    private String Cref;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 250)
    @Column(name = "Nome")
    private String Nome;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 11, max = 11)
    @Column(name = "Cpf")
    private int Cpf;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 9, max = 9)
    @Column(name = "DataNascimento")
    private Date DataNascimento;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 9, max = 9)
    @Column(name = "DataAdmissao")
    private Date DataAdmissao;
    
    @Basic(optional = false)
    @Size(min = 10, max = 10)
    @Column(name = "Telefone")
    private int Telefone;
    
    @Basic(optional = false)
    @Size(min = 11, max = 11)
    @Column(name = "Celular")
    private int Celular;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 1)
    @Column(name = "Sexo")
    private int Sexo;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 200)
    @Column(name = "Rua")
    private String Rua;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 50)
    @Column(name = "Bairro")
    private String Bairro;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 10)
    @Column(name = "Numero")
    private int Numero;
    
    @Basic(optional = false)
    @Size(min = 1, max = 10)
    @Column(name = "Complemento")
    private int Complemento;
}