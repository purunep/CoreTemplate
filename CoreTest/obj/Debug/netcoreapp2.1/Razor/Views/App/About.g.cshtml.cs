#pragma checksum "C:\projects\Core\CoreTemplate\CoreTest\Views\App\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b450e9d8622bdd62e7aee13f8ffd74434f26e69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_App_About), @"mvc.1.0.view", @"/Views/App/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/App/About.cshtml", typeof(AspNetCore.Views_App_About))]
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
#line 1 "C:\projects\Core\CoreTemplate\CoreTest\Views\_ViewImports.cshtml"
using CoreTest.ViewModels;

#line default
#line hidden
#line 2 "C:\projects\Core\CoreTemplate\CoreTest\Views\_ViewImports.cshtml"
using CoreTest.Controllers;

#line default
#line hidden
#line 3 "C:\projects\Core\CoreTemplate\CoreTest\Views\_ViewImports.cshtml"
using CoreTest.Data.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b450e9d8622bdd62e7aee13f8ffd74434f26e69", @"/Views/App/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a6163f9b20ca1a64c5d16d4d93e62168acc24b1", @"/Views/_ViewImports.cshtml")]
    public class Views_App_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(5, 13, false);
#line 1 "C:\projects\Core\CoreTemplate\CoreTest\Views\App\About.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(18, 5, true);
            WriteLiteral("</h2>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
