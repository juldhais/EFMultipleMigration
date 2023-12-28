using EFMultipleMigration;
using EFMultipleMigration.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

switch (builder.Configuration.GetConnectionString("Provider"))
{
    case "SqlServer":
        builder.Services.AddDbContext<DataContext, SqlServerDataContext>();
        break;
    case "Sqlite":
        builder.Services.AddDbContext<DataContext, SqliteDataContext>();
        break;
}

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("1990-01-01")
    })
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
dataContext.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
