using Microsoft.EntityFrameworkCore;
using Truck.Application.Interfaces;
using Truck.Application.Services;
using Truck.Data.Context;
using Truck.Data.Repository;
using Truck.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

//Application services.
builder.Services.AddTransient<ITruckService, TruckService>();
builder.Services.AddTransient<IModelTruckService, ModelTruckService>();

//Data.
builder.Services.AddTransient<ITruckRepository, TruckRepository>();
builder.Services.AddTransient<IModelTruckRepository, ModelTruckRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Update database to the latest version.
using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var context = serviceScope.ServiceProvider.GetService<DataContext>();
context.Database.Migrate();

app.Run();
