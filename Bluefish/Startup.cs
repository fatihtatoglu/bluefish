namespace Bluefish
{
    using System;
    using System.Net;
    using System.Net.Sockets;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Extensions;
    
    public class Startup
    {
        public void Configure(IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<!DOCTYPE html><html lang=\"en\"><head><title>" + $"{Environment.MachineName}" + "</title></head><body>");
                await context.Response.WriteAsync("<p><b>MachineName</b>: " + $"{Environment.MachineName}" + "</p>");
                await context.Response.WriteAsync("<p><b>OS</b>: " + $"{Environment.OSVersion}" + "</p>");

                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                await context.Response.WriteAsync("<p><b>Hostname</b>: " + $"{host.HostName}" + "</p>");

                await context.Response.WriteAsync("<b>IP Addresses</b><ul>");
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        await context.Response.WriteAsync("<li>" + $"{ip}" + "</li>");
                    }
                }
                await context.Response.WriteAsync("</ul>");

                await context.Response.WriteAsync("<p><b>Request URL</b>: " + $"{context.Request.GetDisplayUrl()}<p>");
                await context.Response.WriteAsync("</body></html>");
            });
        }
    }
}