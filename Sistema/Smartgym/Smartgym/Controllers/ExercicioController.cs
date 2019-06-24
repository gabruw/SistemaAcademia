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
    public class ExercicioController : Controller
    {
        private readonly IExercicioRepository _exercicioRepository;
        private readonly IAparelhoRepository _aparelhoRepository;

        private DataTable newDataTable = new DataTable();

        public ExercicioController(IExercicioRepository exercicioRepository, IAparelhoRepository aparelhoRepository)
        {
            _exercicioRepository = exercicioRepository;
            _aparelhoRepository = aparelhoRepository;
        }

        // GET: Exercicio
        public ActionResult Index()
        {
            return View("~/Views/Main/ExercicioMain.cshtml");
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

        // GET: Exercicio/Create
        public ActionResult Create()
        {
            var aparelhosDTO = _aparelhoRepository.GetAll();

            return View("~/Views/Register/ExercicioRegister.cshtml", aparelhosDTO);
        }

        // POST: Exercicio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var idAparelho = Int64.Parse(collection["aparelho"]);
                var aparelhoDTO = _aparelhoRepository.GetbyId(idAparelho);

                Domain.DTO.Exercicio exercicioDTO = new Domain.DTO.Exercicio();
                exercicioDTO.AparelhoExercicio = aparelhoDTO;
                exercicioDTO.NomeExercicio = collection["nomeExercicio"];
                exercicioDTO.ObservacaoExercicio = collection["observacaoExercicio"];

                _exercicioRepository.Incluid(exercicioDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Exercicio/Edit/5
        public ActionResult Edit(long id)
        {
            Auxiliary.Partial.ViewExercicio viewExercicio = new Auxiliary.Partial.ViewExercicio();
            viewExercicio.ExercicioViewExercicio = _exercicioRepository.GetbyId(id);
            viewExercicio.AparelhorViewAgenda = _aparelhoRepository.GetAll();

            return View("~/Views/Edit/ExercicioEdit.cshtml", viewExercicio);
        }

        // POST: Exercicio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var exercicioDTO = _exercicioRepository.GetbyId(id);

                var idAparelho = Int64.Parse(collection["aparelho"]);
                var aparelhoDTO = _aparelhoRepository.GetbyId(idAparelho);

                exercicioDTO.AparelhoExercicio = aparelhoDTO;
                exercicioDTO.NomeExercicio = collection["nomeExercicio"];
                exercicioDTO.ObservacaoExercicio = collection["observacaoExercicio"];

                _exercicioRepository.Update(exercicioDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // POST: Exercicio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var exercicioDTO = _exercicioRepository.GetbyId(id);

            _exercicioRepository.Remove(exercicioDTO);

            return View("~/Views/Main/ExercicioMain.cshtml");
        }
    }
}