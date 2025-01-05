using AppAngular.Server.Context;
using AppAngular.Server.Repositorio;
using AppAngular.Server.RepositorioImp;
using AppAngular.Server.Servicio;
using AppAngular.Server.ServicioImp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//configurar la base de datos. 

builder.Services.AddDbContext<SirmDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//configurar  tokens
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings.GetValue<string>("SecretKey");

//Midelware
builder.Services.
    AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, //Verifica que el token proviene de un emisor confiable.
            ValidateAudience = true, //Verifica que el token sea para un publico adecuado. 
            ValidateLifetime = true, //Asegura que el token no esta vencido. 
            ValidateIssuerSigningKey = true, //Verifica que la firma del token sea válida. 
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"), //Especifica el emisor válido para los tokens
            ValidAudience = jwtSettings.GetValue<string>("Audience"), //Especifica el público válido para los tokens
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // Especifica la llave secreta.
        };
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicio que se cargará, en tiempo de ejecución...
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
