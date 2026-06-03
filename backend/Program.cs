using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
var ConnectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();