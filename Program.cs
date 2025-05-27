
using LibrairieReservation.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
// Ne pas ajouter Swagger ici
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ne pas utiliser Swagger dans le pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

// Ajoute tes routes ici, par exemple :
app.MapGet("/", () => "Hello World!");

// Autres routes (livres, réservations, utilisateurs, etc.)

app.Run();
