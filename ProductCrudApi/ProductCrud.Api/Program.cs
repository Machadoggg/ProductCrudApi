using Microsoft.EntityFrameworkCore;
using ProductCrud.App.Services;
using ProductCrud.Core.Interfaces;
using ProductCrud.Infra.Data;
using ProductCrud.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure SQL Server
IServiceCollection serviceCollection = builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services dependency inyection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

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

app.MapControllers();

app.Run();
