#pragma checksum "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a24c789958aba0be3ac88bee1e504e2683c42946"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail), @"mvc.1.0.view", @"/Views/Home/Detail.cshtml")]
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
#nullable restore
#line 1 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
using Musilu.Eshop.Web.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a24c789958aba0be3ac88bee1e504e2683c42946", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2e4d0d72da0729318202da85a62ca64617df9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<section class=\"py-5\">\r\n    <div class=\"container px-4 px-lg-5 my-5\">\r\n        <div class=\"row gx-4 gx-lg-5 align-items-center\">\r\n            <div class=\"col-md-6\"><img class=\"card-img-top mb-5 mb-md-0\"");
            BeginWriteAttribute("src", " src=\"", 263, "\"", 287, 1);
#nullable restore
#line 9 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
WriteAttributeValue("", 269, Model.ImageSource, 269, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\" /></div>\r\n            <div class=\"col-md-6\">\r\n                <div class=\"small mb-1\">Kategorie: ");
#nullable restore
#line 11 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
                                              Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <h1 class=\"display-5 fw-bolder\">");
#nullable restore
#line 12 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <div class=\"fs-5 mb-5\">\r\n                    <span>");
#nullable restore
#line 14 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
                     Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kč</span>\r\n                </div>\r\n                <p class=\"lead\">");
#nullable restore
#line 16 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Views\Home\Detail.cshtml"
                           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                <div class=""d-flex"">
                    <input class=""form-control text-center me-3"" id=""inputQuantity"" type=""num"" value=""1"" style=""max-width: 3rem"" />
                    <button class=""btn btn-outline-dark flex-shrink-0"" type=""button"">
                        <i class=""bi-cart-fill me-1""></i>
                        Add to cart
                    </button>
                </div>
            </div>
        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591