#pragma checksum "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d620356c65c91941077141d7ae859d4da0ee86e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_DanhGiaKhachHangs_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/DanhGiaKhachHangs/Index.cshtml")]
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
#line 1 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\_ViewImports.cshtml"
using _0306191062_vohoangphuc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\_ViewImports.cshtml"
using _0306191062_vohoangphuc.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d620356c65c91941077141d7ae859d4da0ee86e5", @"/Areas/Admin/Views/DanhGiaKhachHangs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cce5e83527bee649ef741b012d75e3d0cc697a9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_DanhGiaKhachHangs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<_0306191062_vohoangphuc.Areas.Admin.Models.DanhGiaKhachHang>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:90;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-lg-12 grid-margin stretch-card\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <h4 class=\"card-title\">Nhận xét của khách hàng </h4>\r\n");
            WriteLiteral("            <div class=\"table-responsive\">\r\n                <table class=\"table table-striped\">\r\n                    <thead>\r\n                        <tr>\r\n                            <th>\r\n                                ");
#nullable restore
#line 20 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TaiKhoan.HinhAnh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 23 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TaiKhoan.HoVaTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 26 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.LoiDanhGia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
#nullable restore
#line 29 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 35 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"py-1\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d620356c65c91941077141d7ae859d4da0ee86e57733", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1609, "~/admin/assets/images/users/", 1609, 28, true);
#nullable restore
#line 39 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
AddHtmlAttributeValue("", 1637, item.TaiKhoan.HinhAnh, 1637, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 42 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.TaiKhoan.HoVaTen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 45 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.LoiDanhGia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 49 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                                 if(item.TrangThai == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <b class=\"btn btn-success btn-rounded\" style=\"width:90;\">Đã duyệt</b>\r\n");
#nullable restore
#line 52 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                                }
                                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <b class=\"btn btn-danger btn-rounded\" style=\"width:110;\">Chưa duyệt</b>\r\n");
#nullable restore
#line 56 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n");
            WriteLiteral("                                <a class=\"btn btn-success btn-rounded\"");
            BeginWriteAttribute("iddanhgia", " iddanhgia =\"", 2920, "\"", 2941, 1);
#nullable restore
#line 60 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
WriteAttributeValue("", 2933, item.Id, 2933, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"btn_duyet\" style=\"width:90;\" >Duyệt</a>\r\n");
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d620356c65c91941077141d7ae859d4da0ee86e512013", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                                                                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 65 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n$(\'#btn_duyet\').click(function() {\r\n\r\n        var id = $(\'#btn_duyet\').attr(\'iddanhgia\');\r\n        //alert(id);\r\n\r\n        $.ajax({\r\n                method: \"post\",\r\n                url: \"");
#nullable restore
#line 83 "F:\0306191062_vohoangphuc\0306191062_vohoangphuc\Areas\Admin\Views\DanhGiaKhachHangs\Index.cshtml"
                  Write((Context.Request.IsHttps?"https://":"http://")+Context.Request.Host+"/api/apidanhgiakhachhang/duyetdanhgia/");

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + id\r\n            }).done(function (msg) {\r\n                alert(msg);\r\n                location.reload();\r\n\r\n        });\r\n});    \r\n    \r\n    </script>\r\n \r\n");
            }
            );
            WriteLiteral("\r\n        \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<_0306191062_vohoangphuc.Areas.Admin.Models.DanhGiaKhachHang>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
