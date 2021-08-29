using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using WebApiPsychic.Middleware;

namespace WebApiPsychic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // для работы с сессиями
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = false;
            });


            services.AddApplication();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApiPsychic",
                    Description = "A sample ASP.NET Core Web API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Sergei Zakharov",
                        Email = "sergeizahargood@gmail.com",
                        Url = new Uri("https://www.instagram.com/sergeizahargood_gmail_com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MY License",
                        Url = new Uri("https://www.instagram.com/")
                    },

                });

                // генерация документации
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
            /*services.AddCors(option =>
            {
                option.AddPolicy("allowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowCredentials();
                });
            });*/
            services.AddCors();
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.

                //Here comes the change:
                options.CheckConsentNeeded = context => false;
                //options.MinimumSameSitePolicy = SameSiteMode.None;
            });*/
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiPsychic v1"));
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseCors("AllowAll");
            app.UseCors(builder => builder
            .WithOrigins("https://localhost:4200")
            //.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            //.SetIsOriginAllowed(origin => true)
            //.WithExposedHeaders("Access-Control-Allow-Origin")
            );
            app.UseAuthorization();
            app.UseSession();   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
