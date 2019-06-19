using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnidadeRepository _unidadeRepository;

        public ProfessorController(IProfessorRepository professorRepository, IUnidadeRepository unidadeRepository)
        {
            _professorRepository = professorRepository;
            _unidadeRepository = unidadeRepository;
        }

        // GET: Professor
        public ActionResult Index()
        {
            var professorDTO = _professorRepository.GetAll();

            return View("~/Views/Main/ProfessorMain", professorDTO);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/ProfessorRegister");
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int idUnidade, Models.Conta newConta, Models.Endereco newEndereco, Models.Professor newProfessor)
        {
            try
            {
                // Unidade
                var unidadeDTO = _unidadeRepository.GetbyId(idUnidade);

                // Conta
                Domain.DTO.Conta contaDTO = new Domain.DTO.Conta();
                contaDTO.EmailConta = newConta.EmailConta;
                contaDTO.SenhaConta = newConta.SenhaConta;

                // Endereço
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.CepEndereco = newEndereco.CepEndereco;
                enderecoDTO.RuaEndereco = newEndereco.RuaEndereco;
                enderecoDTO.BairroEndereco = newEndereco.BairroEndereco;
                enderecoDTO.NumeroEndereco = newEndereco.NumeroEndereco;
                enderecoDTO.ComplementoEndereco = newEndereco.ComplementoEndereco;

                // Professor
                Domain.DTO.Professor professorDTO = new Domain.DTO.Professor();
                professorDTO.ContaProfessor = contaDTO;
                professorDTO.EnderecoProfessor = enderecoDTO;
                professorDTO.UnidadeProfessor = unidadeDTO;
                professorDTO.PermissaoProfessor = 2;
                professorDTO.CrefProfessor = newProfessor.CrefProfessor;
                professorDTO.NomeProfessor = newProfessor.NomeProfessor;
                professorDTO.CpfProfessor = newProfessor.CpfProfessor;
                professorDTO.DataNascimentoProfessor = newProfessor.DataNascimentoProfessor;
                professorDTO.TelefoneProfessor = newProfessor.TelefoneProfessor;
                professorDTO.CelularProfessor = newProfessor.CelularProfessor;
                professorDTO.SexoProfessor = newProfessor.SexoProfessor;
                professorDTO.ImagemProfessor = newProfessor.ImagemProfessor;

                _professorRepository.Incluid(professorDTO);

                Created("Professor/Create", professorDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            var professorDTO = _professorRepository.GetbyId(id);

            return View("~/Views/Edit/ProfessorEdit", professorDTO);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idUnidade, Models.Conta newConta, Models.Endereco newEndereco, Models.Professor newProfessor)
        {
            try
            {
                // Unidade
                var unidadeDTO = _unidadeRepository.GetbyId(idUnidade);

                // Conta
                Domain.DTO.Conta contaDTO = new Domain.DTO.Conta();
                contaDTO.EmailConta = newConta.EmailConta;
                contaDTO.SenhaConta = newConta.SenhaConta;

                // Endereço
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.CepEndereco = newEndereco.CepEndereco;
                enderecoDTO.RuaEndereco = newEndereco.RuaEndereco;
                enderecoDTO.BairroEndereco = newEndereco.BairroEndereco;
                enderecoDTO.NumeroEndereco = newEndereco.NumeroEndereco;
                enderecoDTO.ComplementoEndereco = newEndereco.ComplementoEndereco;

                // Professor
                Domain.DTO.Professor professorDTO = new Domain.DTO.Professor();
                professorDTO.ContaProfessor = contaDTO;
                professorDTO.EnderecoProfessor = enderecoDTO;
                professorDTO.UnidadeProfessor = unidadeDTO;
                professorDTO.PermissaoProfessor = 2;
                professorDTO.CrefProfessor = newProfessor.CrefProfessor;
                professorDTO.NomeProfessor = newProfessor.NomeProfessor;
                professorDTO.CpfProfessor = newProfessor.CpfProfessor;
                professorDTO.DataNascimentoProfessor = newProfessor.DataNascimentoProfessor;
                professorDTO.TelefoneProfessor = newProfessor.TelefoneProfessor;
                professorDTO.CelularProfessor = newProfessor.CelularProfessor;
                professorDTO.SexoProfessor = newProfessor.SexoProfessor;
                professorDTO.ImagemProfessor = newProfessor.ImagemProfessor;

                _professorRepository.Update(professorDTO);

                Created("Professor/Edit", professorDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            Domain.DTO.Professor professorDTO = new Domain.DTO.Professor();
            professorDTO.IdProfessor = id;

            _professorRepository.Remove(professorDTO);

            return View("~/Views/Main/ProfessorMain");
        }
    }
}