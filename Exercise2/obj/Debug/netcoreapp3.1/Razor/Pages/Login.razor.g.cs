#pragma checksum "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87934e69afea760a1d8be51eaa62af7c0c39c972"
// <auto-generated/>
#pragma warning disable 1591
namespace Exercise1.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Exercise2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\_Imports.razor"
using Exercise2.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
using Exercise1.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
using Exercise1.Data.Impl;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        ");
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "form-group");
                __builder2.AddAttribute(5, "style", "display: flex;justify-content: center");
                __builder2.AddMarkupContent(6, "\r\n            ");
                __builder2.AddMarkupContent(7, "<label>User name:</label>\r\n            ");
                __builder2.OpenElement(8, "input");
                __builder2.AddAttribute(9, "type", "text");
                __builder2.AddAttribute(10, "placeholder", "user name");
                __builder2.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 14 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
                                                                    _username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(12, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _username = __value, _username));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(13, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(14, "\r\n        ");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "form-group");
                __builder2.AddAttribute(17, "style", "display: flex;justify-content: center");
                __builder2.AddMarkupContent(18, "\r\n            ");
                __builder2.AddMarkupContent(19, "<label>Password</label>\r\n            ");
                __builder2.OpenElement(20, "input");
                __builder2.AddAttribute(21, "type", "password");
                __builder2.AddAttribute(22, "placeholder", "password");
                __builder2.AddAttribute(23, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 18 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
                                                                       _password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _password = __value, _password));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n        ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "style", "color: red;display: flex;justify-content: center");
                __builder2.AddContent(29, 
#nullable restore
#line 20 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
                                                                       _errorMessage

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n\r\n        ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "style", "display: flex;justify-content: center");
                __builder2.AddMarkupContent(33, "\r\n            ");
                __builder2.OpenElement(34, "button");
                __builder2.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
                              PerformLogin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(36, "Log In");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "D:\C#\DNP\AuthenticationAndAuthorization\Exercise2\Exercise2\Pages\Login.razor"
       
    private string _username;
    private string _password;
    private string _errorMessage;

    public async Task PerformLogin()
    {
        _errorMessage = "";
        try
        {
            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).ValidateLogin(_username, _password);
            _username = "";
            _password = "";
            NavigationManager.NavigateTo("/");
        }catch (Exception e)
        {
            _errorMessage = e.Message;
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserService UserService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
