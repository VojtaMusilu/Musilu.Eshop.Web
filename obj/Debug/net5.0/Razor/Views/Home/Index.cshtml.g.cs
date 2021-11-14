#pragma checksum "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abdb72a6857616825199638bda5fd471f45000bf"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abdb72a6857616825199638bda5fd471f45000bf", @"/Views/Home/Index.cshtml")]
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
            WriteLiteral("\n<div class=\"text-center\">\n    <h1 class=\"display-4\">Welcome</h1>\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\n\n\n");
#nullable restore
#line 11 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
      
        if (Model != null && Model.CarouselItems != null && Model.CarouselItems.Count > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div id=\"carousel\" class=\"carousel slide\" data-ride=\"carousel\">\n                <ol class=\"carousel-indicators\">\n");
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
            WriteLiteral("\" class=\"active\"></li>\n");
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
            WriteLiteral("\"></li>\n");
#nullable restore
#line 28 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ol>\n                <div class=\"carousel-inner\">\n");
#nullable restore
#line 35 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                      

                        for (int i = 0; i < Model.CarouselItems.Count; i++)
                        {
                            if (i == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"carousel-item active\">\n                                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1425, "\"", 1466, 1);
#nullable restore
#line 42 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1431, Model.CarouselItems[i].ImageSource, 1431, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1467, "\"", 1505, 1);
#nullable restore
#line 42 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1473, Model.CarouselItems[i].ImageAlt, 1473, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                </div>\n");
#nullable restore
#line 44 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"carousel-item\">\n                                    <img class=\"d-block w-100\"");
            BeginWriteAttribute("src", " src=\"", 1763, "\"", 1804, 1);
#nullable restore
#line 49 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1769, Model.CarouselItems[i].ImageSource, 1769, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1805, "\"", 1843, 1);
#nullable restore
#line 49 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1811, Model.CarouselItems[i].ImageAlt, 1811, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                </div>\n");
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
            WriteLiteral("\n    <h1 class=\"display-4\">products</h1>\n\n\n\n");
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
            WriteLiteral("                                <tr>\n                                    <th scope=\"row\">");
#nullable restore
#line 98 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                               Write(Model.Products[i].ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                                    <td>");
#nullable restore
#line 99 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>");
#nullable restore
#line 100 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                   Write(Model.Products[i].Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                </tr>\n");
#nullable restore
#line 102 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                            }
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n");
            WriteLiteral("            <div class=\"container\">\n");
#nullable restore
#line 111 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                  
                    int count = 0;
                    for (int i = 0; i < Model.Products.Count; i += 3)
                    {
                        count = Model.Products.Count - i;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"row\">\n                                    \n                                    <div class=\"col\">\n");
#nullable restore
#line 119 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                          
                                            if (count > 0)
                                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"card\">\n                                                    <img");
            BeginWriteAttribute("src", " src=\"", 4319, "\"", 4355, 1);
#nullable restore
#line 124 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 4325, Model.Products[i].ImageSource, 4325, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 4377, "\"", 4410, 1);
#nullable restore
#line 124 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 4383, Model.Products[i].ImageAlt, 4383, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                                    <div class=\"card-body\">\n                                                        <h5 class=\"card-title\">");
#nullable restore
#line 126 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                          Write(Model.Products[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abdb72a6857616825199638bda5fd471f45000bf14648", async() => {
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
#line 127 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
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
            WriteLiteral("\n                                                        <a href=\"#\" class=\"btn btn-primary\">Přidat do košíku</a>\n                                                    </div>\n                                                </div>\n");
#nullable restore
#line 131 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\n                                    <div class=\"col\">\n");
#nullable restore
#line 135 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                          
                                            if (count > 1)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"card\">\n                                                    <img");
            BeginWriteAttribute("src", " src=\"", 5431, "\"", 5469, 1);
#nullable restore
#line 139 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 5437, Model.Products[i+1].ImageSource, 5437, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 5491, "\"", 5526, 1);
#nullable restore
#line 139 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 5497, Model.Products[i+1].ImageAlt, 5497, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                                    <div class=\"card-body\">\n                                                        <h5 class=\"card-title\">");
#nullable restore
#line 141 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                          Write(Model.Products[i + 1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                                        <a href=""#"" class=""btn btn-primary"">Detail</a>
                                                        <a href=""#"" class=""btn btn-primary"">Přidat do košíku</a>
                                                    </div>
                                                </div>
");
#nullable restore
#line 146 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\n                                    <div class=\"col\">\n");
#nullable restore
#line 150 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                           
                                            if (count > 2)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <div class=\"card\">\n                                                    <img");
            BeginWriteAttribute("src", " src=\"", 6504, "\"", 6542, 1);
#nullable restore
#line 154 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 6510, Model.Products[i+2].ImageSource, 6510, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\"");
            BeginWriteAttribute("alt", " alt=\"", 6564, "\"", 6599, 1);
#nullable restore
#line 154 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 6570, Model.Products[i+2].ImageAlt, 6570, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                                    <div class=\"card-body\">\n                                                        <h5 class=\"card-title\">");
#nullable restore
#line 156 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                                                          Write(Model.Products[i + 2].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                                                        <a href=""#"" class=""btn btn-primary"">Detail</a>
                                                        <a href=""#"" class=""btn btn-primary"">Přidat do košíku</a>
                                                    </div>
                                                </div>
");
#nullable restore
#line 161 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"
                                            } 
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\n                                </div>\n");
#nullable restore
#line 165 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"

                            }
                        
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n");
#nullable restore
#line 171 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Index.cshtml"



        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
