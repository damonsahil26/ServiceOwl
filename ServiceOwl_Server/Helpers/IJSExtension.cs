using Microsoft.JSInterop;

namespace ServiceOwl_Server.Helpers
{
    public static class IJSExtension
    {
        public static async ValueTask ShowToastr(this IJSRuntime JSRuntime, string type, string message)
        {
            await JSRuntime.InvokeVoidAsync("showToastr", type, message);
        }
    }
}
