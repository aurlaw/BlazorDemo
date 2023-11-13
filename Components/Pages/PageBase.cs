using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDemo.Components.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime {get;set;}
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("applyDefaultTheme");

            await base.OnAfterRenderAsync(firstRender); 
        }

    }
}
