global using Microsoft.EntityFrameworkCore;
using ProjetoCRM.API.Services.ClientesService;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Models;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Super Hero API", Version = "v1" });
});

// Builde para registrar o automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Builder para registrar o cliente de serviços no programa
builder.Services.AddScoped<IClientesService, ClientesService>();

//Builder para conexão do SQL com plataforma azure

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));


var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}
//Caso o ambiente não seja de desenvolvimento, retira o prefixo da rota (/swagger), para poder acessar o swagger diretamente na página da API
else
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Super Hero API V1");
        c.RoutePrefix = string.Empty;
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
