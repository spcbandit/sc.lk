using System.Collections;
using System.Net.Mime;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using SC.LK.Application;
using SC.LK.Infrastructure.Api.Attributes;
using SC.LK.Infrastructure.Api.AuthSchemas;
using SC.LK.Infrastructure.ConfiguratorDispatcher;
using SC.LK.Infrastructure.Database;
using SC.LK.Infrastructure.ExternalConnector;
using SC.LK.Infrastructure.InternalConnector;
using SC.LK.Infrastructure.MailSender;
using SC.LK.Properties;
using NLog.Web;
using Org.BouncyCastle.Tls;
using SC.LK;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Infrastructure.Api;
using SC.LK.Infrastructure.Database.MethodsConfigurator;


var logger = NLogBuilder.ConfigureNLog("nlog.testing.config").GetCurrentClassLogger();
logger.Debug($"Starting sc.lk service {Assembly.GetExecutingAssembly().FullName}");
WebApplication app = null;
var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers(options =>
    {
        options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
        options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(
            new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            }));
    });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo {Title = "SC.LK - Server part personal spaces.", Version = "v1.0.1"});
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    });

// Слой основной бизнес логики
    builder.Services.AddApplication();
// Слой микросервиса базы данных
    builder.Services.AddInfrastructureDatabase(builder.Configuration);
    builder.Services.AddMethodConf(builder.Configuration);
// Слой микросервиса создание 
    builder.Services.AddInfrastructureConfiguratorDispatcher(); 
// Слой микросервиса внутренних соединений
    builder.Services.AddInfrastructureInternalConnectors(builder.Configuration);
// Слой микросервиса внешних соединений
    builder.Services.AddInfrastructureExternalConnectors(builder.Configuration);
// Слой микросервиса отправка письма
    builder.Services.AddInfrastructureMailSender(builder.Configuration);
    //builder.Services.AddCors();
// Слой микросервиса джоб
    //builder.Services.AddInfrastructureBackgroundService();
    

    //Слой схемы авторизации
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Resources.JWT_Issuer,
                ValidateAudience = true,
                ValidAudience = Resources.JWT_Audience,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Resources.JWT_Key)),
                ValidateIssuerSigningKey = true,
            };
        })
        .AddSchemasAuthenticate();
    builder.Services.AddSchemasAuthenticate();
    
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
    builder.Host.UseNLog();

    app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseMiddleware<Middleware>();
    
    app.UseMiddleware<ExceptionGlobalMiddleware>();
    // app.Use(async (context, next) =>
    // {
    //     context.Request.EnableBuffering();
    //     await next();
    // });
    
    //app.UseInfrastructureLoggerMiddleware();

    app.UseStaticFiles();
    app.UseHttpsRedirection();

    app.UseRouting();

    //app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSwagger();

    app.UseSwaggerUI();

    var res = app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScanCity.LK");
        c.RoutePrefix = string.Empty;
    });
    
app.Run();
