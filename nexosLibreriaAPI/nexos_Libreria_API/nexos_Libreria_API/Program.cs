using Microsoft.EntityFrameworkCore;
using nexos_Libreria_API.Services.Interfaces;
using Nexos_Libreria_API.DataAccess;
using Nexos_Libreria_API.Services.Services;
using Nexos_Libreria_API.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<LibreriaContext>(options => {
    options.UseSqlServer((builder.Configuration.GetConnectionString("LibraryConection")));
});

builder.Services.AddScoped<IBooks, BookService>();
builder.Services.AddScoped<IAutors, AutorService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<LibreriaContext>();
    dataContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();