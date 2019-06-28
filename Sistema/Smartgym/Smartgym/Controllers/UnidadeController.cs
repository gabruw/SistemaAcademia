using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auxiliary;
using Domain.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Smartgym.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IHostingEnvironment _hosting;

        private Geradores newGerador = new Geradores();
        private DataTable newDataTable = new DataTable();

        public UnidadeController(IUnidadeRepository unidadeRepository, IEnderecoRepository enderecoRepository, IHostingEnvironment hosting)
        {
            _unidadeRepository = unidadeRepository;
            _enderecoRepository = enderecoRepository;
            _hosting = hosting;
        }

        // GET: Unidade
        public ActionResult Index(int permissao, string nome)
        {
            Auxiliary.Partial.AccountInformation accountInformation = new Auxiliary.Partial.AccountInformation();
            accountInformation.Permissao = permissao;
            accountInformation.Nome = nome;

            return View("~/Views/Main/UnidadeMain.cshtml", accountInformation);
        }

        [HttpPost]
        public IActionResult GetAllUnidades()
        {
            var requestFormData = Request.Form;

            var unidadeDTO = _unidadeRepository.GetAll();

            var listUnidadeForm = newDataTable.UnidadeDataProcessForm(unidadeDTO, requestFormData);

            var count = unidadeDTO.Count();

            List<Models.Unidade> list = new List<Models.Unidade>();

            foreach (var unic in listUnidadeForm)
            {
                Models.Endereco partialEnd = new Models.Endereco();
                partialEnd.RuaEndereco = unic.EnderecoUnidade.RuaEndereco;
                partialEnd.BairroEndereco = unic.EnderecoUnidade.BairroEndereco;

                Models.Unidade partialUnd = new Models.Unidade();
                partialUnd.IdUnidade = unic.IdUnidade;
                partialUnd.NomeUnidade = unic.NomeUnidade;
                partialUnd.EnderecoUnidade = partialEnd;

                list.Add(partialUnd);
            }

            dynamic response = new
            {
                Data = list,
                Draw = requestFormData["draw"],
                RecordsFiltered = count,
                RecordTotal = count,
            };

            return Ok(response);
        }

        // GET: Unidade/Create
        public ActionResult Create()
        {
            return View("~/Views/Register/UnidadeRegister.cshtml");
        }

        // POST: Unidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                // Endereço
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.CepEndereco = newGerador.EraseEspecialAndReturnInt(collection["cep"]);
                enderecoDTO.RuaEndereco = collection["rua"];
                enderecoDTO.BairroEndereco = collection["bairro"];
                enderecoDTO.NumeroEndereco = newGerador.EraseEspecialAndReturnInt(collection["numero"]);
                enderecoDTO.ComplementoEndereco = newGerador.EraseEspecialAndReturnInt(collection["complemento"]);

                // Unidade
                Domain.DTO.Unidade unidadeDTO = new Domain.DTO.Unidade();
                unidadeDTO.NomeUnidade = collection["nomeUnidade"];
                unidadeDTO.EnderecoUnidade = enderecoDTO;

                var nomeArquivo = string.Empty;

                if (collection.Files.Count == 1)
                {
                    var caminhoArquivo = Path.GetTempFileName();
                    nomeArquivo = newGerador.GetFileName(collection["nomeUnidade"], collection.Files[0].ContentType.Split("/")[1]);
                    var filePath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", nomeArquivo);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await collection.Files[0].CopyToAsync(stream);
                    }
                }
                else
                {
                    var filePathO = Path.Combine(_hosting.WebRootPath, "img", "Principal", "Default_Image.png");
                    nomeArquivo = newGerador.GetFileName("Default_Image", ".png");

                    var filePathD = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", nomeArquivo);

                    System.IO.File.Copy(filePathO, filePathD, true);
                }

                unidadeDTO.ImagemUnidade = "/img/Recebido/Perfil/Unidade/" + nomeArquivo;

                _unidadeRepository.Incluid(unidadeDTO);

                Created("Unidade/Create", unidadeDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // GET: Unidade/Edit/5
        public ActionResult Edit(long id)
        {
            var unidadeDTO = _unidadeRepository.GetbyId(id);

            return View("~/Views/Edit/UnidadeEdit.cshtml", unidadeDTO);
        }

        // POST: Unidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, IFormCollection collection)
        {
            try
            {
                // Unidade OLD
                var unidadeDTOOld = _unidadeRepository.GetbyId(id);

                // Endereço
                unidadeDTOOld.EnderecoUnidade.CepEndereco = newGerador.EraseEspecialAndReturnInt(collection["cep"]);
                unidadeDTOOld.EnderecoUnidade.RuaEndereco = collection["rua"];
                unidadeDTOOld.EnderecoUnidade.BairroEndereco = collection["bairro"];
                unidadeDTOOld.EnderecoUnidade.NumeroEndereco = newGerador.EraseEspecialAndReturnInt(collection["numero"]);
                unidadeDTOOld.EnderecoUnidade.ComplementoEndereco = newGerador.EraseEspecialAndReturnInt(collection["complemento"]);

                // Unidade
                unidadeDTOOld.NomeUnidade = collection["nomeUnidade"];

                var nomeArquivo = string.Empty;

                if (collection.Files.Count == 1)
                {
                    var caminhoArquivo = Path.GetTempFileName();
                    nomeArquivo = newGerador.GetFileName(collection["nomeUnidade"], collection.Files[0].ContentType.Split("/")[1]);
                    var filePath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", nomeArquivo);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await collection.Files[0].CopyToAsync(stream);
                    }

                    var imgPath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", unidadeDTOOld.ImagemUnidade);

                    try
                    {
                        System.IO.File.Delete(imgPath);
                    }
                    catch
                    {
                        
                    }

                    unidadeDTOOld.ImagemUnidade = "/img/Recebido/Perfil/Unidade/" + nomeArquivo;
                }

                _unidadeRepository.Update(unidadeDTOOld);

                Created("Unidade/Edit", unidadeDTOOld);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/_GenericalExceptionView.cshtml", ex);
            }
        }

        // POST: Unidade/Delete/5
        public ActionResult Delete(long id)
        {
            var unidadeDTO = _unidadeRepository.GetbyId(id);
            var enderecoDTO = unidadeDTO.EnderecoUnidade;

            var imgPath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", unidadeDTO.ImagemUnidade.Split("/").Last());

            try
            {
                System.IO.File.Delete(imgPath);
            }
            catch
            {

            }

            _unidadeRepository.Remove(unidadeDTO);
            _enderecoRepository.Remove(enderecoDTO);

            return View("~/Views/Main/UnidadeMain.cshtml");
        }
    }
}