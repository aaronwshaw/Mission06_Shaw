using Microsoft.EntityFrameworkCore;
using Mission06_Shaw.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure connection to database
builder.Services.AddDbContext<MovieSubmissionContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
