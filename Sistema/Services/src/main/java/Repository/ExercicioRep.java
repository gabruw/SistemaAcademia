/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Repository;

import Model.Exercicio;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 *
 * @author Igor Oliveira
 */
public interface ExercicioRep extends JpaRepository<Exercicio, Integer>{
    
    public Exercicio findByIdExercicio(int idExercicio);
    public Exercicio findByIdAparelho(int idAparelho);
    public Exercicio findByNome(String nome);
    
}
