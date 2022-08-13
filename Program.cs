using WebApplication4.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Para agregar servicios se utiliza builder.services

//agregamos nuestro primer servicio con inyeccion de independencia.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                    options.UseSqlServer(
                                        builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//Pipeline especifica como debemos de responder a solicitudes http extras
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //Este obliga al usuario a usar una linea segura.
app.UseStaticFiles(); //hojas de estilo, imagenes y mucho mas

app.UseRouting(); //esto lo controla mvcRouting

app.UseAuthorization(); //la autorizacion se encuentra antes del mapeo, en asp el orden importa lo controla MVCrouting

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
