#pragma checksum "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8eb3b24924a101d468588acb012e492b0d3e008"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_CustomerOrders_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/CustomerOrders/Index.cshtml")]
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
#line 1 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\_ViewImports.cshtml"
using Musilu.Eshop.Web.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8eb3b24924a101d468588acb012e492b0d3e008", @"/Areas/Customer/Views/CustomerOrders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"115260f9b46bf4f546a52ccb345b851d74e50440", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_CustomerOrders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
  
    ViewData["Title"] = "My Orders";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>");
#nullable restore
#line 5 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>");
#nullable restore
#line 6 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<br />\r\n\r\n");
#nullable restore
#line 10 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
  
    if (Model != null && Model != null && Model.Count > 0)
    {
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <table style=\"width:100%\" class=\"table table-responsive table-striped table-bordered\">\r\n                <tr>\r\n                    <th class=\"col-sm-1\">");
#nullable restore
#line 17 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-2\">");
#nullable restore
#line 18 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.OrderNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
#nullable restore
#line 19 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
#nullable restore
#line 20 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.DateTimeCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th class=\"col-sm-3\">");
#nullable restore
#line 21 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(nameof(Order.User.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"col-sm-1\">");
#nullable restore
#line 24 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-2\">");
#nullable restore
#line 25 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.OrderNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-3\">");
#nullable restore
#line 26 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.TotalPrice.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-3\">");
#nullable restore
#line 27 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.DateTimeCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"col-sm-3\">");
#nullable restore
#line 28 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                    Write(item.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n\r\n            </table>\r\n");
            WriteLiteral("            <details>\r\n                <summary>Details</summary>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 1265, "\"", 1290, 2);
            WriteAttributeValue("", 1270, "order_items_", 1270, 12, true);
#nullable restore
#line 36 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
WriteAttributeValue("", 1282, item.ID, 1282, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <h4>Order Items</h4>\r\n                    <table style=\"width:41.667%\" class=\"table table-responsive table-bordered\">\r\n                        <tr>\r\n                            <th class=\"col-sm-3\">");
#nullable restore
#line 40 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                            Write(nameof(Product.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"col-sm-1\">");
#nullable restore
#line 41 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                            Write(nameof(OrderItem.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th class=\"col-sm-1\">");
#nullable restore
#line 42 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                            Write(nameof(OrderItem.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n\r\n");
#nullable restore
#line 45 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                          
                            foreach (var itemOrderItems in item.OrderItems)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"col-sm-3\">");
#nullable restore
#line 49 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                    Write(itemOrderItems.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"col-sm-1\">");
#nullable restore
#line 50 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                    Write(itemOrderItems.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"col-sm-1\">");
#nullable restore
#line 51 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                                                    Write(itemOrderItems.Price.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 53 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </table>\r\n                </div>\r\n            </details>\r\n            <br />\r\n            <br />\r\n            <br />\r\n");
#nullable restore
#line 61 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h2>Orders are empty!</h2>\r\n");
#nullable restore
#line 66 "D:\Program Files\VisualStudio\Musilu.Eshop.Web\Musilu.Eshop.Web\Musilu.Eshop.Web\Areas\Customer\Views\CustomerOrders\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
