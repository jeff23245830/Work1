using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Repository µù¥U
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
#endregion

#region Service µù¥U
builder.Services.AddScoped<ICategoryService, CategoryService>();
#endregion


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

app.Run();
