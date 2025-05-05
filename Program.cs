using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ShoppingListAPI.Data;
using ShoppingListAPI.Extensions; // Criado para organizar os métodos de extensão

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ShoppingListDB"));

builder.Services
    .AddApplicationServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerWithJwt()
    .AddAuthorization()
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping List API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 

app.Run();
