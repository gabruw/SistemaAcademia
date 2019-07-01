package Model;

import java.io.Serializable;
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
@Table(name = "unidade")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Unidade.findAll", query = "SELECT u FROM Unidade u"),
    @NamedQuery(name = "Unidade.findByIdUnidade", query = "SELECT u FROM Unidade u WHERE u.IdUnidade = :IdUnidade"),
    @NamedQuery(name = "Unidade.findByIdProfessor", query = "SELECT u FROM Unidade u WHERE u.IdProfessor = :IdProfessor"),
    @NamedQuery(name = "Unidade.findByNome", query = "SELECT u FROM Unidade u WHERE u.Nome = :Nome"),
    @NamedQuery(name = "Unidade.findByRua", query = "SELECT u FROM Unidade u WHERE u.Rua = :Rua"),
    @NamedQuery(name = "Unidade.findByBairro", query = "SELECT u FROM Unidade u WHERE u.Bairro = :Bairro")
})

@Data
public class Unidade implements Serializable{
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdUnidade")
    private int IdUnidade;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdProfessor")
    private Professor IdProfessor;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 250)
    @Column(name = "Nome")
    private String Nome;
    
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
    @Size(min = 0, max = 10)
    @Column(name = "Complemento")
    private int Complemento;  
}