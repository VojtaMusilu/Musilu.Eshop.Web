#pragma checksum "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb583576e6e34068a6b4095da175dcbd147a1bfb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb583576e6e34068a6b4095da175dcbd147a1bfb", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2e4d0d72da0729318202da85a62ca64617df9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n\r\n\r\n");
#nullable restore
#line 11 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
      
        if (Model != null && Model.CarouselItems != null && Model.CarouselItems.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div id=\"carousel\" class=\"carousel slide\" data-ride=\"carousel\">\r\n                <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 16 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                      

                        for (int i = 0; i < Model.CarouselItems.Count; i++)
                        {
                            if (i == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li data-target=\"#carousel\" data-slide-to=\"");
#nullable restore
#line 22 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"active\"></li>\r\n");
#nullable restore
#line 23 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li data-target=\"#carousel\" data-slide-to=\"");
#nullable restore
#line 27 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></li>\r\n");
#nullable restore
#line 28 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ol>\r\n                <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 35 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                      

                        for (int i = 0; i < Model.CarouselItems.Count; i++)
                        {
                            if (i == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"carousel-item active\">\r\n                                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1466, "\"", 1507, 1);
#nullable restore
#line 42 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1472, Model.CarouselItems[i].ImageSource, 1472, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1508, "\"", 1546, 1);
#nullable restore
#line 42 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1514, Model.CarouselItems[i].ImageAlt, 1514, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n");
#nullable restore
#line 44 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"carousel-item\">\r\n                                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1811, "\"", 1852, 1);
#nullable restore
#line 49 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1817, Model.CarouselItems[i].ImageSource, 1817, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1853, "\"", 1891, 1);
#nullable restore
#line 49 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1859, Model.CarouselItems[i].ImageAlt, 1859, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n");
#nullable restore
#line 51 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <a class=""carousel-control-prev"" href=""#carousel"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carousel"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
");
#nullable restore
#line 67 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 71 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
      
        if (Model != null && Model.Products != null && Model.Products.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table"">
                <thead>
                    <tr>
                        <th scope=""col"">ID</th>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">Category</th>

                    </tr>
                </thead>
                <tbody>


");
#nullable restore
#line 86 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                      
                        if (Model != null && Model.Products != null)
                        {
                            for (int i = 0; i < Model.Products.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th scope=\"row\">");
#nullable restore
#line 92 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>");
#nullable restore
#line 93 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 94 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 96 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                            }
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 101 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591