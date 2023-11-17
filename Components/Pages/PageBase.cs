using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDemo.Tenants;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDemo.Components.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        public IJSRuntime? JsRuntime {get;set;}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (JsRuntime is not null)
            {
                await JsRuntime.InvokeVoidAsync("applyDefaultTheme");
            }

            await base.OnAfterRenderAsync(firstRender); 
        }

    }
}
