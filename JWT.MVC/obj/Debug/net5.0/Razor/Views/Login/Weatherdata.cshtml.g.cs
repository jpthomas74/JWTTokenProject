#pragma checksum "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "874de968bf6d94dd02366e3b786462b705b3cdcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Weatherdata), @"mvc.1.0.view", @"/Views/Login/Weatherdata.cshtml")]
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
#line 1 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\_ViewImports.cshtml"
using JWT.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\_ViewImports.cshtml"
using JWT.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"874de968bf6d94dd02366e3b786462b705b3cdcb", @"/Views/Login/Weatherdata.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55ae5b4850db917f6b0f8fbecf7aff50b39ee4d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Weatherdata : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<JWT.MVC.Models.WeatherForecast>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
 if (Model != null && Model.Count() > 0)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 11 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayNameFor(model => model.TemperatureC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayNameFor(model => model.TemperatureF));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayNameFor(model => model.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 30 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayFor(modelItem => item.TemperatureC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayFor(modelItem => item.TemperatureF));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(Html.DisplayFor(modelItem => item.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n         </tr>\r\n");
#nullable restore
#line 42 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 46 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Error : ");
#nullable restore
#line 49 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
           Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 50 "D:\MyData\OneDrive\Development\2021\OASYSSAP\JWT.MVC\Views\Login\Weatherdata.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<JWT.MVC.Models.WeatherForecast>> Html { get; private set; }
    }
}
#pragma warning restore 1591
