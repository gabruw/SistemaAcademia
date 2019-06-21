using Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAlunoRepository _alunoRepository;

        public AgendaController(IAgendaRepository agendaRepository, IProfessorRepository professorRepository, IAlunoRepository alunoRepository)
        {
            _agendaRepository = agendaRepository;
            _professorRepository = professorRepository;
            _alunoRepository = alunoRepository;
        }

        // GET: Agenda
        public ActionResult Index()
        {
            var agendaDTO = _agendaRepository.GetAll();

            return View("~/Views/Main/AgendaMain", agendaDTO);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            Models.ViewAgenda newViewAgenda = new Models.ViewAgenda();
            newViewAgenda.ProfessorViewAgenda = _professorRepository.GetAll();
            newViewAgenda.AlunoViewAgenda = _alunoRepository.GetAll();

            return View("~/Views/Register/AgendaRegister", newViewAgenda);
        }

        // POST: Agenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(long idAluno, long idProfessor, Models.Agenda newAgenda)
        {
            try
            {
                var professorDTO = _professorRepository.GetbyId(idProfessor);
                var alunoDTO =_alunoRepository.GetbyId(idAluno);
                
                Domain.DTO.Agenda agendaDTO = new Domain.DTO.Agenda();
                agendaDTO.ProfessorAgenda = professorDTO;
                agendaDTO.AlunoAgenda = alunoDTO;
                agendaDTO.DataAgenda = newAgenda.DataAgenda;

                _agendaRepository.Incluid(agendaDTO);

                Created("Agenda/Create", agendaDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(long id)
        {
            Models.ViewAgenda newViewAgenda = new Models.ViewAgenda();
            newViewAgenda.AgendaViewAgenda = _agendaRepository.GetbyId(id);
            newViewAgenda.ProfessorViewAgenda = _professorRepository.GetAll();
            newViewAgenda.AlunoViewAgenda = _alunoRepository.GetAll();

            return View("~/Views/Edit/AgendaEdit", newViewAgenda);
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long idAluno, long idProfessor, Models.Agenda newAgenda)
        {
            try
            {
                var professorDTO = _professorRepository.GetbyId(idProfessor);
                var alunoDTO = _alunoRepository.GetbyId(idAluno);

                Domain.DTO.Agenda agendaDTO = new Domain.DTO.Agenda();
                agendaDTO.ProfessorAgenda = professorDTO;
                agendaDTO.AlunoAgenda = alunoDTO;
                agendaDTO.DataAgenda = newAgenda.DataAgenda;

                _agendaRepository.Update(agendaDTO);

                Created("Agenda/Edit", agendaDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(long id)
        {
            Domain.DTO.Agenda agendaDTO = new Domain.DTO.Agenda();
            agendaDTO.IdAgenda = id;

            _agendaRepository.Remove(agendaDTO);

            return View("~/Views/Remove/AgendaMain");
        }
    }
}