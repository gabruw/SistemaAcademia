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
        private readonly ISerieRepository _serieRepository;

        private Geradores newGerador = new Geradores();
        private DataTable newDataTable = new DataTable();

        public FichaController(IFichaRepository fichaRepository, IExercicioRepository exercicioRepository, ISerieRepository serieRepository)
        {
            _fichaRepository = fichaRepository;
            _exercicioRepository = exercicioRepository;
            _serieRepository = serieRepository;
        }

        // GET: Ficha
        public ActionResult Index()
        {
            return View("~/Views/Main/FichaMain.cshtml");
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

        // GET: Ficha/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/FichaRegister.cshtml");
        }

        // POST: Ficha/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ficha/Edit/5
        public ActionResult Edit(long id)
        {
            var fichaDTO = _fichaRepository.GetbyId(id);

            return View("~/Views/Edit/FichaEdit.cshtml", fichaDTO);
        }

        // POST: Ficha/Edit/5
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

        // POST: Ficha/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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