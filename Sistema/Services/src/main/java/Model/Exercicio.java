
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
@Table(name = "Exercicio")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Exercicio.findAll", query = "SELECT u FROM Exercicio u"),
    @NamedQuery(name = "Exercicio.findByIdExercicio", query = "SELECT u FROM Exercicio u WHERE u.IdExercicio = :IdExercicio"),
    @NamedQuery(name = "Exercicio.findByIdAparelho", query = "SELECT u FROM Exercicio u WHERE u.IdAparelho = :IdAparelho"),
    @NamedQuery(name = "Exercicio.findByNome", query = "SELECT u FROM Exercicio u WHERE u.Nome = :Nome")
})

@Data
public class Exercicio implements Serializable{
    
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdExercicio")
    private int IdExercicio;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdAparelho")
    private Avaliacao IdAparelho;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 250)
    @Column(name = "Nome")
    private String Nome;
    
}
