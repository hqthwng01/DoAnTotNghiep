#pragma checksum "D:\DA_TOTNGHIEP\Areas\Admin\Views\ProductTypes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46728293281a1b909adeb4535a48d0efb6730e82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductTypes_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductTypes/Index.cshtml")]
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
#line 1 "D:\DA_TOTNGHIEP\Areas\Admin\Views\_ViewImports.cshtml"
using DA_TOTNGHIEP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DA_TOTNGHIEP\Areas\Admin\Views\_ViewImports.cshtml"
using DA_TOTNGHIEP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46728293281a1b909adeb4535a48d0efb6730e82", @"/Areas/Admin/Views/ProductTypes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69eb05b105e90de7f973b2b4fc25a1aaa61369ec", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_ProductTypes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DA_TOTNGHIEP.Models.ProductTypes>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DA_TOTNGHIEP\Areas\Admin\Views\ProductTypes\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"view-all\">\r\n    ");
#nullable restore
#line 9 "D:\DA_TOTNGHIEP\Areas\Admin\Views\ProductTypes\Index.cshtml"
Write(await Html.PartialAsync("_ViewAll", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 13 "D:\DA_TOTNGHIEP\Areas\Admin\Views\ProductTypes\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DA_TOTNGHIEP.Models.ProductTypes>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591