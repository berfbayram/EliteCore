using EliteCore.Models;
using EliteCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// **CORS Politikas? Ekle**
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.WithOrigins("https://localhost:9000", "http://localhost:9000")  // Frontend'inizin URL'si
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();  // E?er kimlik bilgileri gerekiyorsa
        });
});

// **Database Ba?lant?s?**
var connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Bernardo9988@";
builder.Services.AddDbContext<EliteDbContext>(options =>
    options.UseNpgsql(connectionString)
);

// **Ba??ml?l?klar? Ekle**
builder.Services.AddControllers();
builder.Services.AddScoped<GelenMailService>();

// **Swagger API Deste?i**
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// **CORS'u Uygula**
app.UseCors("AllowAllOrigins");

// **Swagger UI'y? Devreye Al**
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// **Veritaban? Ba?lant?s?n? Ba?lat**
using var serviceScope = app.Services.CreateScope();
using var context = serviceScope.ServiceProvider.GetRequiredService<EliteDbContext>();

app.Run();
