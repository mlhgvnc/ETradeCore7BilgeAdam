#nullable disable

using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IoC Container : Inversion of Control Container (Bağımlılıkların Yönetimi) 
// Alternatif olarak Autofac ve Ninject gibi kütüphaneler de kullanılabilir.

// Unable to resolve service hataları burada çözümlenmelidir.

// AddScoped: istek (request) boyunca objenin referansını (genelde interface veya abstract class) kullandığımız yerde obje (somut class'tan oluşturulacak)
// bir kere oluşturulur ve yanıt (response) dönene kadar bu obje hayatta kalır.
// AddSingleton: web uygulaması başladığında objenin referansnı (genelde interface veya abstract class) kullandığımız yerde obje (somut class'tan oluşturulacak)
// bir kere oluşturulur ve uygulama çalıştığı (IIS üzerinden uygulama durdurulmadığı veya yeniden başlatılmadığı) sürece bu obje hayatta kalır.
// AddTransient: istek (request) bağımsız ihtiyaç olan objenin referansını (genelde interface veya abstract class) kullandığımız her yerde bu objeyi new'ler.
// Genelde AddScoped methodu kullanılır.

string connectionString = builder.Configuration.GetConnectionString("ETradeDb"); // appsettings.json veya appsettings.Development.json dosyalarındaki isim üzerinden atanan
                                                                                 // veritabanı bağlantı string'ini döner.
builder.Services.AddDbContext<ETradeContext>(options => options.UseSqlServer(connectionString));
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
