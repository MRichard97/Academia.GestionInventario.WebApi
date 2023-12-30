using Academia.GestionInventario.WebApi._Infrastructure;
using Academia.GestionInventario.WebApi.AppServices.Empleados;
using Academia.GestionInventario.WebApi.AppServices.Login;
using Academia.GestionInventario.WebApi.AppServices.Productos;
using Academia.GestionInventario.WebApi.AppServices.ProductosLotes;
using Academia.GestionInventario.WebApi.AppServices.SalidasInventarios;
using Academia.GestionInventario.WebApi.AppServices.Sucursales;
using Academia.GestionInventario.WebApi.AppServices.Usuarios;
using Academia.GestionInventario.WebApi.DomainServices.Empleados;
using Academia.GestionInventario.WebApi.DomainServices.Productos;
using Academia.GestionInventario.WebApi.DomainServices.ProductosLotes;
using Academia.GestionInventario.WebApi.DomainServices.SalidasInventarios;
using Academia.GestionInventario.WebApi.DomainServices.Sucursales;
using Academia.GestionInventario.WebApi.DomainServices.Usuarios;
using Academia.Transporte.WebApi._Infrastructure;
using Farsiman.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(op =>
{
    op.AddPolicy("AllowSpecificOrigin",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GestionInventarioDbContext>(db => db.UseSqlServer(
    builder.Configuration.GetConnectionString("GestionInventarioDb")
    ));

builder.Services.AddFsAuthService((op) =>
{
    op.Username = builder.Configuration.GetFromENV("FsIDentityServer:Username");
    op.Password = builder.Configuration.GetFromENV("FsIDentityServer:Password");
});

//Servicios de Aplicaciones
builder.Services.AddTransient<LoginAppService>();
builder.Services.AddTransient<SucursalAppServices>();
builder.Services.AddTransient<ProductoAppService>();
builder.Services.AddTransient<ProductoLoteAppService>();
builder.Services.AddTransient<SalidaInventrioAppService>();
builder.Services.AddTransient<UsuarioAppService>();
builder.Services.AddTransient<EmpleadoAppService>();
builder.Services.AddTransient<UnitOfWorkBuilder, UnitOfWorkBuilder>();

builder.Services.AddScoped<SalidaInventarioDomainService>();
builder.Services.AddScoped<SucursalDomainService>();
builder.Services.AddScoped<ProductoDomainService>();
builder.Services.AddScoped<EmpleadoDomainService>();
builder.Services.AddScoped<ProductoLoteDomainService>();
builder.Services.AddScoped<UsuarioDomainService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
