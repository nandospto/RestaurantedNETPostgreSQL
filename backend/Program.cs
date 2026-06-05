using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Serviços

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:5173") // URL do seu React
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// 
var ConnectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(ConnectionString));

var app = builder.Build();

app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();