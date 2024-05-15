using mais_consultas_api.Data;
using mais_consultas_api.Profiles;
using mais_consultas_api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Injetando o AutoMapper
builder.Services.AddAutoMapper(typeof(ProviderProfile));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mais.Consultas.API", Version = "v1" });
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