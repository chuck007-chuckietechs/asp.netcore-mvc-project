#pragma checksum "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "177b384d4bcf2900f5124d2119fd583acc2e8faf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bids_Index), @"mvc.1.0.view", @"/Views/Bids/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"177b384d4bcf2900f5124d2119fd583acc2e8faf", @"/Views/Bids/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b8557de5cf844b03e9fc6a8cb069caeb5f31569", @"/Views/_ViewImports.cshtml")]
    public class Views_Bids_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBDPrototype.ViewModels.BidVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary form-control text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Create a new Bid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary btn-sm text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Preview project bids"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BidItems", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm text-white "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("View Bid Details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm text-white "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Edit a bid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
  
    ViewData["Title"] = "Bids";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n<div class=\"container row p-0 m-0\">\r\n    <div class=\"col-10 px-sm-0 m-0\">\r\n        <h1 class=\"text-muted\">Bid List</h1>\r\n        <br />\r\n    </div>\r\n");
#nullable restore
#line 19 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
     if (User.IsInRole("Manager") || User.IsInRole("Designer"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-2 px-sm-0 m-0\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "177b384d4bcf2900f5124d2119fd583acc2e8faf9265", async() => {
                WriteLiteral("\r\n                <i class=\"fas fa-plus\"></i>\r\n                Create New Bid\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 27 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
    }
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table"" id=""Exampledatatable"">
            <thead>
                <tr>
                    <th width=""80"">
                        Projects
                    </th>
                    <th width=""80px"">
                        Date
                    </th>
                    <th width=""80px"">
                        Start Date
                    </th>
                    <th width=""80px"">
                        Close Date
                    </th>
                    <th>
                        Amount
                    </th>
                    <th>
                        Status
                    </th>
                    <th>
                        Approved
                    </th>
                    
                    <th></th>
                    <th width=""200""></th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 64 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                 foreach (var item in Model.Bids)
                {
                    string selectedRow = "";
                    if (item.ID == (int?)ViewData["BidID"])
                    {
                        selectedRow = "table-success";
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("class", " class=\"", 2252, "\"", 2272, 1);
#nullable restore
#line 71 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
WriteAttributeValue("", 2260, selectedRow, 2260, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td>\r\n                            ");
#nullable restore
#line 73 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Projects.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 76 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 79 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 82 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ClosingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 85 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 88 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Statuses.BidStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 91 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IsApproved));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td></td>\r\n\r\n                        <td>\r\n");
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "177b384d4bcf2900f5124d2119fd583acc2e8faf15632", async() => {
                WriteLiteral("\r\n                                <i class=\"far fa-eye\"></i>\r\n                                Preview\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                    WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "177b384d4bcf2900f5124d2119fd583acc2e8faf18294", async() => {
                WriteLiteral("<i class=\"fas fa-info-circle\">Details</i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-BidId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 105 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                                                 WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["BidId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-BidId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["BidId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("tooltip-test\"", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 106 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                             if (User.IsInRole("Manager") || User.IsInRole("Designer"))
                            {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "177b384d4bcf2900f5124d2119fd583acc2e8faf21520", async() => {
                WriteLiteral("<i class=\"fas fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 107 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                    WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 107 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                                                                                                                                                                                  }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                    </tr>\r\n");
#nullable restore
#line 110 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n\r\n");
#nullable restore
#line 116 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
 if (Model.Items != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h2 class=""text-muted"">Staff and Materials for Selected Bid</h2>
    <table class=""table"">
        <tr>
            <th>Code</th>
            <th>Type</th>
            <th>Description</th>
            <th>Price</th>
            <th>Quantity</th>
        </tr>

");
#nullable restore
#line 128 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
         foreach (var item in Model.Items)
        {
            string selectedRow = "";
            if (item.ID == (int?)ViewData["ID"])
            {
                selectedRow = "success";
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 5024, "\"", 5044, 1);
#nullable restore
#line 135 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
WriteAttributeValue("", 5032, selectedRow, 5032, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 140 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 143 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ItemType.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 146 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 149 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 152 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                     foreach (var itemname in item.BidItems)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                   Write(itemname.BidItemQuantity);

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                 
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 158 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>Employee</th>\r\n            <th>Position</th>\r\n            <th>Markup</th>\r\n            <th>Est. Hours</th>\r\n            <th>Contact</th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 169 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
         foreach (var item in Model.Staffs)
        {
            string selectedRow = "";
            if (item.ID == (int?)ViewData["ID"])
            {
                selectedRow = "success";
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("class", " class=\"", 6233, "\"", 6253, 1);
#nullable restore
#line 176 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
WriteAttributeValue("", 6241, selectedRow, 6241, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 181 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(item.StaffFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 184 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Labour.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 187 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                     foreach (var itemname in item.BidStaffs)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 189 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                   Write(itemname.BidStaffMarkup);

#line default
#line hidden
#nullable disable
#nullable restore
#line 189 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                                                
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 193 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                     foreach (var itemname in item.BidStaffs)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 195 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                   Write(itemname.BidStaffTotalHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 196 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 199 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
               Write(item.StaffPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 202 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 204 "C:\Users\G751\Desktop\Chukwudi_Okechukwu_NBDPrototype_Project\Views\Bids\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/v/bs4/jq-3.3.1/dt-1.10.24/datatables.min.css"" />

    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/jq-3.3.1/dt-1.10.24/datatables.min.js""></script>

    <script>

        $(document).ready(function () {

            $('#Exampledatatable').DataTable({
                ""lengthMenu"": [[3, 5, 10, 25, - 1], [3, 5, 10, 25, ""All""]]
            });
        });

    </script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "177b384d4bcf2900f5124d2119fd583acc2e8faf33208", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBDPrototype.ViewModels.BidVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
