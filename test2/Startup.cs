using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using WebAPI.Models;

namespace test2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });


            services.AddDbContext<ProjectContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Project")));
            services.AddDbContext<WorkflowContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Workflow")));
            services.AddDbContext<CodeContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<KeyWordContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("KEYWORDS")));
            services.AddDbContext<PaymentDetailContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<StoryboardContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Storyboard")));
            services.AddDbContext<QuizContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("Quiz")));
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "my API", Version = "v1" });
            });

       
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
