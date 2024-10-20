using Microsoft.Extensions.DependencyInjection;
using PremierLeague.Repositories;
using PremierLeague.Repositories.Entities;
using PremierLeague.Repositories.Interface;
using PremierLeague.Sevices;
using PremierLeague.Sevices.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// DI
builder.Services.AddDbContext<EnglishPremierLeague2024DbContext>();
// DI Repositories
builder.Services.AddScoped<IPremierLeagueAccountRepositories, PremierLeagueAccountRepositories>();
//DI Sevices
builder.Services.AddScoped<IPremierLeagueAccountSevices, PremierLeagueAccountSevices>();
builder.Services.AddScoped<PremierLeague.Repositories.PremierLeagueAccountRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
