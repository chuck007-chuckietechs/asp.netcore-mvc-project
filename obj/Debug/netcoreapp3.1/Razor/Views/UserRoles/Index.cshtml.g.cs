#pragma checksum "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71ee807b8e7364309616462a61ddb8e7d60c3721"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserRoles_Index), @"mvc.1.0.view", @"/Views/UserRoles/Index.cshtml")]
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
#line 1 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\_ViewImports.cshtml"
using NBDPrototype;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\_ViewImports.cshtml"
using NBDPrototype.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ee807b8e7364309616462a61ddb8e7d60c3721", @"/Views/UserRoles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b8557de5cf844b03e9fc6a8cb069caeb5f31569", @"/Views/_ViewImports.cshtml")]
    public class Views_UserRoles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NBDPrototype.ViewModels.UserVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container row p-0 m-0\">\r\n    <div class=\"col-10 px-sm-0 m-0\">\r\n        <h1 class=\"text-muted\">User Roles</h1>\r\n        <br />\r\n    </div>\r\n        <table class=\"table\">\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 14 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 17 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.userRoles));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 26 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 29 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
                          
                            foreach (var r in item.userRoles)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            WriteLiteral("  ");
#nullable restore
#line 32 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
                               Write(r);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 33 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td >\r\n                        ");
#nullable restore
#line 37 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-success btn-sm text-white" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 41 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\UserRoles\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NBDPrototype.ViewModels.UserVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
