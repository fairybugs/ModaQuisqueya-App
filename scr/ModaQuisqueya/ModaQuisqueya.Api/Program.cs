using Microsoft.EntityFrameworkCore;
using ModaQuisqueya.Api.Data;
using ModaQuisqueya.Infrastructure.Interfaces;
using ModaQuisqueya.Infrastructure.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModaQuisqueyaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDiseñadorRepositorio, DiseñadorRepositorio>();
builder.Services.AddScoped<IOutfitRepositorio, OutfitRepositorio>();
builder.Services.AddScoped<ITiendaRepositorio, TiendaRepositorio>();
builder.Services.AddScoped<ITendenciaRepositorio, TendenciaRepositorio>();

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
