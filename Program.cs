using Microsoft.EntityFrameworkCore;
using SMS_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Retrive the Connection String from the "appsettings.json"
//var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SmsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add a CORS policy to the application's services
builder.Services.AddCors(options =>
{
    // Add a default policy to the options
    options.AddDefaultPolicy(policybuilder =>
    {
        // Allow any origin
        policybuilder.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>());

        // Allow any header
        policybuilder.AllowAnyHeader();

        // Allow any method
        policybuilder.AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseRouting();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
