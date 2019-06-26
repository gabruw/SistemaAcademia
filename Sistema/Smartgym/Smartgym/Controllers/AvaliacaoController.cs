using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private CultureInfo newCultureInfo = new CultureInfo("en-US");

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

            List<Models.Avaliacao> list = new List<Models.Avaliacao>();

            foreach (var aval in listAvaliacoesForm)
            {
                Models.Professor partialProf = new Models.Professor();
                partialProf.NomeProfessor = aval.ProfessorAvaliacao.NomeProfessor;

                Models.Aluno partialAlu = new Models.Aluno();
                partialAlu.NomeAluno = aval.AlunoAvaliacao.NomeAluno;

                Models.Avaliacao partialAval = new Models.Avaliacao();
                partialAval.IdAvaliacao = aval.IdAvaliacao;
                partialAval.DataAvaliacao = aval.DataAvaliacao;
                partialAval.ImcAvaliacao = aval.ImcAvaliacao;
                partialAval.PercentualGorduraAvaliacao = aval.PercentualGorduraAvaliacao;
                partialAval.AlunoAvaliacao = partialAlu;
                partialAval.ProfessorAvaliacao = partialProf;

                list.Add(partialAval);
            }

            dynamic response = new
            {
                Data = list,
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
            viewAvaliacao.AlunoViewAvaliacao = _alunoRepository.GetAll();
            viewAvaliacao.ProfessorViewAvaliacao = _professorRepository.GetAll();

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

                avaliacaoDTO.AbdomemAvaliacao = Double.Parse(collection["abdomem"], newCultureInfo);
                avaliacaoDTO.BracoDireitoAvaliacao = Double.Parse(collection["bracoDireito"], newCultureInfo);
                avaliacaoDTO.BracoEsquerdoAvaliacao = Double.Parse(collection["bracoEsquerdo"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaAbdomemAvaliacao = Double.Parse(collection["dobraCutaneaAbdomem"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaCoxaAvaliacao = Double.Parse(collection["dobraCutaneaCoxa"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaPanturrilhaAvaliacao = Double.Parse(collection["dobraCutaneaPanturrilha"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaPeitoAvaliacao = Double.Parse(collection["dobraCutaneaPeito"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaQuadrilAvaliacao = Double.Parse(collection["dobraCutaneaQuadril"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaTricepsAvaliacao = Double.Parse(collection["dobraCutaneaTriceps"], newCultureInfo);
                avaliacaoDTO.PanturrilhaDireitaAvaliacao = Double.Parse(collection["panturrilhaDireita"], newCultureInfo);
                avaliacaoDTO.PanturrilhaEsquerdaAvaliacao = Double.Parse(collection["panturrilhaEsquerda"], newCultureInfo);
                avaliacaoDTO.PeitoralAvaliacao = Double.Parse(collection["peitoral"], newCultureInfo);
                avaliacaoDTO.QuadrcepsEsquerdoAvaliacao = Double.Parse(collection["quadricepsEsquerdo"], newCultureInfo);
                avaliacaoDTO.QuadricepsDireitoAvaliacao = Double.Parse(collection["quadricepsDireito"], newCultureInfo);
                avaliacaoDTO.QuadrilAvaliacao = Double.Parse(collection["quadril"], newCultureInfo);

                avaliacaoDTO.DataAvaliacao = DateTime.Now.Date;
                avaliacaoDTO.AlturaAvaliacao = Double.Parse(collection["altura"], newCultureInfo);
                avaliacaoDTO.PesoAvaliacao = Double.Parse(collection["peso"], newCultureInfo);

                double percentualGordura;

                avaliacaoDTO.ImcAvaliacao = newGerador.CalcularIMC(alunoDTO.DataNascimentoAluno, avaliacaoDTO, alunoDTO.SexoAluno, out percentualGordura);
                avaliacaoDTO.PercentualGorduraAvaliacao = percentualGordura;
                avaliacaoDTO.ObservacaoAvaliacao = collection["observacoesAvaliacao"];

                _avaliacaoRepository.Incluid(avaliacaoDTO);

                Created("Avaliacao/Create", avaliacaoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(long id)
        {
            Auxiliary.Partial.ViewAvaliacao viewAvaliacao = new Auxiliary.Partial.ViewAvaliacao();
            viewAvaliacao.AvaliacaoViewAvaliacao = _avaliacaoRepository.GetbyId(id);
            viewAvaliacao.AlunoViewAvaliacao = _alunoRepository.GetAll();
            viewAvaliacao.ProfessorViewAvaliacao = _professorRepository.GetAll();

            return View("~/Views/Edit/AvaliacaoEdit.cshtml", viewAvaliacao);
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, IFormCollection collection)
        {
            try
            {
                var alunoDTO = _alunoRepository.GetbyId(Int64.Parse(collection["aluno"]));

                var avaliacaoDTO = _avaliacaoRepository.GetbyId(id);

                avaliacaoDTO.IdAlunoAvaliacao = Int64.Parse(collection["aluno"]);
                avaliacaoDTO.IdProfessorAvaliacao = Int64.Parse(collection["professor"]);

                avaliacaoDTO.AbdomemAvaliacao = Double.Parse(collection["abdomem"], newCultureInfo);
                avaliacaoDTO.BracoDireitoAvaliacao = Double.Parse(collection["bracoDireito"], newCultureInfo);
                avaliacaoDTO.BracoEsquerdoAvaliacao = Double.Parse(collection["bracoEsquerdo"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaAbdomemAvaliacao = Double.Parse(collection["dobraCutaneaAbdomem"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaCoxaAvaliacao = Double.Parse(collection["dobraCutaneaCoxa"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaPanturrilhaAvaliacao = Double.Parse(collection["dobraCutaneaPanturrilha"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaPeitoAvaliacao = Double.Parse(collection["dobraCutaneaPeito"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaQuadrilAvaliacao = Double.Parse(collection["dobraCutaneaQuadril"], newCultureInfo);
                avaliacaoDTO.DobraCutaneaTricepsAvaliacao = Double.Parse(collection["dobraCutaneaTriceps"], newCultureInfo);
                avaliacaoDTO.PanturrilhaDireitaAvaliacao = Double.Parse(collection["panturrilhaDireita"], newCultureInfo);
                avaliacaoDTO.PanturrilhaEsquerdaAvaliacao = Double.Parse(collection["panturrilhaEsquerda"], newCultureInfo);
                avaliacaoDTO.PeitoralAvaliacao = Double.Parse(collection["peitoral"], newCultureInfo);
                avaliacaoDTO.QuadrcepsEsquerdoAvaliacao = Double.Parse(collection["quadricepsEsquerdo"], newCultureInfo);
                avaliacaoDTO.QuadricepsDireitoAvaliacao = Double.Parse(collection["quadricepsDireito"], newCultureInfo);
                avaliacaoDTO.QuadrilAvaliacao = Double.Parse(collection["quadril"], newCultureInfo);

                avaliacaoDTO.DataAvaliacao = avaliacaoDTO.DataAvaliacao;
                avaliacaoDTO.AlturaAvaliacao = Double.Parse(collection["altura"], newCultureInfo);
                avaliacaoDTO.PesoAvaliacao = Double.Parse(collection["peso"], newCultureInfo);

                double percentualGordura;

                avaliacaoDTO.ImcAvaliacao = newGerador.CalcularIMC(alunoDTO.DataNascimentoAluno, avaliacaoDTO, alunoDTO.SexoAluno, out percentualGordura);
                avaliacaoDTO.PercentualGorduraAvaliacao = percentualGordura;
                avaliacaoDTO.ObservacaoAvaliacao = collection["observacoesAvaliacao"];

                _avaliacaoRepository.Update(avaliacaoDTO);

                Created("Avaliacao/Create", avaliacaoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(long id)
        {
            var avaliacaoDTO = _avaliacaoRepository.GetbyId(id);

            _avaliacaoRepository.Remove(avaliacaoDTO);

            return View("~/Views/Main/AvaliacaoMain.cshtml");
        }
    }
}