using System.Text.Json.Serialization;
using EcommerceApi.Controllers;
using EcommerceApi.Data;
using EcommerceApi.service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configure controllers
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//configure db contexts
builder.Services.AddDbContext<ProductContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProductService>();

var app = builder.Build();

app.MapControllers();

app.Run();
