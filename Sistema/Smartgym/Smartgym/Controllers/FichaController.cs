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
    public class FichaController : Controller
    {
        private readonly IFichaRepository _fichaRepository;
        private readonly IExercicioRepository _exercicioRepository;
        private readonly IExercicioSerieRepository _exercicioSerieRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        private Geradores newGerador = new Geradores();
        private DataTable newDataTable = new DataTable();

        public FichaController(IFichaRepository fichaRepository, IExercicioRepository exercicioRepository, IExercicioSerieRepository exercicioSerieRepository, ISerieRepository serieRepository,
            IAlunoRepository alunoRepository, IProfessorRepository professorRepository)
        {
            _fichaRepository = fichaRepository;
            _exercicioRepository = exercicioRepository;
            _exercicioSerieRepository = exercicioSerieRepository;
            _serieRepository = serieRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        // GET: Ficha
        public ActionResult Index(int permissao, string nome)
        {
            Auxiliary.Partial.AccountInformation accountInformation = new Auxiliary.Partial.AccountInformation();
            accountInformation.Permissao = permissao;
            accountInformation.Nome = nome;

            return View("~/Views/Main/FichaMain.cshtml", accountInformation);
        }

        [HttpPost]
        public IActionResult GetAllExercicios()
        {
            var requestFormData = Request.Form;

            var exercicioDTO = _exercicioRepository.GetAll();

            var listExercicioForm = newDataTable.ExercicioDataProcessForm(exercicioDTO, requestFormData);

            var count = exercicioDTO.Count();

            dynamic response = new
            {
                Data = listExercicioForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetAllFichas()
        {
            var requestFormData = Request.Form;

            var fichaDTO = _fichaRepository.GetAll();

            var listFichaForm = newDataTable.FichaDataProcessForm(fichaDTO, requestFormData);

            var count = fichaDTO.Count();

            dynamic response = new
            {
                Data = listFichaForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult GetAllExerciciosSerieBySerie(IFormCollection collection)
        {
            var serieDTO = _serieRepository.GetbyId(Int64.Parse(collection["idSerie"]));
            var listExercicioSerie = serieDTO.ExercicioExercicioSerie;

            var listExeSerie = new List<Domain.DTO.ExercicioSerie>();
            foreach(var exeSer in listExercicioSerie)
            {
                var exercicioSerieFiltrado = new Domain.DTO.ExercicioSerie();
                exercicioSerieFiltrado.ExercicioExercicioSerie = exeSer.ExercicioExercicioSerie;
                exercicioSerieFiltrado.RepeticoesExercicioSerie = exeSer.RepeticoesExercicioSerie;

                listExeSerie.Add(exercicioSerieFiltrado);
            }

            return Ok(listExeSerie);
        }

        // GET: Ficha/Create
        public ActionResult Create()
        {
            var newPartial = new Auxiliary.Partial.PartialCollectionProfessorAluno();
            newPartial.Aluno = _alunoRepository.GetAll();
            newPartial.Professor = _professorRepository.GetAll();

            return View("~/Views/Register/FichaRegister.cshtml", newPartial);
        }

        [HttpPost]
        public void CreateExercicio(IFormCollection collection)
        {
            Domain.DTO.ExercicioSerie exercicioSerieDTO = new Domain.DTO.ExercicioSerie();
            exercicioSerieDTO.IdExercicioExercicioSerie = Int64.Parse(collection["idExercicio"]);
            exercicioSerieDTO.IdSerieExercicioSerie = Int64.Parse(collection["idSerie"]);
            exercicioSerieDTO.RepeticoesExercicioSerie = Int32.Parse(collection["repeticoesExercicio"]);

            var serieDTO = _serieRepository.GetbyId(Int64.Parse(collection["idSerie"]));
            serieDTO.ExercicioExercicioSerie.Add(exercicioSerieDTO);

            _serieRepository.Update(serieDTO);
        }

        [HttpGet]
        public void RemoveExercicio(long idExercicio)
        {
            var exercicioDTO = _exercicioRepository.GetbyId(idExercicio);
        }

        [HttpPost]
        public long CreateSerie(IFormCollection collection)
        {
            Domain.DTO.Serie serieDTO = new Domain.DTO.Serie();
            serieDTO.IdFichaSerie = Int64.Parse(collection["idFicha"]);
            serieDTO.NomeSerie = collection["nomeSerie"];
            serieDTO.ObservacaoSerie = collection["observacoesSerie"];
            serieDTO.RepeticoesSerie = Int32.Parse(collection["repeticoesSerie"]);

            var fichaDTO = _fichaRepository.GetbyId(Int64.Parse(collection["idFicha"]));
            fichaDTO.SerieFicha.Add(serieDTO);

            var fichaReturned =_fichaRepository.UpdateAndReturnEntity(fichaDTO);

            var serieForReturn = fichaReturned.SerieFicha.Last();

            return serieForReturn.IdSerie;
        }

        [HttpPost]
        public void RemoveSerie(long id)
        {
            var serieDTO = _serieRepository.GetbyId(id);

            var fichaDTO = _fichaRepository.GetbyId(id);
            fichaDTO.SerieFicha.Remove(serieDTO);

            _fichaRepository.Update(fichaDTO);
        }

        // POST: Ficha/Create
        [HttpPost]
        public long Create(IFormCollection collection)
        {
            var idAluno = Int64.Parse(collection["idAluno"]);
            var idProfessor = Int64.Parse(collection["idProfessor"]);

            Domain.DTO.Ficha fichaDTO = new Domain.DTO.Ficha();
            fichaDTO.IdAlunoFicha = idAluno;
            fichaDTO.IdProfessorFicha = idProfessor;

            var fichaReturned = _fichaRepository.IncluidAndReturnEntity(fichaDTO);

            return fichaReturned.IdFicha;
        }

        // GET: Ficha/Edit/5
        public ActionResult Edit(long id)
        {
            var fichaDTO = _fichaRepository.GetbyId(id);

            return View("~/Views/Edit/FichaEdit.cshtml", fichaDTO);
        }

        // POST: Ficha/Edit/5
        [HttpPost]
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

        // GET: Ficha/Delete/5
        public ActionResult Delete(long id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}