using mais_consultas_api.Data;
using mais_consultas_api.Services;
using mais_consultas_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

string? connectionString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString,
    ServerVersion.Parse("8.0.28-mysql")
));

builder.Services.AddScoped<IProfessionalService, ProfessionalService>();

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
