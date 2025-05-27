using Microsoft.EntityFrameworkCore;
using LibrairieReservation.Models;
using LibrairieReservation.Data;
var builder = WebApplication.CreateBuilder(args);

// Ajout du DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout des services Razor Pages (obligatoire si tu utilises Razor Pages)
builder.Services.AddRazorPages();

// Si tu utilises MVC avec contrôleurs + vues, tu peux aussi garder
// builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages
app.MapRazorPages();

// Map MVC controllers (optionnel si tu utilises MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
