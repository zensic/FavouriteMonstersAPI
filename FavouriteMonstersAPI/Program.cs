using FavouriteMonstersAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// Add MVC controller service
builder.Services.AddControllers();

// Add swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database context
builder.Services.AddDbContext<MonstersDbContext>(options =>
{
    string connectionString;
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

    if (env == "Production")
    {
        // If the production environment, use connection string in heroku config vars
        var connUser = Environment.GetEnvironmentVariable("DB_USERNAME");
        var connPass = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var connHost = Environment.GetEnvironmentVariable("DB_HOST");
        var connDb = Environment.GetEnvironmentVariable("DATABASE");

        connectionString = $"server={connHost};Uid={connUser};Pwd={connPass};Database={connDb}";
    }
    else
    {
        // If development environment, use connection string in appsettings config
        connectionString = builder.Configuration.GetConnectionString("MonstersDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MonstersDbContextConnection' not found.");
    }

    options.UseMySql(connectionString, serverVersion);
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

app.MapControllers();

app.Run();