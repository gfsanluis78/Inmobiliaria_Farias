#pragma checksum "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ce0db846a2e1a9270ad11ef4fbcebbd462b39b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inmueble_BusquedaTodos), @"mvc.1.0.view", @"/Views/Inmueble/BusquedaTodos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ce0db846a2e1a9270ad11ef4fbcebbd462b39b0", @"/Views/Inmueble/BusquedaTodos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f638455819c96ada468791a06c29250bbe1e0ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Inmueble_BusquedaTodos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Farias_Inmobiliaria.Models.Inmueble>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Detalles"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
  
    ViewData["Title"] = "Busqueda Inmuebles del propietario";
    Propietario propietario = ViewBag.propietario;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inmuebles de ");
#nullable restore
#line 8 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
            Write(propietario.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 8 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
                                Write(propietario.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce0db846a2e1a9270ad11ef4fbcebbd462b39b06968", async() => {
                WriteLiteral("Crear Nuevo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.PrecioAproximado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.MontoAlquilerPropuesto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayNameFor(model => model.Disponibilidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th>\r\n                Acciones\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdInmueble));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.Uso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.Tipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.PrecioAproximado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 66 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
           Write(Html.DisplayFor(modelItem => item.MontoAlquilerPropuesto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 69 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
            Write(item.Disponibilidad == false ? "No disponible" : "Disponible");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce0db846a2e1a9270ad11ef4fbcebbd462b39b014210", async() => {
                WriteLiteral("<span class=\"lnr lnr-pencil\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
                                       WriteLiteral(item.IdInmueble);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp; |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce0db846a2e1a9270ad11ef4fbcebbd462b39b016570", async() => {
                WriteLiteral("<span class=\"lnr lnr-eye\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
                                          WriteLiteral(item.IdInmueble);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp; |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce0db846a2e1a9270ad11ef4fbcebbd462b39b018930", async() => {
                WriteLiteral("<span class=\"lnr lnr-cross\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
                                         WriteLiteral(item.IdInmueble);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 78 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Inmueble\BusquedaTodos.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Farias_Inmobiliaria.Models.Inmueble>> Html { get; private set; }
    }
}
#pragma warning restore 1591