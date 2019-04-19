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
@Table(name = "serie")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Serie.findAll", query = "SELECT u FROM Serie u"),
    @NamedQuery(name = "Serie.findByIdSerie", query = "SELECT u FROM Serie u WHERE u.IdSerie = :IdSerie"),
    @NamedQuery(name = "Serie.findByIdExercicio", query = "SELECT u FROM Serie u WHERE u.IdExercicio = :IdExercicio"),
    @NamedQuery(name = "Serie.findByIdFicha", query = "SELECT u FROM Serie u WHERE u.IdFicha = :IdFicha"),
    @NamedQuery(name = "Serie.findByNome", query = "SELECT u FROM Serie u WHERE u.Nome = :Nome")
})

@Data
public class Serie implements Serializable{    
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdSerie")
    private int IdSerie;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdExercicio")
    private Exercicio IdExercicio;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdFicha")
    private Ficha IdFicha;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 200)
    @Column(name = "Nome")
    private String Nome;  
}