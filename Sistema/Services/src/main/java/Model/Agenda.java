
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
@Table(name = "agenda")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Agenda.findAll", query = "SELECT u FROM Agenda u"),
    @NamedQuery(name = "Aluno.findByIdAgenda", query = "SELECT u FROM Agenda u WHERE u.IdAgenda = :IdAgenda"),
    @NamedQuery(name = "Agenda.findByIdProfessor", query = "SELECT u FROM Agenda u WHERE u.IdProfessor = :IdProfessor"),
    @NamedQuery(name = "Agenda.findByIdAluno", query = "SELECT u FROM Agenda u WHERE u.IdAluno = :IdAluno")
})


@Data
public class Agenda implements Serializable{
    
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdAgenda")
    private int IdAgenda;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdProfessor")
    private Professor IdProfessor;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdAluno")
    private Aluno IdAluno;
    
    @Basic(optional = false)
    @NotNull
    @Column(name = "Data")
    private Data Data;
    
}
