using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AccountController : Controller
    {
        private readonly IContaRepository _contaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AccountController(IContaRepository contaRepository, IAlunoRepository alunoRepository, IProfessorRepository professorRepository)
        {
            _contaRepository = contaRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: Account/CheckLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(Models.Conta newConta)
        {
            Domain.DTO.Conta contaDTO = new Domain.DTO.Conta();
            contaDTO.EmailConta = newConta.EmailConta;
            contaDTO.SenhaConta = newConta.SenhaConta;

            long[] loginResult = _contaRepository.Logar(contaDTO);

            var permissao = 0;
            var nome = "";
            if (loginResult.First() != 0 || loginResult.First() != -1)
            {
                var professorDTO = new Domain.DTO.Professor();
                var alunoDTO = new Domain.DTO.Aluno();

                if (loginResult[1] == 1)
                {
                    alunoDTO = _alunoRepository.GetbyId(loginResult.First());
                    permissao = alunoDTO.PermissaoAluno;
                    nome = alunoDTO.NomeAluno;
                }
                else
                {
                    professorDTO = _professorRepository.GetbyId(loginResult.First());

                    permissao = professorDTO.PermissaoProfessor;
                    nome = professorDTO.NomeProfessor;
                }
                
            }
            else if (loginResult.First() == 0)
            {
                ViewBag.Erro = "Email incorreto.";
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                ViewBag.Erro = "Senha incorreta.";
                return View("~/Views/Account/Login.cshtml");
            }

            Auxiliary.Partial.AccountInformation accountInformation = new Auxiliary.Partial.AccountInformation();
            accountInformation.Permissao = permissao;
            accountInformation.Nome = nome;

            return View("~/Views/Home/Main.cshtml", accountInformation);
        }

        public IActionResult SemAutorizacao()
        {
            return View();
        }

        public IActionResult SemPermissao()
        {
            return View();
        }
    }
}