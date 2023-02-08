﻿using Data.Context;
using DatingApp.Api.Services.Implementation;
using DatingApp.Api.Services.Interface;
using IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//اضافه کردن کانتکست
builder.Services.AddDbContext<DatingAppContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatingAppConnectionString"));
});

//اضافه کردن سرویس ها
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.RegisterServices();



// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
//builder.Services.AddCors();
// End Of Add Cors




builder.Services.AddControllers();
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

// Enable Cors
app.UseCors("MyPolicy");
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7235/"));


app.MapControllers();

app.Run();
