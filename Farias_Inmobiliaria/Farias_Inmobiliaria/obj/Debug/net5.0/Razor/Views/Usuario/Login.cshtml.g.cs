#pragma checksum "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Usuario\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0eeb2c5719a75fe761d24fdf389b5e1a174ddba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Login), @"mvc.1.0.view", @"/Views/Usuario/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0eeb2c5719a75fe761d24fdf389b5e1a174ddba", @"/Views/Usuario/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f638455819c96ada468791a06c29250bbe1e0ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Usuario\Login.cshtml"
  
	ViewData["Title"] = "Acceso de usuarios";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Genaro\Documents\TUDS\Archivos locales de VS\Inmobiliaria\Farias_Inmobiliaria\Farias_Inmobiliaria\Views\Usuario\Login.cshtml"
Write(await Html.PartialAsync("_Login"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591