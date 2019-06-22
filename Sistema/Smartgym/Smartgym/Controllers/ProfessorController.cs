using Auxiliary;
using Auxiliary.Partial;
using Domain.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Smartgym.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IHostingEnvironment _hosting;

        private Geradores newGerador = new Geradores();
        private DataTable newDataTable = new DataTable();

        public ProfessorController(IProfessorRepository professorRepository, IUnidadeRepository unidadeRepository, IContaRepository contaRepository, IEnderecoRepository enderecoRepository, IHostingEnvironment hosting)
        {
            _professorRepository = professorRepository;
            _unidadeRepository = unidadeRepository;
            _contaRepository = contaRepository;
            _enderecoRepository = enderecoRepository;
            _hosting = hosting;
        }

        // GET: Professor
        public ActionResult Index()
        {
            var professorDTO = _professorRepository.GetAll();

            return View("~/Views/Main/ProfessorMain.cshtml", professorDTO);
        }

        [HttpPost]
        public IActionResult GetAllProfessores()
        {
            var requestFormData = Request.Form;

            var professorDTO = _professorRepository.GetAll();

            var listProfessorForm = newDataTable.ProfessorDataProcessForm(professorDTO, requestFormData);

            var count = professorDTO.Count();

            dynamic response = new
            {
                Data = listProfessorForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            var unidadeDTO = _unidadeRepository.GetAll();

            return View("~/Views/Register/ProfessorRegister.cshtml", unidadeDTO);
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(long idUnidade, IFormCollection collection)
        {
            try
            {
                var nomeArquivo = string.Empty;

                if (collection.Files.Count == 1)
                {
                    var caminhoArquivo = Path.GetTempFileName();
                    nomeArquivo = newGerador.GetFileName(collection["nomeCompleto"], collection.Files[0].ContentType.Split("/")[1]);
                    var filePath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Professor", nomeArquivo);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await collection.Files[0].CopyToAsync(stream);
                    }
                }
                else
                {
                    nomeArquivo = "img/Cadastro/Default_Image.png";
                }

                // Unidade
                var unidadeDTO = _unidadeRepository.GetbyId(idUnidade);

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

                // Professor
                Domain.DTO.Professor professorDTO = new Domain.DTO.Professor();
                professorDTO.ContaProfessor = contaDTO;
                professorDTO.EnderecoProfessor = enderecoDTO;
                professorDTO.UnidadeProfessor = unidadeDTO;
                professorDTO.PermissaoProfessor = 2;
                professorDTO.CrefProfessor = collection["cref"];
                professorDTO.NomeProfessor = collection["nomeCompleto"];
                professorDTO.CpfProfessor = newGerador.EraseEspecialAndReturnLong(collection["cpf"]);
                professorDTO.DataNascimentoProfessor = DateTime.Parse(collection["dataNascimento"], new CultureInfo("pt-BR"));
                professorDTO.DataAdmissaoProfessor = DateTime.Now.Date;
                professorDTO.TelefoneProfessor = newGerador.EraseEspecialAndReturnLong(collection["telefone"]);
                professorDTO.CelularProfessor = newGerador.EraseEspecialAndReturnLong(collection["celular"]);
                professorDTO.SexoProfessor = newGerador.EraseEspecialAndReturnInt(collection["sexo"]);
                professorDTO.ImagemProfessor = "/img/Recebido/Perfil/Professor/" + nomeArquivo;

                _professorRepository.Incluid(professorDTO);

                Created("Professor/Create", professorDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(long id)
        {
            ViewProfessor viewProfessor = new ViewProfessor();

            viewProfessor.Professor = _professorRepository.GetbyId(id);
            viewProfessor.Unidade = _unidadeRepository.GetAll();

            return View("~/Views/Edit/ProfessorEdit.cshtml", viewProfessor);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, long idUnidade, IFormCollection collection)
        {
            try
            {
                var professorDTOOld = _professorRepository.GetbyId(id);

                var nomeArquivo = string.Empty;

                if (collection.Files.Count == 1)
                {
                    var caminhoArquivo = Path.GetTempFileName();
                    nomeArquivo = newGerador.GetFileName(collection["nomeCompleto"], collection.Files[0].ContentType.Split("/")[1]);
                    var filePath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Professor", nomeArquivo);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await collection.Files[0].CopyToAsync(stream);
                    }
                }
                else
                {
                    if (professorDTOOld.ImagemProfessor.Length < 0)
                    {
                        nomeArquivo = "img/Cadastro/Default_Image.png";
                    }
                }

                // Unidade
                var unidadeDTO = _unidadeRepository.GetbyId(idUnidade);

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

                // Professor
                Domain.DTO.Professor professorDTO = new Domain.DTO.Professor();
                professorDTO.ContaProfessor = contaDTO;
                professorDTO.EnderecoProfessor = enderecoDTO;
                professorDTO.UnidadeProfessor = unidadeDTO;
                professorDTO.PermissaoProfessor = 2;
                professorDTO.CrefProfessor = collection["cref"];
                professorDTO.NomeProfessor = collection["nomeCompleto"];
                professorDTO.CpfProfessor = newGerador.EraseEspecialAndReturnLong(collection["cpf"]);
                professorDTO.DataNascimentoProfessor = DateTime.Parse(collection["dataNascimento"], new CultureInfo("pt-BR"));
                professorDTO.DataAdmissaoProfessor = DateTime.Now.Date;
                professorDTO.TelefoneProfessor = newGerador.EraseEspecialAndReturnLong(collection["telefone"]);
                professorDTO.CelularProfessor = newGerador.EraseEspecialAndReturnLong(collection["celular"]);
                professorDTO.SexoProfessor = newGerador.EraseEspecialAndReturnInt(collection["sexo"]);
                professorDTO.ImagemProfessor = "/img/Recebido/Perfil/Professor/" + nomeArquivo;

                _professorRepository.Incluid(professorDTO);

                Created("Professor/Create", professorDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(long id)
        {
            var professorDTO = _professorRepository.GetbyId(id);
            var contaDTO = professorDTO.ContaProfessor;
            var enderecoDTO = professorDTO.EnderecoProfessor;

            var imgPath = _hosting + professorDTO.ImagemProfessor;

            if (Directory.Exists(imgPath))
            {
                System.IO.File.Delete(imgPath);
            }

            _professorRepository.Remove(professorDTO);
            _contaRepository.Remove(contaDTO);
            _enderecoRepository.Remove(enderecoDTO);

            return View("~/Views/Main/ProfessorMain.cshtml");
        }
    }
}