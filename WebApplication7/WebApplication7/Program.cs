using Microsoft.EntityFrameworkCore;
using WebApplication7.Data; // <-- Make sure this matches your actual namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ✅ Use AddControllersWithViews to support both APIs and Razor Views
builder.Services.AddControllersWithViews();

// ✅ Register your DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // ✅ Add this to serve CSS, JS, etc.

app.UseRouting();

app.UseAuthorization();

// ✅ Enable MVC controller routing (for LoginController + Views)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

// ✅ Also keep API routing
app.MapControllers();

app.Run();
