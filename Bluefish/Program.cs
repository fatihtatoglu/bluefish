namespace Bluefish
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(args);
            webHostBuilder.UseStartup<Startup>();
            webHostBuilder.UseKestrel(opt =>
            {
                opt.ListenAnyIP(5000);
            });

            return webHostBuilder;
        }
    }
}