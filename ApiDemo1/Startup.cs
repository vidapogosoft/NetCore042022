using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Services;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace ApiDemo1
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = "Demo Token ApiKey Exmaple";

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:12241", "http://localhost:12241/persona/listar",
                                          "http://localhost:12241/persona/crear", "http://localhost:12241/persona/actualizar")
                                      .AllowAnyOrigin()
                                      .AllowAnyHeader()
                                       .AllowAnyMethod();
                                  });
            });

            services.AddControllers();

            services
             .AddAuthentication(
             x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }
             )
             .AddJwtBearer(
              x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;

                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                      ValidateAudience = false,
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = false
                  };

              }
              );

            services.AddAuthorization();

            //Servicio verificador y creador de TOKEN JWT
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));

            //services.AddSingleton
            //services.AddTransient
            services.AddScoped<IPersonasGet, PersonaServicesGet>();
            services.AddScoped<IPiloto, PilotoServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            //llamo al middleware de la autenticacion
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
