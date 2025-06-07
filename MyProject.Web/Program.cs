using MyProject.Repository;
using MyProject.Repository.Interfaces.User;
using MyProject.Repository.Interfaces.Desk;
using MyProject.Repository.Interfaces.FavoriteDesk;
using MyProject.Repository.Interfaces.Reservation;
using MyProject.Repository.Implementations.User;
using MyProject.Repository.Implementations.Desk;
using MyProject.Repository.Implementations.FavoriteDesk;
using MyProject.Repository.Implementations.Reservation;
using MyProject.Services.Implementations.Authentication;
using MyProject.Services.Implementations.Desk;
using MyProject.Services.Implementations.FavoriteDesk;
using MyProject.Services.Implementations;
using MyProject.Services.Implementations;
using MyProject.Services.Interfaces.Authentication;
using MyProject.Services.Interfaces.Desk;
using MyProject.Services.Interfaces.FavoriteDesk;
using MyProject.Services.Interfaces;
using MyProject.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDeskRepository, DeskRepository>();
builder.Services.AddScoped<IFavoriteDeskRepository, FavoriteDeskRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IDeskService, DeskService>();
builder.Services.AddScoped<IFavoriteDeskService, FavoriteDeskService>();


ConnectionFactory.SetConnectionString(
    builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
