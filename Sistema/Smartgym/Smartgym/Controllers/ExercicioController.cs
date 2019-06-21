using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class ExercicioController : Controller
    {
        // GET: Exercicio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Exercicio/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: Exercicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercicio/Create
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

        // GET: Exercicio/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: Exercicio/Edit/5
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

        // GET: Exercicio/Delete/5
        public ActionResult Delete(long id)
        {
            return View();
        }

        // POST: Exercicio/Delete/5
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