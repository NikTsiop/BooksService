using BooksService.Api.Middleware;
using BooksService.Application;
using BooksService.Infrastructure;
using BooksService.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var dbPath = Path.Combine(AppContext.BaseDirectory, "app.db");
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);


builder.Services.AddApplicationModule();
builder.Services.AddInfrastructureModule();
builder.Services.AddPersistenceModule();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(StartupBase));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    DbInitializer.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
