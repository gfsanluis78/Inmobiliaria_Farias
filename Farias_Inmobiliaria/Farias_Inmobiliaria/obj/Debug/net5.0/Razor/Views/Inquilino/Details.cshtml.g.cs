#pragma checksum "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "295a85766b354cda46e9e77de7ac0c1cb983c70a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inquilino_Details), @"mvc.1.0.view", @"/Views/Inquilino/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"295a85766b354cda46e9e77de7ac0c1cb983c70a", @"/Views/Inquilino/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f638455819c96ada468791a06c29250bbe1e0ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Inquilino_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Farias_Inmobiliaria.Models.Inquilino>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
  
    ViewData["Title"] = "Detalles"; // Details

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalles</h1>\r\n\r\n<div>\r\n    <h4>Inquilino</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IdInquilino));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.IdInquilino));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dni));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 52 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inquilino\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.IdInquilino }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "295a85766b354cda46e9e77de7ac0c1cb983c70a8916", async() => {
                WriteLiteral("Volver a la Lista");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Farias_Inmobiliaria.Models.Inquilino> Html { get; private set; }
    }
}
#pragma warning restore 1591
