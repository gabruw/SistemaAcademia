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
@Table(name = "avaliacao")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Avaliacao.findAll", query = "SELECT u FROM Avaliacao u"),
    @NamedQuery(name = "Avaliacao.findByIdAvaliacao", query= "SELECT u FROM Avaliacao u WHERE u.IdAvaliacao = :IdAvaliacao"),
    @NamedQuery(name = "Avaliacao.findByIdAluno", query = "SELECT u FROM Avaliacao u WHERE u.IdAluno = :IdAluno"),
    @NamedQuery(name = "Avaliacao.findByIdProfessor", query = "SELECT u FROM Avaliacao u WHERE u.IdProfessor = :IdProfessor")
})

@Data
public class Avaliacao implements Serializable{
    private static final long serialVersionUID = 1L;
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "IdAvaliacao")
    private int IdAvaliacao;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdAluno")
    private Aluno IdAluno;
    
    @Basic(optional = false)
    @ManyToOne
    @JoinColumn(name = "IdProfessor")
    private Professor IdProfessor;
    
    @Basic(optional = false)
    @NotNull
    @Column(name = "Data")
    private Date Data;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Altura")
    private double Altura;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Peso")
    private double Peso;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Imc")
    private double Imc;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "BracoDireito")
    private double BracoDireito;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "BracoEsquerdo")
    private double BracoEsquerdo;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Peitoral")
    private double Peitoral;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Abdomem")
    private double Abdomem;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "Quadril")
    private double Quadril;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "QuadricepsDireito")
    private double QuadricepsDireito;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "QuadricepsEsquerdo")
    private double QuadricepsEsquerdo;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "PanturrilhaDireita")
    private double PanturrilhaDireita;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "PanturrilhaEsqueda")
    private double PanturrilhaEsqueda;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaPeito")
    private double DobraCutaneaPeito;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaTriceps")
    private double DobraCutaneaTriceps;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaAbdomem")
    private double DobraCutaneaAbdomem;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaQuadril")
    private double DobraCutaneaQuadril;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaPanturrilha")
    private double DobraCutaneaPanturrilha;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "DobraCutaneaCoxa")
    private double DobraCutaneaCoxa;
    
    @Basic(optional = false)
    @NotNull
    @Size(min = 2, max = 4)
    @Column(name = "PercentualGordura")
    private double PercentualGordura; 
}