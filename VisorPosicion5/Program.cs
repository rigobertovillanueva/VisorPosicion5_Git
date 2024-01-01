using Microsoft.EntityFrameworkCore;
using VisorPosicion5.Models;
using VisorPosicion5.Services;
//Removing args is unlikely to affect the day-to-day running of most web applications,
//but it does reduce the configurability of your application via the command line.
var builder = WebApplication.CreateBuilder();


// Add services to the container.
builder.Services.AddDbContext<VisorPosicionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VisorPosicionConnection")));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOperacionesService, OperacionesService>();


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
