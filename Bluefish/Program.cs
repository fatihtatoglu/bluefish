namespace Bluefish
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            IWebHost webHost = webHostBuilder
                              .UseKestrel()
                              .UseStartup<Startup>()
                              .Build();

            webHost.Run();
        }
    }
}