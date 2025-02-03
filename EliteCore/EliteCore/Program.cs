using EliteCore.Models;
using EliteCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DbContext servisini ekleyelim
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Connection string'i appsettings.json'dan al
builder.Services.AddDbContext<EliteDbContext>(options =>
    options.UseSqlServer(connectionString)); // SQL Server kullan?yorsan

// Swagger ve API için gerekli servisleri ekle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// GelenMailService'yi ekle
builder.Services.AddScoped<GelenMailService>();

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

// Uygulaman?n çal??mas? için gerekli servisleri kullanarak i?lemleri ba?lat
using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var context = serviceScope.ServiceProvider.GetService<EliteDbContext>();

app.Run();
