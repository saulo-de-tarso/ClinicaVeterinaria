global using Microsoft.EntityFrameworkCore;
using ProjetoCRM.API.Services.ClientService;
using ProjetoCRM.API.Data;
using ProjetoCRM.API.Models;
using System;
using ProjetoCRM.API.Services.PetService;
using ProjetoCRM.API.Services.AppointmentService;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Super Hero API", Version = "v1" });
});

// Builder to register automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Builder to register the clients service
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//Builder to connect to the SQL server instance

builder.Services.AddDbContext<DataContext>(options =>
    options
        .UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"))
        .LogTo(Console.WriteLine, LogLevel.Information)
    );


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();

//if (app.environment.isdevelopment())
//{
    
//}
////if enviroment is not development, removes the route prefix (/swagger), for direct access to swagger from the api home page
//else
//{
//    app.useswaggerui(c =>
//    {
//        c.swaggerendpoint("/swagger/v1/swagger.json", "super hero api v1");
//        c.routeprefix = string.empty;
//    });
//}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
