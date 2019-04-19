
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
@Table(name = "Ficha")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Ficha.findAll", query = "SELECT u FROM Ficha u"),
    @NamedQuery(name = "Ficha.findByIdFicha", query = "SELECT u FROM Ficha u WHERE u.IdFicha = :IdFicha"),
    @NamedQuery(name = "Ficha.findByIdExercicio", query = "SELECT u FROM Ficha u WHERE u.IdExercicio = :IdExercicio"),
    @NamedQuery(name = "Ficha.findByIdSerie", query = "SELECT u FROM Ficha u WHERE u.IdSerie = :IdSerie"),
    @NamedQuery(name = "Ficha.findByIdAluno", query = "SELECT u FROM Ficha u WHERE u.IdAluno = :IdAluno"),
    @NamedQuery(name = "Ficha.findByIdProfessor", query = "SELECT u FROM Ficha u WHERE u.IdProfessor = :IdProfessor")
})

@Data
public class Ficha implements Serializable{
    
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdFicha")
    private int IdFicha;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdExercicio")
    private Exercicio IdExercicio;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdProfessor")
    private Professor IdProfessor;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdAluno")
    private Aluno IdAluno;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdSerie")
    private Serie IdSerie;
    
}
