using AppAngular.Server.Context;
using AppAngular.Server.Repositorio;
using AppAngular.Server.RepositorioImp;
using AppAngular.Server.Servicio;
using AppAngular.Server.ServicioImp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configurar la base de datos. 

builder.Services.AddDbContext<SirmDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicio que se cargará, cuando la aplicación arranque...
builder.Services.AddScoped<IRepositorioParametro, RepositorioParametroImp>();
builder.Services.AddScoped<IServicioParametro, ServicioParametroImp>();

builder.Services.AddScoped<IRepositorioCatalogo, RepositorioCatalogoImp>();
builder.Services.AddScoped<IServicioCatalogo,  ServicioCatalogoImp>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
