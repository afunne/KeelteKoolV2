using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace KeelteKoolV2.xUnitTesting.Mock
{
    //Võlts keskkond testide jaoks, et teenused mis vajavad IHostEnvironment-i saaksid töötada
    public class MockIHostEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = "Testing";
        public string ApplicationName { get; set; } = "KeelteKoolV2.xUnitTesting";
        public string ContentRootPath { get; set; } = AppContext.BaseDirectory;
        public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
    }
}
