#pragma checksum "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b98168d100130f4afa7a0560edd217da1c7e6fad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Chat), @"mvc.1.0.view", @"/Views/Shared/_Chat.cshtml")]
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
#line 1 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/_ViewImports.cshtml"
using General_Quarters;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/_ViewImports.cshtml"
using General_Quarters.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b98168d100130f4afa7a0560edd217da1c7e6fad", @"/Views/Shared/_Chat.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe2919fbb15a473af766f3abeec95287ee17c386", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Chat : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chat.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml"
  
    ViewData["Title"] = "General Quarters Home";
    string username = Context.Session.GetString("UserName");
    string userId = Context.Session.GetInt32("UserId").ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-12 bg-light border rounded shadow p-0 mr-3"">
    <h3 class=""text-center my-2"">Game Chat</h3>
    <div class=""col-12""><hr /></div>
    <div class=""col-12"">
        <div id=""messageBox"" class=""col-12 form-control border overflow-auto mb-3"" style=""height: 200px;"">
            <h6 id=""messagesList""></h6>
        </div>
        <div class=""col-12""><hr /></div>
        <input type=""hidden"" id=""join-group"" class=""btn btn-link"" value=""Join Group"" />
        <input type=""hidden"" id=""leave-group"" class=""btn btn-link"" value=""Leave Group"" />
        <textarea placeholder=""Enter a message..."" id=""group-message-text"" class=""form-control mb-3""></textarea>
        <input type=""hidden""");
            BeginWriteAttribute("value", " value=\"", 888, "\"", 907, 2);
            WriteAttributeValue("", 896, "Game", 896, 4, true);
#nullable restore
#line 20 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml"
WriteAttributeValue(" ", 900, Model, 901, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"group-name\" id=\"group-name\">\n        <input disabled type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 981, "\"", 1000, 2);
            WriteAttributeValue("", 989, "Game", 989, 4, true);
#nullable restore
#line 21 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml"
WriteAttributeValue(" ", 993, Model, 994, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"group-name\" id=\"auto-join\">\n        <input disabled id=\"userInput\" class=\"no-outline no-no-outline bg-white d-none\"");
            BeginWriteAttribute("value", " value=\"", 1123, "\"", 1140, 1);
#nullable restore
#line 22 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml"
WriteAttributeValue("", 1131, username, 1131, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\n        <input disabled id=\"userIdentification\" class=\"no-outline no-no-outline bg-white d-none\"");
            BeginWriteAttribute("value", " value=\"", 1240, "\"", 1255, 1);
#nullable restore
#line 23 "/Users/sparerecords/Development/2_codingDojoAssingments/C#_stack/General-Quarters/Views/Shared/_Chat.cshtml"
WriteAttributeValue("", 1248, userId, 1248, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\n        <input type=\"button\" id=\"groupmsg\" class=\"btn-primary mb-3 form-control\" value=\"Send to Group\" />\n    </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b98168d100130f4afa7a0560edd217da1c7e6fad7283", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b98168d100130f4afa7a0560edd217da1c7e6fad8306", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n<script>\n    var messageBody = document.querySelector(\'#messageBody\');\n    messageBody.scrollTop = messageBody.scrollHeight - messageBody.clientHeight;\n</script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
