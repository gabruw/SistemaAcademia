#pragma checksum "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4861cccb10f2327bbcd8b49c047c5e1baf161c56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edit_ExercicioEdit), @"mvc.1.0.view", @"/Views/Edit/ExercicioEdit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Edit/ExercicioEdit.cshtml", typeof(AspNetCore.Views_Edit_ExercicioEdit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4861cccb10f2327bbcd8b49c047c5e1baf161c56", @"/Views/Edit/ExercicioEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9005a25d01fd89251b0f37654d85a182accd7b92", @"/Views/_ViewImports.cshtml")]
    public class Views_Edit_ExercicioEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Auxiliary.Partial.ViewExercicio>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Exercicio", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
  
    ViewData["Title"] = "Editar - Exercício";
    Layout = "_RegisterAndEdit";

#line default
#line hidden
            BeginContext(90, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(132, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(144, 227, true);
            WriteLiteral("<div>\r\n    <section>\r\n        <p id=\"Titulo\">\r\n            <i id=\"IconeTitulo\" class=\"fas fa-edit\"></i>\r\n            Editar Exercício\r\n        </p>\r\n    </section>\r\n\r\n    <section id=\"DadosExercicio\" class=\"col-sm-8\">\r\n        ");
            EndContext();
            BeginContext(371, 3129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4861cccb10f2327bbcd8b49c047c5e1baf161c565667", async() => {
                BeginContext(466, 634, true);
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <span class=""ls-label-text"">Identificação</span>
                        </div>

                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-sm-6"">
                                    <span class=""ls-label-text"">Nome do Exercício</span>
                                    <input type=""text"" id=""NomeExercicio"" class=""form-control"" name=""nomeExercicio""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1100, "\"", 1151, 1);
#line 31 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
WriteAttributeValue("", 1108, Model.ExercicioViewExercicio.NomeExercicio, 1108, 43, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1152, 348, true);
                WriteLiteral(@" required>
                                </div>

                                <div class=""col-sm-6"">
                                    <span class=""ls-label-text"">Unidade</span>
                                    <select type=""text"" id=""Aparelho"" class=""form-control"" name=""aparelho"" required>
                                        ");
                EndContext();
                BeginContext(1500, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4861cccb10f2327bbcd8b49c047c5e1baf161c567550", async() => {
                    BeginContext(1508, 21, true);
                    WriteLiteral("Selecione um aparelho");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1538, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 38 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                         foreach (var aparelho in Model.AparelhorViewAgenda)
                                        {
                                            if(aparelho.IdAparelho == Model.ExercicioViewExercicio.AparelhoExercicio.IdAparelho)
                                            {

#line default
#line hidden
                BeginContext(1854, 48, true);
                WriteLiteral("                                                ");
                EndContext();
                BeginContext(1902, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4861cccb10f2327bbcd8b49c047c5e1baf161c569451", async() => {
                    BeginContext(1949, 21, false);
#line 42 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                                                                         Write(aparelho.NomeAparelho);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 42 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                                   WriteLiteral(aparelho.IdAparelho);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1979, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 43 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
                BeginContext(2125, 48, true);
                WriteLiteral("                                                ");
                EndContext();
                BeginContext(2173, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4861cccb10f2327bbcd8b49c047c5e1baf161c5612421", async() => {
                    BeginContext(2211, 21, false);
#line 46 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                                                                Write(aparelho.NomeAparelho);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 46 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                                   WriteLiteral(aparelho.IdAparelho);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2241, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 47 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                            }
                                        }

#line default
#line hidden
                BeginContext(2333, 431, true);
                WriteLiteral(@"                                    </select>
                                </div>
                            </div>

                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <span class=""ls-label-text"">Observação</span>
                                    <textarea id=""ObservacaoExercicio"" class=""form-control"" name=""observacaoExercicio"">");
                EndContext();
                BeginContext(2765, 48, false);
#line 56 "C:\Users\SHU Aeronáutica 01\Documents\GitHub\Smartgym\Sistema\Smartgym\Smartgym\Views\Edit\ExercicioEdit.cshtml"
                                                                                                                  Write(Model.ExercicioViewExercicio.ObservacaoExercicio);

#line default
#line hidden
                EndContext();
                BeginContext(2813, 680, true);
                WriteLiteral(@"</textarea>
                                </div>
                            </div>

                            <br>

                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <button type=""submit"" id=""ConfirmarEditarExercicio"" class=""btn btn-primary"">Confirmar</button>

                                    <button type=""reset"" id=""ResetEditarExercicio"" class=""btn btn-secondary"">Resetar</button>
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
            BeginContext(3500, 59, true);
            WriteLiteral("\r\n    </section>\r\n</div>\r\n\r\n<div class=\"overlay\"></div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Auxiliary.Partial.ViewExercicio> Html { get; private set; }
    }
}
#pragma warning restore 1591
