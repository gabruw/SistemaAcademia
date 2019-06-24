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
            return View("~/Views/Main/ProfessorMain.cshtml");
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
        public async Task<ActionResult> Create(IFormCollection collection)
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
                professorDTO.IdUnidadeProfessor = newGerador.EraseEspecialAndReturnLong(collection["unidade"]);
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

                //Domain.DTO.Unidade unidadeDTO = new Domain.DTO.Unidade();
                //unidadeDTO.ProfessorUnidade.Add(professorDTO);

                //_unidadeRepository.Update(unidadeDTO);

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
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // Professor OLD
                var professorDTOOld = _professorRepository.GetbyId(id);

                // Conta
                professorDTOOld.ContaProfessor.EmailConta = collection["email"];
                professorDTOOld.ContaProfessor.SenhaConta = collection["senha"];

                // Endereço
                professorDTOOld.EnderecoProfessor.CepEndereco = newGerador.EraseEspecialAndReturnInt(collection["cep"]);
                professorDTOOld.EnderecoProfessor.RuaEndereco = collection["rua"];
                professorDTOOld.EnderecoProfessor.BairroEndereco = collection["bairro"];
                professorDTOOld.EnderecoProfessor.NumeroEndereco = newGerador.EraseEspecialAndReturnInt(collection["numero"]);
                professorDTOOld.EnderecoProfessor.ComplementoEndereco = newGerador.EraseEspecialAndReturnInt(collection["complemento"]);

                // Professor
                professorDTOOld.IdUnidadeProfessor = newGerador.EraseEspecialAndReturnLong(collection["unidade"]);
                professorDTOOld.CrefProfessor = collection["cref"];
                professorDTOOld.NomeProfessor = collection["nomeCompleto"];
                professorDTOOld.CpfProfessor = newGerador.EraseEspecialAndReturnLong(collection["cpf"]);
                professorDTOOld.DataNascimentoProfessor = DateTime.Parse(collection["dataNascimento"], new CultureInfo("pt-BR"));
                professorDTOOld.DataAdmissaoProfessor = DateTime.Now.Date;
                professorDTOOld.TelefoneProfessor = newGerador.EraseEspecialAndReturnLong(collection["telefone"]);
                professorDTOOld.CelularProfessor = newGerador.EraseEspecialAndReturnLong(collection["celular"]);
                professorDTOOld.SexoProfessor = newGerador.EraseEspecialAndReturnInt(collection["sexo"]);

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

                    var imgPath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Professor", professorDTOOld.ImagemProfessor);

                    try
                    {
                        System.IO.File.Delete(imgPath);
                    }
                    catch
                    {

                    }

                    professorDTOOld.ImagemProfessor = "/img/Recebido/Perfil/Professor/" + nomeArquivo;
                }

                _professorRepository.Incluid(professorDTOOld);

                Created("Professor/Create", professorDTOOld);

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

            var imgPath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Professor", professorDTO.ImagemProfessor);

            try
            {
                System.IO.File.Delete(imgPath);
            }
            catch
            {

            }

            _professorRepository.Remove(professorDTO);
            _contaRepository.Remove(contaDTO);
            _enderecoRepository.Remove(enderecoDTO);

            return View("~/Views/Main/ProfessorMain.cshtml");
        }
    }
}