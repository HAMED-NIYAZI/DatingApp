using Data.Context;
using DatingApp.Api.Extensions;
using DatingApp.Api.Services.Implementation;
using DatingApp.Api.Services.Interface;
using IOC.Dependencies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//اضافه کردن سرویس ها

builder.Services.RegisterServices();
builder.Services.AddApplicationService(builder.Configuration);






// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()//addresses that can call this apis   .AllowAnyOrigin("http://site:5466")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
//builder.Services.AddCors();
// End Of Add Cors



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region add jwt AddAuthentication

builder.Services.AddIdentityService(builder.Configuration);

#endregion add jwt AddAuthentication


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




//Add Authentication
app.UseAuthentication();

app.UseAuthorization();

// Enable Cors
app.UseCors("MyPolicy");
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:7235/"));


app.MapControllers();

app.Run();
