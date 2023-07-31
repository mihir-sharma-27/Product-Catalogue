using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalogueService.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductCatalogueServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductCatalogueServiceContext") ?? throw new InvalidOperationException("Connection string 'ProductCatalogueServiceContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Add CORS policy allowing all origins, headers, and methods
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin());

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

app.UseCors("AllowAll"); // Use the CORS policy globally

app.MapControllers();

app.Run();
