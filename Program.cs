using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MongoApi.Data;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(builder.Configuration["JWT:KEY"]))
            ,ValidateIssuer = false,
            ValidateAudience = false

        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();//.RequireAuthorization();

app.Run();
