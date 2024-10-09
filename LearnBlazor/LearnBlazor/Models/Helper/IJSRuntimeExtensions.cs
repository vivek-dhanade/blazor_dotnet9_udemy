using Microsoft.JSInterop;

namespace LearnBlazor.Models.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showToastr","success",message);
        }

        public static async Task ToastrError(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("showToastr","error",message);
        }

        //public static async Task SweetalertSuccess(this IJSRuntime jSRuntime, string message )
        //{
        //    await jSRuntime.InvokeVoidAsync("sweetAlert", "success", message); 
        //}

        //public static async Task SweetalertError(this IJSRuntime jSRuntime, string message)
        //{
        //    await  jSRuntime.InvokeVoidAsync("sweetAlert", "error", message );
        //}
    }

}
