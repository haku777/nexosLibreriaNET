using nexos_Libreria_MVC.Services.Services;
using nexos_Libreria_MVC.Services.Services.Api;
using nexos_Libreria_MVC.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBooks, BooksApiServices>();
builder.Services.AddScoped<IapiPath, ApiPath>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("");

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default"
    ,pattern: "{controller=Books}/{action=Index}");

app.Run();
