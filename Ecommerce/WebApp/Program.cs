using Fluent.Infrastructure.FluentModel;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = DataAccess.Context.ApplicationDbContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Agregar DbContext con la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
