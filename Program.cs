using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalogueService.Data;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ProductCatalogueServiceContext>(options =>
{
    options.UseInMemoryDatabase("ProductCatalogue"); // Replace with your unique database name
});

// Add CORS policy allowing all origins, headers, and methods
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin());

});


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ProductCatalogueServiceContext>();
    // Perform database operations here if needed
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll"); // Use the CORS policy globally

app.Run();
