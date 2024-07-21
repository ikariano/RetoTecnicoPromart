using Aplicacion.Contexto;
using Aplicacion.Repositorios;
using Aplicacion.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conexionSQL = builder.Configuration.GetConnectionString("Conexion");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AplicacionContext>(options => {
    options.UseSqlServer(conexionSQL, b => b.MigrationsAssembly("ClientesAPI"));
});
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
