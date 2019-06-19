using Auxiliary;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        private Geradores newGerador = new Geradores();

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: Aluno
        public ActionResult Index()
        {
            var alunoDTO = _alunoRepository.GetAll();

            return View("~/Views/Main/AlunoMain", alunoDTO);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/AlunoRegister");
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Conta newConta, Models.Endereco newEndereco, Models.Aluno newAluno)
        {
            try
            {
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

                // Aluno
                Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
                alunoDTO.ContaAluno = contaDTO;
                alunoDTO.EnderecoAluno = enderecoDTO;
                alunoDTO.PermissaoAluno = 1;
                alunoDTO.MatriculaAluno = newGerador.GerarMatricula(newAluno.NomeAluno, newAluno.DataNascimentoAluno);
                alunoDTO.NomeAluno = newAluno.NomeAluno;
                alunoDTO.CpfAluno = newAluno.CpfAluno;
                alunoDTO.DataNascimentoAluno = newAluno.DataNascimentoAluno;
                alunoDTO.TelefoneAluno = newAluno.TelefoneAluno;
                alunoDTO.CelularAluno = newAluno.CelularAluno;
                alunoDTO.SexoAluno = newAluno.SexoAluno;
                alunoDTO.ImagemAluno = newAluno.ImagemAluno;

                _alunoRepository.Incluid(alunoDTO);

                Created("Aluno/Create", alunoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            var alunoDTO = _alunoRepository.GetbyId(id);

            return View("~/Views/Edit/AlunoEdit", alunoDTO);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Models.Conta newConta, Models.Endereco newEndereco, Models.Aluno newAluno)
        {
            try
            {
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

                // Aluno
                Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
                alunoDTO.ContaAluno = contaDTO;
                alunoDTO.EnderecoAluno = enderecoDTO;
                alunoDTO.PermissaoAluno = 1;
                alunoDTO.MatriculaAluno = newAluno.MatriculaAluno;
                alunoDTO.NomeAluno = newAluno.NomeAluno;
                alunoDTO.CpfAluno = newAluno.CpfAluno;
                alunoDTO.DataNascimentoAluno = newAluno.DataNascimentoAluno;
                alunoDTO.TelefoneAluno = newAluno.TelefoneAluno;
                alunoDTO.CelularAluno = newAluno.CelularAluno;
                alunoDTO.SexoAluno = newAluno.SexoAluno;
                alunoDTO.ImagemAluno = newAluno.ImagemAluno;

                _alunoRepository.Update(alunoDTO);

                Created("Aluno/Edit", alunoDTO);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
            alunoDTO.IdAluno = id;

            _alunoRepository.Remove(alunoDTO);

            return View("~/Views/Main/AlunoMain");
        }
    }
}