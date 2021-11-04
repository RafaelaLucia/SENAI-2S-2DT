using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_movies_webapi
{
    public class Startup
    {
        public object AddjwtBerer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                Version = "v1",
                Title = "movies.webAPI",
                
            });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //definir a forma de autenticacao
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";

            })

            //define os parametros de validacao do token
            .AddJwtBearer("JwtBearer", options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //validar quem esta emitindo o token
                    ValidateIssuer = true,
                    //validar quem esta recebendo o token
                    ValidateAudience = true,
                    //validar o tempo de expiracao
                    ValidateLifetime = true,
                    //definindo a chave de seguranca
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),
                    //tempo de expiracao do token
                    ClockSkew = TimeSpan.FromMinutes(30),
                    //define o nome de quem emite o token (issue)
                    ValidIssuer = "movies.webAPI",
                    //define o nome de quem recebe o token (audience)
                    ValidAudience = "movies.webAPI"
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
            //aaaaaaaaa
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "movies.webAPI");
                c.RoutePrefix = string.Empty;
            });

            //habilita a autenticacao
            app.UseAuthentication();
            //habilita a autorizacao
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos controllers
                endpoints.MapControllers();

            });
        }
    }
}
