using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .ConfigureServices(services => services.AddMvc())
                .Configure(app => app.UseMvc())
                .UseUrls("http://localhost:33333")
                .Build()
                .Run();
        }
    }
}
