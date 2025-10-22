using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("DataSource=:memory:"));

var app = builder.Build();

// Inicializa banco em memória
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.OpenConnection();
    db.Database.EnsureCreated();
}

app.MapGet("/api/accounts", async (AppDbContext db) =>
    await db.Accounts.ToListAsync());

app.MapPost("/api/accounts", async (AppDbContext db, Account account) =>
{
    db.Accounts.Add(account);
    await db.SaveChangesAsync();
    return Results.Created($"/api/accounts/{account.Id}", account);
});

app.Run();

public partial class Program { } // Necessário para testes de integração
