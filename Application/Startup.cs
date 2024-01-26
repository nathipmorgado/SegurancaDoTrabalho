﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SegurancaTrabalho.Domain.Service.Security;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using SegurancaTrabalho.Repository.Context;
using SegurancaTrabalho.DataAcessLayer.CrosCutting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;
using MySqlConnector;

namespace application
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
            ConfigureService.ConfigureDependenciesService(services);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfiguration = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new DtoToEntitylProfile());
            //    cfg.AddProfile(new EntityToDtoProfile());
            //});

            //IMapper mapper = config.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers();

            //NatyVitao --> criar uma para MYSQL (é o mesmo do curso ---> pesquisar)
            //var connectionString = "server=srm.mysql.database.azure.com;user=adm;database=seguranca_trabalho;port=3306;password=ER01jun21**";
            var connectionString = "Server=localhost;Port=3306;DataBase=dbNET5atualizado;Uid=root;Pwd=130519";
            services.AddDbContext<DataContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
            
            ////Oracle
            //services.AddDbContext<DataContext>(
            //    options => options.UseOracle(String.Format("User Id={0};Password={1};Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3})))(CONNECT_DATA =(SERVICE_NAME = {4})))", Configuration.GetValue<string>("Oracle:user"), Configuration.GetValue<string>("Oracle:senha"), Configuration.GetValue<string>("Oracle:Host"), Configuration.GetValue<string>("Oracle:Port"), Configuration.GetValue<string>("Oracle:ServiceName")))
            //);

            ////SqlServer
            //services.AddDbContext<DataContext>(
            //    options => options.UseSqlServer(String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", Configuration.GetValue<string>("SqlServer:DS"), Configuration.GetValue<string>("SqlServer:BD"), Configuration.GetValue<string>("SqlServer:USER"), Configuration.GetValue<string>("SqlServer:SENHA")))
            //);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Segurança do Trabalho",
                    Description = "Api Segurança do Trabalho",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                                  .WithOrigins("http://localhost:3000")
                                  .WithOrigins("http://localhost:8080")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("./swagger/v1/swagger.json", "CMM.Api");
            //    c.RoutePrefix = string.Empty;
            //});

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Segurançado Trabalho.Api");
                c.RoutePrefix = "swagger";
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}