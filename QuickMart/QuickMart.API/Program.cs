using Microsoft.EntityFrameworkCore;
using QuickMart.Infrastructure;
using QuickMart.Core.Repository;
using QuickMart.Core.Service;
using QuickMart.Infrastructure.Repository;
using QuickMart.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuickMartDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductMasterRepository, ProductMasterRepository>();
builder.Services.AddTransient<IProductMasterService, ProductMasterService>();

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
