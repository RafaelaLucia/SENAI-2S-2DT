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

namespace senai_gufi_webAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddControllers() //adicionar controladores
              .AddNewtonsoftJson(options => {
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; //ignorar os loops
                   options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; //ignorar os valores nulos
               });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gufi_webAPI", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
             .AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = "JwtBearer";
                 options.DefaultChallengeScheme = "JwtBearer";
             })

             .AddJwtBearer("JwtBearer", options => //expressão lambida
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao")),
                     ClockSkew = TimeSpan.FromMinutes(30),
                     ValidIssuer = "gufi.webAPI",
                     ValidAudience = "gufi.webAPI"
                 };
             });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:3000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });
        }

     //   private void AddNewtonsoftJson(Action<object> p)
     //   {
     //       throw new NotImplementedException();
     //   }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gufi_webAPI");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
