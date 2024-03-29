#pragma checksum "C:\Development\Git\MapaCovid\src\Api\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8feb70ef28638fd036bca59ee30cd52f3b7c0cb8"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8feb70ef28638fd036bca59ee30cd52f3b7c0cb8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3bf9ec3e3a6770c21a7839930b59c9c6f06f06b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Api.Models.IndexModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Development\Git\MapaCovid\src\Api\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script src=""https://polyfill.io/v3/polyfill.min.js?features=default""></script>
<script type=""text/javascript"" src=""https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js""></script>
<script
  src=""https://code.jquery.com/jquery-2.2.4.js""
  integrity=""sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI=""
  crossorigin=""anonymous""></script>
<script src=""/maps/locations.json""></script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8feb70ef28638fd036bca59ee30cd52f3b7c0cb83706", async() => {
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
            WriteLiteral(@"
<script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyCkMNthxGt3NRFc-QVIoYc8rDi3QjC3fcw&callback=initMap&libraries=&v=weekly"" async defer></script>
<script>
    window.handleTickerChanged = (symbol, price) => {
        return 'Done!';
    };
</script>
<script>
    let marker = [];
</script>


<style>
    html, body, h1, h2, h3, h4, h5 {
        font-family: ""Raleway"", sans-serif
    }
</style>
<style type=""text/css"">
    /* Always set the map height explicitly to define the size of the div
        * element that contains the map. */
    #map {
        height: 100%;
    }
    /* Optional: Makes the sample page fill the window. */
    html,
    .leftside-div {
        text-align: center;
        margin-left: auto;
        margin-right: 0;
        display: block;
    }

    body {
        height: 100%;
        margin: 0;
        padding: 0;
    }
</style>
<!-- Sidebar/menu -->
<nav class=""w3-sidebar w3-collapse w3-white w3-animate-left"" style=""z-index:3; width:200");
            WriteLiteral(@"px; position:fixed"" id=""mySidebar""><br>
  <hr>
  <div class=""w3-container"">
    <h5>Dashboard</h5>
  </div>
  <div class=""w3-bar-block"">
    <a href=""#"" class=""w3-bar-item w3-button w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black"" onclick=""w3_close()"" title=""close menu""><i class=""fa fa-remove fa-fw""></i>  Close Menu</a>
    <a href=""/Home"" class=""w3-bar-item w3-button w3-padding w3-blue""><i class=""fa fa-users fa-fw""></i>  Overview</a>
    <a href=""#"" class=""w3-bar-item w3-button w3-padding""><i class=""fa fa-eye fa-fw""></i>  Infectados</a>
    <a href=""#"" class=""w3-bar-item w3-button w3-padding""><i class=""fa fa-eye fa-fw""></i>  Vacinados</a>
    <a href=""/Cadastrar"" class=""w3-bar-item w3-button w3-padding""><i class=""fa fa-users fa-fw""></i>  Cadastramento</a><br><br>
  </div>
</nav>
<div class=""w3-overlay w3-hide-large w3-animate-opacity"" onclick=""w3_close()"" style=""cursor:pointer"" title=""close side menu"" id=""myOverlay""></div>
<div class=""w3-main"" style=""margin-left:200px;margin-top:10px;"">");
            WriteLiteral(@"

    <!-- Header -->
    <header class=""w3-container"" style=""padding-top:10px"">
        <h3><b><i class=""fa fa-dashboard""></i>  Dashboard</b></h3>
    </header>
    <hr>
    <div class=""w3-row-padding w3-margin-bottom"">
        <div style=""width: 440px; height: 112px;"" class=""w3-quarter "">
            <div class=""w3-container w3-red w3-padding-16"">
                <div class=""w3-left""><i class=""fa fa-users w3-xxxlarge""></i></div>
                <div class=""w3-right"">
                    <h3>");
#nullable restore
#line 78 "C:\Development\Git\MapaCovid\src\Api\Views\Home\Index.cshtml"
                   Write(Model._numeroInfectados);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
                <div class=""w3-clear""></div>
                <h4>Infectados</h4>
            </div>
        </div>
        <div style=""width: 440px; height: 112px;"" class=""w3-quarter"">
            <div class=""w3-container w3-blue w3-padding-16"">
                <div class=""w3-left""><i class=""fa fa-users w3-xxxlarge""></i></div>
                <div class=""w3-right"">
                    <h3>");
#nullable restore
#line 88 "C:\Development\Git\MapaCovid\src\Api\Views\Home\Index.cshtml"
                   Write(Model._numeroVacinados);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
                <div class=""w3-clear""></div>
                <h4>Vacinados</h4>
            </div>
        </div>
        <div style=""width: 440px; height: 112px;"" class=""w3-quarter"">
            <div class=""w3-container w3-orange w3-text-white w3-padding-16"">
                <div class=""w3-left""><i class=""fa fa-share-alt w3-xxxlarge""></i></div>
                <div class=""w3-right"">
                    <h3>");
#nullable restore
#line 98 "C:\Development\Git\MapaCovid\src\Api\Views\Home\Index.cshtml"
                   Write(Model._totalContabilizados);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                </div>
                <div class=""w3-clear""></div>
                <h4>Total de Contabilizados</h4>
            </div>
        </div>
    </div>
    <hr>
    <div class=""w3-panel"">
        <div class=""w3-row-padding"" style=""margin:0 -16px"">
            <div class=""w3-twothird"" style=""width: 900px; height: 400px;"">
                <!-- Mapa -->
                
                <div id=""map""></div>
                
            </div>
            <div class=""w3-third"" style=""height: 300px;"">
                <!-- Feeds -->
            </div>
        </div>
    </div>
    <hr>
    <!-- End page content -->
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Api.Models.IndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
