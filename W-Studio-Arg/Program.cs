using Portafolio.Servicios;
using W_Studio_Arg.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioEmpresa, RepositorioEmpresa>();
builder.Services.AddTransient<IServicioEmail, ServicioEmail>();

// Test de servicios.
//builder.Services.AddTransient<ServicioTransitorio>();
//builder.Services.AddScoped<ServicioDelimitado>();
//builder.Services.AddSingleton<ServicioUnico>();

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
