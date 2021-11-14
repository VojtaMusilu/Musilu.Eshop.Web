#pragma checksum "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa0eb39511071a8a907e7d24016fa741a36dcd2d"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa0eb39511071a8a907e7d24016fa741a36dcd2d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2e4d0d72da0729318202da85a62ca64617df9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n    <h1 class=\"display-4\">products</h1>\r\n\r\n\r\n\r\n");
#nullable restore
#line 74 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
      


        if (Model != null && Model.Products != null && Model.Products.Count >= 0)
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
#line 92 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                      
                        if (Model != null && Model.Products != null)
                        {
                            for (int i = 0; i < Model.Products.Count; i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th scope=\"row\">");
#nullable restore
#line 98 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>");
#nullable restore
#line 99 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 100 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 102 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                            }
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
            WriteLiteral("            <div class=\"container px-4 px-lg-5 mt-5 \">\r\n");
#nullable restore
#line 111 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                  
                    int count = 0;
                    for (int i = 0; i < Model.Products.Count; i += 3)
                    {
                        count = Model.Products.Count - i;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center\">\r\n\r\n                            <div class=\"col mb-5\">\r\n");
#nullable restore
#line 119 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                  
                                    if (count > 0)
                                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"card\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 4440, "\"", 4476, 1);
#nullable restore
#line 124 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 4446, Model.Products[i].ImageSource, 4446, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 4498, "\"", 4531, 1);
#nullable restore
#line 124 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 4504, Model.Products[i].ImageAlt, 4504, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <div class=\"card-body\">\r\n                                                <h5 class=\"card-title\">");
#nullable restore
#line 126 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                  Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                                <h6>");
#nullable restore
#line 127 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa0eb39511071a8a907e7d24016fa741a36dcd2d15094", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 128 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                         WriteLiteral(Model.Products[i].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <a href=\"#\" class=\"btn btn-primary\">Přidat do košíku</a>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 132 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"col\">\r\n");
#nullable restore
#line 136 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                  
                                    if (count > 1)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"card\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 5530, "\"", 5568, 1);
#nullable restore
#line 140 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 5536, Model.Products[i+1].ImageSource, 5536, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 5590, "\"", 5625, 1);
#nullable restore
#line 140 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 5596, Model.Products[i+1].ImageAlt, 5596, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <div class=\"card-body\">\r\n                                                <h5 class=\"card-title\">");
#nullable restore
#line 142 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                  Write(Model.Products[i + 1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                                <h6>");
#nullable restore
#line 143 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i + 1].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa0eb39511071a8a907e7d24016fa741a36dcd2d19940", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                         WriteLiteral(Model.Products[i+1].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <a href=\"#\" class=\"btn btn-primary\">Přidat do košíku</a>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 148 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <div class=\"col\">\r\n");
#nullable restore
#line 152 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                  
                                    if (count > 2)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"card\">\r\n                                            <img");
            BeginWriteAttribute("src", " src=\"", 6634, "\"", 6672, 1);
#nullable restore
#line 156 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 6640, Model.Products[i+2].ImageSource, 6640, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 6694, "\"", 6729, 1);
#nullable restore
#line 156 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 6700, Model.Products[i+2].ImageAlt, 6700, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                            <div class=\"card-body\">\r\n                                                <h5 class=\"card-title\">");
#nullable restore
#line 158 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                  Write(Model.Products[i + 2].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                                <h6>");
#nullable restore
#line 159 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i + 2].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa0eb39511071a8a907e7d24016fa741a36dcd2d24788", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 160 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                         WriteLiteral(Model.Products[i+2].ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                <a href=\"#\" class=\"btn btn-primary\">Přidat do košíku</a>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 164 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 168 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 171 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    <section class=""py-5"">
        <div class=""container px-4 px-lg-5 mt-5"">
            <div class=""row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center"">
                <div class=""col mb-5"">
                    <div class=""card h-100"">
                        <!-- Product image-->
                        <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                        <!-- Product details-->
                        <div class=""card-body p-4"">
                            <div class=""text-center"">
                                <!-- Product name-->
                                <h5 class=""fw-bolder"">Fancy Product</h5>
                                <!-- Product price-->
                                $40.00 - $80.00
                            </div>
                        </div>
                        <!-- Product actions-->
                        <div class=""card-footer p-4 pt-0 border-top-0 bg-tran");
            WriteLiteral(@"sparent"">
                            <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">View options</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</div>
");
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
