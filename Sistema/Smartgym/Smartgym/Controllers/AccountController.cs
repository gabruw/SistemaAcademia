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

        public AccountController(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/CheckLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(Models.Conta newConta)
        {
            Domain.DTO.Conta contaDTO = new Domain.DTO.Conta();
            contaDTO.EmailConta = newConta.EmailConta;
            contaDTO.SenhaConta = newConta.SenhaConta;

            var returnDB = _contaRepository.Logar(contaDTO);

            if (returnDB != null)
            {
                //Domain.DTO.Professor alunoDTO = new Domain.DTO.Aluno();
                //alunoDTO.EmailAluno = newAluno.EmailAluno;
                //alunoDTO.SenhaAluno = newAluno.SenhaAluno;

                //if (logAluno.NomeAluno.Contains("Email"))
                //{
                //    ModelState.AddModelError("Email", "Email incorreta!");
                //    return View("~/Views/Login/Login.cshtml");
                //}
                //else
                //{
                //    ModelState.AddModelError("Senha", "Senha incorreta!");
                //    return View("~/Views/Login/Login.cshtml");
                //}
            }

            return View("~/Views/Home/Main.cshtml");
        }

        public IActionResult AlunoRegister()
        {
            return View("~/Views/Register/AlunoRegister.cshtml");
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