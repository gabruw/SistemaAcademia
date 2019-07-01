using Auxiliary;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Smartgym.Controllers
{
    public class AparelhoController : Controller
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        private DataTable newDataTable = new DataTable();

        public AparelhoController(IAparelhoRepository aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        // GET: Aparelho
        public ActionResult Index(int permissao, string nome)
        {
            Auxiliary.Partial.AccountInformation accountInformation = new Auxiliary.Partial.AccountInformation();
            accountInformation.Permissao = permissao;
            accountInformation.Nome = nome;

            return View("~/Views/Main/AparelhoMain.cshtml", accountInformation);
        }

        [HttpPost]
        public IActionResult GetAllAparelhos()
        {
            var requestFormData = Request.Form;

            var aparelhoDTO = _aparelhoRepository.GetAll();

            var listAparelhoForm = newDataTable.AparelhoDataProcessForm(aparelhoDTO, requestFormData);

            var count = aparelhoDTO.Count();

            dynamic response = new
            {
                Data = listAparelhoForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        // GET: Aparelho/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/AparelhoRegister.cshtml");
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
        public ActionResult Edit(long id)
        {
            var aparelhoDTO = _aparelhoRepository.GetbyId(id);

            return View("~/Views/Edit/AparelhoEdit.cshtml", aparelhoDTO);
        }

        // POST: Aparelho/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, Models.Aparelho newAparelho)
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
        public ActionResult Delete(long id)
        {
            var aparelhoDTO = _aparelhoRepository.GetbyId(id);

            _aparelhoRepository.Remove(aparelhoDTO);

            return View("~/Views/Main/AparelhoMain.cshtml");
        }
    }
}