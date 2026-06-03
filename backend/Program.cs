using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var ConnectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();