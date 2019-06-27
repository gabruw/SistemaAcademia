using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

namespace Smartgym
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // DB Connection
            var connectionString = Configuration.GetConnectionString("SmartgymDB");
            services.AddDbContext<SmartgymContext>(option =>
                                                            option.UseLazyLoadingProxies().UseMySql(connectionString,
                                                                m => m.MigrationsAssembly("Repository")));

            // Scope's
            services.AddScoped<Domain.Repository.IAgendaRepository, Repository.Repository.AgendaRepository>();
            services.AddScoped<Domain.Repository.IAlunoRepository, Repository.Repository.AlunoRepository>();
            services.AddScoped<Domain.Repository.IContaRepository, Repository.Repository.ContaRepository>();
            services.AddScoped<Domain.Repository.IAparelhoRepository, Repository.Repository.AparelhoRepository>();
            services.AddScoped<Domain.Repository.IEnderecoRepository, Repository.Repository.EnderecoRepository>();
            services.AddScoped<Domain.Repository.IAvaliacaoRepository, Repository.Repository.AvaliacaoRepository>();
            services.AddScoped<Domain.Repository.IExercicioRepository, Repository.Repository.ExercicioRepository>();
            services.AddScoped<Domain.Repository.IFichaRepository, Repository.Repository.FichaRepository>();
            services.AddScoped<Domain.Repository.IProfessorRepository, Repository.Repository.ProfessorRepository>();
            services.AddScoped<Domain.Repository.ISerieRepository, Repository.Repository.SerieRepository>();
            services.AddScoped<Domain.Repository.IUnidadeRepository, Repository.Repository.UnidadeRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseCookieAuthentication(options => {
            //    options.LoginPath = new PathString("");
            //    options.AccessDeniedPath = new PathString("");
            //    options.
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
