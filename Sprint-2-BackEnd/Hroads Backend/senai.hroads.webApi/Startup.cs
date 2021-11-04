using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.hroads.webApi_
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
             .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
              });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "hroads.webApi"

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os parâmetros de validação do token
                .AddJwtBearer("JwtBearer", options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida quem está emitindo o token
                        ValidateIssuer = true,

                        // Valida quem está recebendo o token
                        ValidateAudience = true,

                        // Valida o tempo de expiração do token
                        ValidateLifetime = true,

                        // Definindo a chave (frase) de segurança
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticar")),

                        // Tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Define o nome do issuer, ou seja, quem emite o token
                        ValidIssuer = "hroads.webApi",

                        // Define o nome do audience, ou seja, quem recebe o token
                        ValidAudience = "hroads.webApi"
                    };
                });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "hroads.webApi");
                c.RoutePrefix = string.Empty;
            });


            
            app.UseAuthentication();      
            
            app.UseAuthorization();         

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
            });
        }
    }
}
