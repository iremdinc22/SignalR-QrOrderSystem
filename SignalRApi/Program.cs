using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore; //  UseNpgsql için gerekli
using SignalR.BusinessLayer.Container;
using SignalR.BusinessLayer.ValidationRules.BookingValidations;
using SignalR.DataAccessLayer.Concrete;
using SignalRApi.Hubs;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed(host => true)
              .AllowCredentials();
    });
});

// DbContext’i appsettings.json’daki connection string ile configure et
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DbContext
builder.Services.AddDbContext<SignalRContext>();
// 🔹 AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// DI registrations
// Extensions.cs içindeki ContainerDependencies metodunu çağırıyoruz.
builder.Services.ContainerDependencies();


// Fluent Validation ı ekleyen kısım
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidation>();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// MVC Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();

