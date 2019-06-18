using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        private readonly IEnderecoRepository _enderecoRepository;

        public AlunoController(IAlunoRepository alunoRepository, IEnderecoRepository enderecoRepository)
        {
            _alunoRepository = alunoRepository;
            _enderecoRepository = enderecoRepository;
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
        public ActionResult Create(Models.Aluno newAluno, Models.Endereco newEndereco)
        {
            try
            {
                // Endereço
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.CepEndereco = newEndereco.CepEndereco;
                enderecoDTO.RuaEndereco = newEndereco.RuaEndereco;
                enderecoDTO.BairroEndereco = newEndereco.BairroEndereco;
                enderecoDTO.NumeroEndereco = newEndereco.NumeroEndereco;
                enderecoDTO.ComplementoEndereco = newEndereco.ComplementoEndereco;

                // Aluno
                Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
                alunoDTO.EnderecoAluno = enderecoDTO;
                alunoDTO.PermissaoAluno = 1;
                alunoDTO.EmailAluno = newAluno.EmailAluno;
                alunoDTO.SenhaAluno = newAluno.SenhaAluno;
                alunoDTO.MatriculaAluno = GerarMatricula(newAluno.NomeAluno, newAluno.DataNascimentoAluno);

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
        public ActionResult Edit(int id, Models.Aluno newAluno)
        {
            try
            {
                Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();

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