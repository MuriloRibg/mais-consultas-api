using System.Text;
using System.Text.Json.Serialization;
using mais_consultas_api.Data;
using mais_consultas_api.Models.Options;
using mais_consultas_api.Profiles;
using mais_consultas_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Injetando o AutoMapper
builder.Services.AddAutoMapper(typeof(ProviderProfile));

// Importando as configurações de Token JWT.
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

// Adicionando configurações de autenticação via JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer((options) =>
{
    var jwtIssuer = builder.Configuration["Jwt:Issuer"];
    var jwtAudience = builder.Configuration["Jwt:Audience"];
    var jwtKey = builder.Configuration["Jwt:Key"];
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// Add services to the container.

builder.Services.AddControllers(options =>
{
    // Aplica autenticação por padrão à todos os Endpoints.
    var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mais.Consultas.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        },
        Scheme = "Bearer",
        Name = "Bearer",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });

});
builder.Services.AddCors();

string? connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString,
        ServerVersion.Parse("8.0.28-mysql")
    ));

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProviderService>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
    c.WithOrigins("*")
        .WithMethods("PUT", "DELETE", "GET", "POST")
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();