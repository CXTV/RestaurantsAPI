using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeds;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


builder.Host.UseSerilog((context,configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeds>();

await seeder.Seed();

// Configure the HTTP request pipeline.
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
