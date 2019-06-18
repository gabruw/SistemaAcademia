using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AparelhoController : Controller
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        public AparelhoController(IAparelhoRepository aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        // GET: Aparelho
        public ActionResult Index()
        {
            return View("~/Views/Main/AparelhoMain");
        }

        // GET: Aparelho/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/AparelhoRegister");
        }

        // POST: Aparelho/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Aparelho newAparelho)
        {
            try
            {
                Domain.DTO.Aparelho aparelhoDTO = new Domain.DTO.Aparelho();
                aparelhoDTO.NomeAparelho = newAparelho.NomeAparelho;

                _aparelhoRepository.Incluid(aparelhoDTO);

                Created("Aparelho/Create", aparelhoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aparelho/Edit/5
        public ActionResult Edit(int id)
        {
            var aparelhoDTO = _aparelhoRepository.GetbyId(id);

            return View("~/Views/Edit/AparelhoEdit", aparelhoDTO);
        }

        // POST: Aparelho/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Aparelho newAparelho)
        {
            try
            {
                Domain.DTO.Aparelho aparelhoDTO = new Domain.DTO.Aparelho();
                aparelhoDTO.IdAparelho = id;
                aparelhoDTO.NomeAparelho = newAparelho.NomeAparelho;

                _aparelhoRepository.Update(aparelhoDTO);

                Created("Aparelho/Edit", aparelhoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aparelho/Delete/5
        public ActionResult Delete(int id)
        {
            Domain.DTO.Aparelho aparelhoDTO = new Domain.DTO.Aparelho();
            aparelhoDTO.IdAparelho = id;

            _aparelhoRepository.Remove(aparelhoDTO);

            return View("~/Views/Main/AparelhoMain");
        }
    }
}