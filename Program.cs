using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AgroStore.Data;
using AgroStore.Shared.Interfaces;
using AgroStore.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server;
using AgroStore.Shared;
using AgroStore.Authentication;
using AgroStore.Authentication.CustomAuthenticationStateProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<AuthenticationStateProvider , CustomAuthenticationStateProvider>();

builder.Services.AddDbContext<AppDbcontext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<IProductService, ProductService>(); // Cambio realizado aquí
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IShoppingcCart,ShoppingCartService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbcontext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();


builder.Services.AddAuthorization();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
