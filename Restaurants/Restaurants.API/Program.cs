using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.AddInfrastructure();
var app = builder.Build();
var scope=app.Services.CreateScope();
var seeder=scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
