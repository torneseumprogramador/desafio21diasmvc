using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMVCRazor.Models;

namespace WebMVCRazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            new Cliente(){ Id = 1, Nome = "Danilo", Telefone = "123432123" }.Salvar();
            new Cliente(){ Id = 2, Nome = "Erivelton", Telefone = "54323432" }.Salvar();
            new Cliente(){ Id = 3, Nome = "Douglas", Telefone = "653223453" }.Salvar();
            new Cliente(){ Id = 4, Nome = "Miquéias", Telefone = "23456323" }.Salvar();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllerRoute(name: "aula",
                //     pattern: "/aula",
                //     defaults: new { controller = "Home", action = "Class" });

                // endpoints.MapControllerRoute(name: "privacidade",
                //     pattern: "/politica-de-privacidade",
                //     defaults: new { controller = "Home", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
