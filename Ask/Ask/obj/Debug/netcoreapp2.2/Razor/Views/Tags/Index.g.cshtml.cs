#pragma checksum "E:\VsProjects\Ask\Ask\Views\Tags\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b87e23ebae01cd5ea07a4091de53e8f0c8e11368"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tags_Index), @"mvc.1.0.view", @"/Views/Tags/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tags/Index.cshtml", typeof(AspNetCore.Views_Tags_Index))]
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
#line 2 "E:\VsProjects\Ask\Ask\Views\_ViewImports.cshtml"
using Ask.Models.ViewModels;

#line default
#line hidden
#line 3 "E:\VsProjects\Ask\Ask\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 4 "E:\VsProjects\Ask\Ask\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 5 "E:\VsProjects\Ask\Ask\Views\_ViewImports.cshtml"
using Ask.Models;

#line default
#line hidden
#line 6 "E:\VsProjects\Ask\Ask\Views\_ViewImports.cshtml"
using Ask.Models.DbModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b87e23ebae01cd5ea07a4091de53e8f0c8e11368", @"/Views/Tags/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcf123010ef339935242ab65c508592f48494d8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Tags_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Tag>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 312, true);
            WriteLiteral(@"<div class=""m-2""><h3>Tags</h3></div>
<div><p class=""text-black-50"" style=""font-size:15px"">A tag is a keyword or label that categorizes your question with other, similar questions. Using the right tags makes it easier for others to find and answer your question.</p></div>
<hr />
<div class=""card-columns"">

");
            EndContext();
#line 9 "E:\VsProjects\Ask\Ask\Views\Tags\Index.cshtml"
     foreach (var tag in Model)
    {

#line default
#line hidden
            BeginContext(384, 147, true);
            WriteLiteral("        <div class=\"card border-light mb-3 mr-2\" style=\"max-width: 18rem;\">\r\n            <div class=\"card-header bg-transparent\"><sp class=\"q-tag\">");
            EndContext();
            BeginContext(532, 8, false);
#line 12 "E:\VsProjects\Ask\Ask\Views\Tags\Index.cshtml"
                                                                 Write(tag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(540, 120, true);
            WriteLiteral("</sp></div>\r\n            <div class=\"card-body text-black-50\" >\r\n                \r\n                <p class=\"card-text\">");
            EndContext();
            BeginContext(661, 15, false);
#line 15 "E:\VsProjects\Ask\Ask\Views\Tags\Index.cshtml"
                                Write(tag.Description);

#line default
#line hidden
            EndContext();
            BeginContext(676, 42, true);
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 18 "E:\VsProjects\Ask\Ask\Views\Tags\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(725, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Tag>> Html { get; private set; }
    }
}
#pragma warning restore 1591
