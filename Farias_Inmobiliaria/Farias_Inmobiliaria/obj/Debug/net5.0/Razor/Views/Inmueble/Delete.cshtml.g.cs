#pragma checksum "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c442d990ce903ff5aab7c6d4d189d062ef6015cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inmueble_Delete), @"mvc.1.0.view", @"/Views/Inmueble/Delete.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\_ViewImports.cshtml"
using Farias_Inmobiliaria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\_ViewImports.cshtml"
using Farias_Inmobiliaria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c442d990ce903ff5aab7c6d4d189d062ef6015cf", @"/Views/Inmueble/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f638455819c96ada468791a06c29250bbe1e0ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Inmueble_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Farias_Inmobiliaria.Models.Inmueble>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
  
    ViewData["Title"] = "Borrar";
    var Propietarios = (IList<Propietario>)ViewBag.Propietarios;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Borrar</h1>\r\n\r\n<h3>Seguro quiere Borrar esto?</h3>\r\n<div>\r\n    <h4>Inmueble</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Superficie));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Latitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Latitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Longitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Longitud));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 50 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 53 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 56 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 59 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 62 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Ambientes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 65 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PrecioAproximado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 68 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PrecioAproximado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 71 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IdPropietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n");
#nullable restore
#line 74 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
             if(Model != null) { 
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
            Write(Model.Duenio.Nombre + " " + Model.Duenio.Apellido);

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\Delete.cshtml"
                                                                    
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c442d990ce903ff5aab7c6d4d189d062ef6015cf13181", async() => {
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Borrar\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c442d990ce903ff5aab7c6d4d189d062ef6015cf13529", async() => {
                    WriteLiteral("Volver a la Lista");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Farias_Inmobiliaria.Models.Inmueble> Html { get; private set; }
    }
}
#pragma warning restore 1591
