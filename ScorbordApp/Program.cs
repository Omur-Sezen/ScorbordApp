using Microsoft.EntityFrameworkCore;
using ScorbordApp.Entities; // Entities klasöründeki modellerini görmesi için

var builder = WebApplication.CreateBuilder(args);

// 1. Veritabanı Servisini Ekle (SQLite kullanarak)
// Bu satır, SQL Server servis hatalarını devre dışı bırakır ve projeyi çalıştırır.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Scorbord.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Swagger Yapılandırması
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();