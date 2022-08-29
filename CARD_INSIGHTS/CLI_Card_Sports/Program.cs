using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APICard_Sports;
using APICard_Sports.Context;
using CLI_Card_Sports;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;



namespace CLI_Card_Sports
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();



            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            //executar leitura csv
            var db = new DataContext();
            var execute = new Exportador(db);
            execute.Export();
            Console.WriteLine("Teste");

            //app.Run();



        }
    }
}

