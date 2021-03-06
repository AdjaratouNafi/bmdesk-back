#pragma checksum "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6589a8f80c09caad8294e9223a047bfd26c33c31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Tooltip), @"mvc.1.0.view", @"/Views/Home/Tooltip.cshtml")]
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
#line 2 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
using BMSDesk_CLI_API.Web.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6589a8f80c09caad8294e9223a047bfd26c33c31", @"/Views/Home/Tooltip.cshtml")]
    public class Views_Home_Tooltip : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BMSDesk_CLI_API.Model.Tooltip_Model>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
 if (Model.ModuleType == "ticket")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"desctooltip\">\r\n        <div class=\"card-body p-0\">\r\n            <div class=\"form-box row\">\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 9 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblTicketID", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 11 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 15 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblCategory", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 17 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 21 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblStatus", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 23 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.StatusName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 27 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblSubject", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 29 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 33 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblDescription", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label overflow_chart\">\r\n                        ");
#nullable restore
#line 35 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 41 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
}
else if (Model.ModuleType == "solution")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"desctooltip\">\r\n        <div class=\"card-body p-0\">\r\n            <div class=\"form-box row\">\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 48 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblSolutionID", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 50 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 54 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblCategory", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 56 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 60 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblSubject", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label font-weight-bold\">\r\n                        ");
#nullable restore
#line 62 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Model.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12 form-group row mb-0\">\r\n                    <label class=\"col-sm-3 col-form-label\">");
#nullable restore
#line 66 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                                                      Write(HtmlHelpers.GlobalResources("lblSolution", Model.lang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                    <div class=\"col-sm-9 col-form-label overflow_chart\">\r\n                        ");
#nullable restore
#line 68 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
                   Write(Html.Raw(Model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 74 "/home/mo/github.com/nafi/bmdesk-back/Views/Home/Tooltip.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BMSDesk_CLI_API.Model.Tooltip_Model> Html { get; private set; }
    }
}
#pragma warning restore 1591
