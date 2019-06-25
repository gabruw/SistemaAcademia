using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auxiliary;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        private Geradores newGerador = new Geradores();
        private DataTable newDataTable = new DataTable();

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository, IAlunoRepository alunoRepository, IProfessorRepository professorRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            return View("~/Views/Main/AvaliacaoMain.cshtml");
        }

        [HttpPost]
        public IActionResult GetAllAvaliacoes()
        {
            var requestFormData = Request.Form;

            var avaliacaoDTO = _avaliacaoRepository.GetAll();

            var listAvaliacoesForm = newDataTable.AvaliacaoDataProcessForm(avaliacaoDTO, requestFormData);

            var count = avaliacaoDTO.Count();

            dynamic response = new
            {
                Data = listAvaliacoesForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            Auxiliary.Partial.ViewAvaliacao viewAvaliacao = new Auxiliary.Partial.ViewAvaliacao();
            viewAvaliacao.AlunoViewAgenda = _alunoRepository.GetAll();
            viewAvaliacao.ProfessorViewAgenda = _professorRepository.GetAll();

            return View("~/Views/Register/AvaliacaoRegister.cshtml", viewAvaliacao);
        }

        // POST: Avaliacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var alunoDTO = _alunoRepository.GetbyId(Int64.Parse(collection["aluno"]));

                Domain.DTO.Avaliacao avaliacaoDTO = new Domain.DTO.Avaliacao();
                avaliacaoDTO.IdAlunoAvaliacao = Int64.Parse(collection["aluno"]);
                avaliacaoDTO.IdProfessorAvaliacao = Int64.Parse(collection["professor"]);

                avaliacaoDTO.AbdomemAvaliacao = Double.Parse(collection["abdomem"]);
                avaliacaoDTO.BracoDireitoAvaliacao = Double.Parse(collection["bracoDireito"]);
                avaliacaoDTO.BracoEsquerdoAvaliacao = Double.Parse(collection["bracoEsquerdo"]);
                avaliacaoDTO.DobraCutaneaAbdomemAvaliacao = Double.Parse(collection["dobraCutaneaAbdomem"]);
                avaliacaoDTO.DobraCutaneaCoxaAvaliacao = Double.Parse(collection["dobraCutaneaCoxa"]);
                avaliacaoDTO.DobraCutaneaPanturrilhaAvaliacao = Double.Parse(collection["dobraCutaneaPanturrilha"]);
                avaliacaoDTO.DobraCutaneaPeitoAvaliacao = Double.Parse(collection["dobraCutaneaPeito"]);
                avaliacaoDTO.DobraCutaneaQuadrilAvaliacao = Double.Parse(collection["dobraCutaneaQuadril"]);
                avaliacaoDTO.DobraCutaneaTricepsAvaliacao = Double.Parse(collection["dobraCutaneaTriceps"]);
                avaliacaoDTO.PanturrilhaDireitaAvaliacao = Double.Parse(collection["panturrilhaDireita"]);
                avaliacaoDTO.PanturrilhaEsquerdaAvaliacao = Double.Parse(collection["panturrilhaEsquerda"]);
                avaliacaoDTO.PeitoralAvaliacao = Double.Parse(collection["peitoral"]);
                avaliacaoDTO.QuadrcepsEsquerdoAvaliacao = Double.Parse(collection["quadrcepsEsquerdo"]);
                avaliacaoDTO.QuadricepsDireitoAvaliacao = Double.Parse(collection["quadricepsDireito"]);
                avaliacaoDTO.QuadrilAvaliacao = Double.Parse(collection["quadril"]);

                avaliacaoDTO.DataAvaliacao = DateTime.Now.Date;
                avaliacaoDTO.AlturaAvaliacao = Double.Parse(collection["altura"]);
                avaliacaoDTO.PesoAvaliacao = Double.Parse(collection["peso"]);

                var soma7 = avaliacaoDTO.DobraCutaneaAbdomemAvaliacao + avaliacaoDTO.DobraCutaneaCoxaAvaliacao +
                       avaliacaoDTO.DobraCutaneaPanturrilhaAvaliacao + avaliacaoDTO.DobraCutaneaPeitoAvaliacao +
                       avaliacaoDTO.DobraCutaneaQuadrilAvaliacao + avaliacaoDTO.DobraCutaneaTricepsAvaliacao;

                double densidadeCorporal = 0;
                if (alunoDTO.SexoAluno == 1)
                {
                    densidadeCorporal = 1.112 - 0.00043499 * soma7 + 0.00000055 * (soma7 * soma7) - 0.00028826 * alunoDTO.IdadeAluno;
                }
                else
                {
                    densidadeCorporal = 1.0970 - 0.000464971 * soma7 + 0.00000056 * (soma7 * soma7) - 0.00012828 * alunoDTO.IdadeAluno;
                }

                double percentualGordura = ((4.95 / densidadeCorporal) - 4.50) * 100;

                avaliacaoDTO.PercentualGorduraAvaliacao = percentualGordura;
                avaliacaoDTO.ImcAvaliacao = avaliacaoDTO.PesoAvaliacao / (avaliacaoDTO.AlturaAvaliacao * avaliacaoDTO.AlturaAvaliacao);
                avaliacaoDTO.ObservacaoAvaliacao = collection["observacaoAvaliacao"];

                _avaliacaoRepository.Incluid(avaliacaoDTO);

                Created("Avaliacao/Create", avaliacaoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(long id)
        {
            var avaliacaoDTO = _avaliacaoRepository.GetbyId(id);

            return View("~/Views/Edit/AlunoEdit.cshtml", avaliacaoDTO);
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: Avaliacao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, IFormCollection collection)
        {
            var avaliacaoDTO = _avaliacaoRepository.GetbyId(id);

            _avaliacaoRepository.Remove(avaliacaoDTO);

            return View("~/Views/Main/AvaliacaoMain.cshtml");
        }
    }
}