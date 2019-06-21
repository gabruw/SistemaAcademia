using Auxiliary;
using Domain.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Smartgym.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IHostingEnvironment _hosting;

        private Geradores newGerador = new Geradores();

        public AlunoController(IAlunoRepository alunoRepository, IHostingEnvironment hosting)
        {
            _alunoRepository = alunoRepository;
            _hosting = hosting;
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
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var caminhoArquivo = Path.GetTempFileName();
                var nomeArquivo = newGerador.GetFileName(collection["nomeCompleto"], collection.Files[0].ContentType.Split("/")[1]);
                var filePath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Aluno", nomeArquivo);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await collection.Files[0].CopyToAsync(stream);
                }

                // Conta
                Domain.DTO.Conta contaDTO = new Domain.DTO.Conta();
                contaDTO.EmailConta = collection["email"];
                contaDTO.SenhaConta = collection["senha"];

                // Endereço
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.CepEndereco = newGerador.EraseEspecialAndReturnInt(collection["cep"]);
                enderecoDTO.RuaEndereco = collection["rua"];
                enderecoDTO.BairroEndereco = collection["bairro"];
                enderecoDTO.NumeroEndereco = newGerador.EraseEspecialAndReturnInt(collection["numero"]);
                enderecoDTO.ComplementoEndereco = newGerador.EraseEspecialAndReturnInt(collection["complemento"]);

                // Aluno
                Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
                alunoDTO.ContaAluno = contaDTO;
                alunoDTO.EnderecoAluno = enderecoDTO;
                alunoDTO.PermissaoAluno = 1;
                alunoDTO.MatriculaAluno = newGerador.GerarMatricula(collection["nomeCompleto"]);
                alunoDTO.NomeAluno = collection["nomeCompleto"];
                alunoDTO.CpfAluno = newGerador.EraseEspecialAndReturnLong(collection["cpf"]);
                alunoDTO.DataNascimentoAluno = DateTime.Parse(collection["dataNascimento"], new CultureInfo("pt-BR"));
                alunoDTO.TelefoneAluno = newGerador.EraseEspecialAndReturnInt(collection["telefone"]);
                alunoDTO.CelularAluno = newGerador.EraseEspecialAndReturnInt(collection["celular"]);
                alunoDTO.SexoAluno = newGerador.EraseEspecialAndReturnInt(collection["sexo"]);
                alunoDTO.ImagemAluno = filePath.ToString();

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
        public ActionResult Edit(long id)
        {
            var alunoDTO = _alunoRepository.GetbyId(id);

            return View("~/Views/Edit/AlunoEdit", alunoDTO);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, Models.Conta newConta, Models.Endereco newEndereco, Models.Aluno newAluno)
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
        public ActionResult Delete(long id)
        {
            Domain.DTO.Aluno alunoDTO = new Domain.DTO.Aluno();
            alunoDTO.IdAluno = id;

            _alunoRepository.Remove(alunoDTO);

            return View("~/Views/Main/AlunoMain");
        }
    }
}