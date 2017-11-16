using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace RemoteDocumentProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cert = new X509Certificate2("cert.pfx", "1234");

            var host = new WebHostBuilder()
                .UseKestrel(options => 
                        options.Listen(IPAddress.Any, 4433, listenOptions => listenOptions.UseHttps(cert)))
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
