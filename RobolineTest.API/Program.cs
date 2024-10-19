using Microsoft.EntityFrameworkCore;
using RobolineTest.Domain.Core;
using RobolineTest.Domain.Interfaces;
using RobolineTest.Infrastructure.Data;
using RobolineTestSevices;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
builder.Services.AddTransient<IRepository<ProductCategory>, CategoryRepository>();
builder.Services.AddTransient<ICrudService<Product>, ProductService>();
builder.Services.AddTransient<ICrudService<ProductCategory>, CategoryService>();
builder.Services.AddDbContext<ProductContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("Default")));
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

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
