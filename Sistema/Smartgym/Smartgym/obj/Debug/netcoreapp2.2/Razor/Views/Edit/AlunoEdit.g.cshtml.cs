#pragma checksum "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec4a016b2785eb5b98994219ed6773542a03c9ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edit_AlunoEdit), @"mvc.1.0.view", @"/Views/Edit/AlunoEdit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Edit/AlunoEdit.cshtml", typeof(AspNetCore.Views_Edit_AlunoEdit))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\_ViewImports.cshtml"
using Smartgym;

#line default
#line hidden
#line 2 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\_ViewImports.cshtml"
using Smartgym.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a016b2785eb5b98994219ed6773542a03c9ca", @"/Views/Edit/AlunoEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9005a25d01fd89251b0f37654d85a182accd7b92", @"/Views/_ViewImports.cshtml")]
    public class Views_Edit_AlunoEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.DTO.Aluno>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Aluno", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
  
    ViewData["Title"] = "Editar - Aluno";
    Layout = "_RegisterAndEdit";

#line default
#line hidden
            BeginContext(84, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(111, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(123, 222, true);
            WriteLiteral("<div>\r\n    <section>\r\n        <p id=\"Titulo\">\r\n            <i id=\"IconeTitulo\" class=\"fas fa-edit\"></i>\r\n            Editar Aluno\r\n        </p>\r\n    </section>\r\n\r\n    <section id=\"DadosPessoais\" class=\"col-sm-8\">\r\n        ");
            EndContext();
            BeginContext(345, 8529, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec4a016b2785eb5b98994219ed6773542a03c9ca5374", async() => {
                BeginContext(466, 522, true);
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <span class=""ls-label-text"">Identificação</span>
                        </div>

                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-sm-4"">
                                    <img id=""ImagemPreview"" class=""img-fluid mx-auto d-block""");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 988, "\"", 1012, 1);
#line 29 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 994, Model.ImagemAluno, 994, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1013, 503, true);
                WriteLiteral(@" alt=""Imagem Perfil."" />
                                    <br>
                                    <input type=""file"" id=""ImagemPerfil"" class=""form-control-file"" name=""imagemPerfil"" accept=""image/*"">
                                </div>

                                <div class=""col-sm-8"">
                                    <span class=""ls-label-text"">Nome Completo</span>
                                    <input type=""text"" id=""NomeCompleto"" class=""form-control"" name=""nomeCompleto""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1516, "\"", 1540, 1);
#line 36 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 1524, Model.NomeAluno, 1524, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1541, 193, true);
                WriteLiteral(" required>\r\n\r\n                                    <span class=\"ls-label-text =\">Email</span>\r\n                                    <input type=\"text\" id=\"Email\" class=\"form-control\" name=\"email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1734, "\"", 1770, 1);
#line 39 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 1742, Model.ContaAluno.EmailConta, 1742, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1771, 332, true);
                WriteLiteral(@" required>

                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <span class=""ls-label-text ="">Senha</span>
                                            <input type=""password"" id=""Senha"" class=""form-control"" name=""senha""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2103, "\"", 2139, 1);
#line 44 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 2111, Model.ContaAluno.SenhaConta, 2111, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2140, 313, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-4"">
                                            <span class=""ls-label-text"">CPF</span>
                                            <input type=""text"" id=""Cpf"" class=""form-control"" name=""cpf""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2453, "\"", 2476, 1);
#line 49 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 2461, Model.CpfAluno, 2461, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2477, 313, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-4"">
                                            <span class=""ls-label-text"">CEP</span>
                                            <input type=""text"" id=""Cep"" class=""form-control"" name=""cep""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2790, "\"", 2830, 1);
#line 54 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 2798, Model.EnderecoAluno.CepEndereco, 2798, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2831, 412, true);
                WriteLiteral(@" required>
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-5"">
                                            <span class=""ls-label-text"">Rua</span>
                                            <input type=""text"" id=""Rua"" class=""form-control"" name=""rua""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3243, "\"", 3283, 1);
#line 61 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 3251, Model.EnderecoAluno.RuaEndereco, 3251, 32, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3284, 351, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-3"">
                                            <span class=""ls-label-text d-inline-block text-truncate"">Bairro</span>
                                            <input type=""text"" id=""Bairro"" class=""form-control"" name=""bairro""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3635, "\"", 3678, 1);
#line 66 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 3643, Model.EnderecoAluno.BairroEndereco, 3643, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3679, 351, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-2"">
                                            <span class=""ls-label-text d-inline-block text-truncate"">Número</span>
                                            <input type=""text"" id=""Numero"" class=""form-control"" name=""numero""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4030, "\"", 4073, 1);
#line 71 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 4038, Model.EnderecoAluno.NumeroEndereco, 4038, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4074, 360, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-2"">
                                            <span class=""ls-label-text d-inline-block text-truncate"">Compl</span>
                                            <input type=""text"" id=""Complemento"" class=""form-control"" name=""complemento""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4434, "\"", 4482, 1);
#line 76 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 4442, Model.EnderecoAluno.ComplementoEndereco, 4442, 40, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4483, 418, true);
                WriteLiteral(@">
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-6"">
                                            <span class=""ls-label-text"">Telefone</span>
                                            <input type=""text"" id=""Telefone"" class=""form-control"" name=""telefone""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4901, "\"", 4929, 1);
#line 83 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 4909, Model.TelefoneAluno, 4909, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4930, 316, true);
                WriteLiteral(@">
                                        </div>

                                        <div class=""col-sm-6"">
                                            <span class=""ls-label-text"">Celular</span>
                                            <input type=""text"" id=""Celular"" class=""form-control"" name=""celular""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5246, "\"", 5273, 1);
#line 88 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 5254, Model.CelularAluno, 5254, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5274, 440, true);
                WriteLiteral(@">
                                        </div>
                                    </div>

                                    <div class=""row"">
                                        <div class=""col-sm-6"">
                                            <span class=""ls-label-text"">Data de Nascimento</span>
                                            <input type=""date"" id=""DataNascimento"" class=""form-control"" name=""dataNascimento""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 5714, "\"", 5776, 1);
#line 95 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
WriteAttributeValue("", 5722, Model.DataNascimentoAluno.Date.ToString("yyyy-MM-dd"), 5722, 54, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5777, 478, true);
                WriteLiteral(@" required>
                                        </div>

                                        <div class=""col-sm-6"">
                                            <span class=""ls-label-text"">Sexo</span>
                                            <br>
                                            <div class=""custom-control custom-radio custom-control-inline"">
                                                <label class=""radio-inline control-label"" for=""Masculino"">
");
                EndContext();
#line 103 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                     if (Model.SexoAluno == 1)
                                                    {

#line default
#line hidden
                BeginContext(6390, 148, true);
                WriteLiteral("                                                        <input type=\"radio\" class=\"form-check-input\" id=\"Masculino\" name=\"sexo\" value=\"1\" checked>\r\n");
                EndContext();
#line 106 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
                BeginContext(6706, 140, true);
                WriteLiteral("                                                        <input type=\"radio\" class=\"form-check-input\" id=\"Masculino\" name=\"sexo\" value=\"1\">\r\n");
                EndContext();
#line 110 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                    }

#line default
#line hidden
                BeginContext(6901, 393, true);
                WriteLiteral(@"
                                                    Masculino
                                                </label>
                                            </div>

                                            <div class=""custom-control custom-radio custom-control-inline"">
                                                <label class=""radio-inline control-label"" for=""Feminino"">
");
                EndContext();
#line 118 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                     if (Model.SexoAluno == 2)
                                                    {

#line default
#line hidden
                BeginContext(7429, 147, true);
                WriteLiteral("                                                        <input type=\"radio\" class=\"form-check-input\" id=\"Feminino\" name=\"sexo\" value=\"2\" checked>\r\n");
                EndContext();
#line 121 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
                BeginContext(7744, 139, true);
                WriteLiteral("                                                        <input type=\"radio\" class=\"form-check-input\" id=\"Feminino\" name=\"sexo\" value=\"2\">\r\n");
                EndContext();
#line 125 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                    }

#line default
#line hidden
                BeginContext(7938, 929, true);
                WriteLiteral(@"
                                                    Feminino
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br>

                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <button type=""submit"" id=""ConfirmarCadastroAluno"" class=""btn btn-primary"">Confirmar</button>

                                    <button type=""reset"" id=""ResetCadastroAluno"" class=""btn btn-secondary"">Resetar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 18 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\AlunoEdit.cshtml"
                                                         WriteLiteral(Model.IdAluno);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8874, 53, true);
            WriteLiteral("\r\n    </section>\r\n</div>\r\n<div class=\"overlay\"></div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.DTO.Aluno> Html { get; private set; }
    }
}
#pragma warning restore 1591
