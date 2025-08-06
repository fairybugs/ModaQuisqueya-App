using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModaQuisqueya.Application.Contract;
using ModaQuisqueya.Application.Services;
using ModaQuisqueya.Infrastructure.Contexto;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Repositorios;
using ModaQuisqueya.Infrastructure.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModaQuisqueyaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IDiseñadorRepositorio, DiseñadorRepositorio>();
builder.Services.AddScoped<IOutfitRepositorio, OutfitRepositorio>();
builder.Services.AddScoped<ITiendaRepositorio, TiendaRepositorio>();
builder.Services.AddScoped<ITendenciaRepositorio, TendenciaRepositorio>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITiendaService, TiendaService>();
builder.Services.AddScoped<IDiseñadorService, DiseñadorService>();
builder.Services.AddScoped<IOutfitService, OutfitService>();
builder.Services.AddScoped<ITendenciaService, TendenciaService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
