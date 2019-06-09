using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace test2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var db1 = services.GetRequiredService<CodeContext>();
                    db1.Database.EnsureCreated();

                    var db2 = services.GetRequiredService<KeyWordContext>();
                    db2.Database.EnsureCreated();

                    var db3 = services.GetRequiredService<StoryboardContext>();
                    db3.Database.EnsureCreated();

                    var db4 = services.GetRequiredService<WorkflowContext>();
                    db4.Database.EnsureCreated();

                    var db5 = services.GetRequiredService<ProjectContext>();
                    db5.Database.EnsureCreated();
                    var db6 = services.GetRequiredService<QuizContext>();
                    db5.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");

                }
            }
            

        host.Run();
}
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
