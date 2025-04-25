using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Application.Mappings;
using BibliotecaApp.Application.Services;
using BibliotecaApp.Domain.Interfaces.Repositories;
using BibliotecaApp.Infrastructure.Data.Context;
using BibliotecaApp.Infrastructure.Repositories;
using BibliotecaApp.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Add services ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Add Cors ---
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --- DbContext ---
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- AutoMapper ---
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// --- Repositories ---
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<ITipoMaterialRepository, TipoMaterialRepository>();

// --- Services ---
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPrestamoService, PrestamoService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ITipoMaterialService, TipoMaterialService>();

// --- Middleware ---
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// --- Swagger solo en desarrollo ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- Middleware personalizado ---
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors(); // Activar CORS aquí
app.UseAuthorization();
app.MapControllers();
app.Run();
