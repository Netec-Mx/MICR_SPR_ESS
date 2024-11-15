using MVCMonolitico.Models.Data;
using MVCMonolitico.Models.Data.Repositories;
using MVCMonolitico.Models.Services.Implementations;
using MVCMonolitico.Models.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*Se inyecta contexto de base de datos*/
builder.Services.AddDbContext<AppDBContext>();

/*Se inicializan los repositorios*/
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ItemRepository>();

/*Se inicializan los servicios*/
builder.Services.AddScoped<IItemService, ItemServiceImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();



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
