using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeds;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


//builder.Services.AddDbContext<RestaurantsDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantsDB"));
//});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();



var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeds>();
await seeder.Seed();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
