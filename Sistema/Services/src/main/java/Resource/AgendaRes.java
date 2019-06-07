package Resource;

import Model.Agenda;
import DTO.AgendaDTO;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/agenda")
public class AgendaRes {
    @Autowired
    AgendaRes Agenda;

    @PersistenceContext
    EntityManager EntityM;
    
    @PostMapping("/search")
    public Agenda getAllAgenda(@RequestBody AgendaDTO agenda) {
        try {
            Query query = EntityM.createQuery("SELECT * FROM Agenda");
            
            return (Agenda) query.getSingleResult();
        } catch (NoResultException e) {
            return null;
        }
    }

    
}
