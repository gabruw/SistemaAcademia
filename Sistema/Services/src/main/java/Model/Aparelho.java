
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
@Table(name = "aparelho")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Aparelho.findAll", query = "SELECT u FROM Aparelho u"),
    @NamedQuery(name = "Aparelho.findByIdAparelho", query = "SELECT u FROM Aparelho u WHERE u.IdAparelho = :IdAparelho"),
    @NamedQuery(name = "Aparelho.findByIdAparelho", query = "SELECT u FROM Aparelho u WHRE u.Nome = :Nome")
    
})

@Data
public class Aparelho implements Serializable{
    
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdAparelho")
    private int IdAparelho;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 4, max = 20)
    @Column(name = "Nome")
    private int Nome;
    
}
