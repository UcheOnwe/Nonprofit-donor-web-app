using Microsoft.EntityFrameworkCore;
using Radzen;
using UcheNonProfit.Components;
using UcheNonProfit.Models;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("NonProfitDB");
builder.Services.AddDbContext<NonProfitDBContext>(options =>
    options.UseSqlServer(connectString));

builder.Services.AddRadzenComponents();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
