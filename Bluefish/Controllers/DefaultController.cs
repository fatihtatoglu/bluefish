namespace Bluefish.Controllers
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;

    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = new
            {
                Name = this.GetType().Name.Replace("Controller", "Api"),
                Server = Environment.MachineName,
                Timestamp = DateTime.UtcNow
            };

            return this.Json(data);
        }

        [HttpGet]
        public IActionResult Html()
        {
            StringBuilder builder = new StringBuilder(1024);
            builder.Append("<!doctype html>")
                   .Append("<html lang=\"en\">")
                   .Append("<head>")
                   .Append("<meta charset=\"utf-8\">")
                   .Append("<title>")
                   .Append(Environment.MachineName)
                   .Append("</title>")
                   .Append("<meta name=\"description\" content=\"Bluefish the simple docker image.\">")
                   .Append("<meta name=\"author\" content=\"Fatih Tatoğlu\">")
                   .Append("<style>")
                   .Append("*{ font-size: 12px; font-family: Tahoma; } p { line-height: 6px; }")
                   .Append("</style>")
                   .Append("</head>")
                   .Append("<body>");

            builder.Append("<h2>Environment</h2>")
                   .Append("<p><b>Machine Name:</b> ").Append(Environment.MachineName).Append("</p>")
                   .Append("<p><b>OS:</b> ").Append(Environment.OSVersion).Append("</p>")
                   .Append("<p><b>Hostname:</b> ").Append(Dns.GetHostName()).Append("</p>")
                   .Append("<p><b>Domain:</b> ").Append(Environment.UserDomainName).Append("</p>")
                   .Append("<p><b>Username:</b> ").Append(Environment.UserName).Append("</p>");

            builder.Append("<h3>IP Addresses</h3><ul>");

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                builder.Append("<li>").Append(ip).Append("</li>");
            }

            builder.Append("</ul>")
                   .Append("<h3>Environment Variables</h3><ul>");

            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                builder.AppendFormat("<li>{0} = {1}</li>", item.Key, item.Value);
            }

            builder.AppendLine("<h3>Drivers</h3>");
            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                if (!item.IsReady)
                {
                    continue;
                }

                builder.AppendFormat("<li>{4} ({0}) ({1:#,#} MB/{2:#,#} MB/{3:#,#} MB) {5}</li>", item.Name, item.TotalFreeSpace / 1000000, item.AvailableFreeSpace / 1000000, item.TotalSize / 1000000, item.VolumeLabel, item.DriveFormat);
            }

            builder.Append("</body>")
                   .Append("</html>");

            return this.Content(builder.ToString(), "text/html");
        }
    }
}