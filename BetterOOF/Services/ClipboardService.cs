using Microsoft.JSInterop;


//Code from: https://www.puresourcecode.com/dotnet/blazor/copy-to-clipboard-component-for-blazor/

namespace BetterOOF.Services
{  
        public class ClipboardService
        {
            private readonly Lazy<Task<IJSObjectReference>>? moduleTask;
            private readonly IJSRuntime jsRuntime;

            public ClipboardService(IJSRuntime jsRuntime)
            {
                this.jsRuntime = jsRuntime;
            }

            public ValueTask WriteTextAsync(string text)
            {
                return jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
            }
        }
    }
