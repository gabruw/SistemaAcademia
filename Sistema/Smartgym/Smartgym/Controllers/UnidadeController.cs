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
        public ActionResult Index()
        {
            var unidadeDTO = _unidadeRepository.GetAll();

            return View("~/Views/Main/UnidadeMain.cshtml", unidadeDTO);
        }

        [HttpPost]
        public IActionResult GetAllUnidades()
        {
            var requestFormData = Request.Form;

            var unidadeDTO = _unidadeRepository.GetAll();

            var listUnidadeForm = newDataTable.UnidadeDataProcessForm(unidadeDTO, requestFormData);

            var count = unidadeDTO.Count();

            dynamic response = new
            {
                Data = listUnidadeForm,
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
                    nomeArquivo = "img/Principal/Default_Image.png";
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
                Domain.DTO.Endereco enderecoDTO = new Domain.DTO.Endereco();
                enderecoDTO.IdEndereco = unidadeDTOOld.EnderecoUnidade.IdEndereco;
                enderecoDTO.CepEndereco = newGerador.EraseEspecialAndReturnInt(collection["cep"]);
                enderecoDTO.RuaEndereco = collection["rua"];
                enderecoDTO.BairroEndereco = collection["bairro"];
                enderecoDTO.NumeroEndereco = newGerador.EraseEspecialAndReturnInt(collection["numero"]);
                enderecoDTO.ComplementoEndereco = newGerador.EraseEspecialAndReturnInt(collection["complemento"]);

                // Unidade
                Domain.DTO.Unidade unidadeDTO = new Domain.DTO.Unidade();
                unidadeDTO.IdUnidade = id;
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

                    var imgPath = Path.Combine(_hosting.WebRootPath, "img", "Recebido", "Perfil", "Unidade", unidadeDTOOld.ImagemUnidade);

                    try
                    {
                        System.IO.File.Delete(imgPath);
                    }
                    catch
                    {
                        
                    }

                    unidadeDTO.ImagemUnidade = "/img/Recebido/Perfil/Unidade/" + nomeArquivo;
                }
                else if (unidadeDTOOld.ImagemUnidade.Length < 0)
                {
                    unidadeDTO.ImagemUnidade = "img/Principal/Default_Image.png";
                }
                else
                {
                    unidadeDTO.ImagemUnidade = unidadeDTOOld.ImagemUnidade;
                }

                _unidadeRepository.Update(unidadeDTO);

                Created("Unidade/Edit", unidadeDTO);

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