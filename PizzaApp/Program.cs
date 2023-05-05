using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //options.JsonSerializerOptions.MaxDepth = 0;
    //options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(option => option.UseInMemoryDatabase("Demo"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<DatabaseContext>();
DatabaseContext.SetInitialData(context);

app.Run();
