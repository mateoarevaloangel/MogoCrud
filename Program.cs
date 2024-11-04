using Microsoft.EntityFrameworkCore;
using MongoApi.Data;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer");

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseMongoDB(builder.Configuration.GetConnectionString("Cadena"), builder.Configuration.GetConnectionString("DataBase"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//.RequireAuthorization();

app.Run();
