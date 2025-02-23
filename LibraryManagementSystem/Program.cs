var builder = WebApplication.CreateBuilder(args);

// MVC servislerini ekliyoruz. Bu, controller ve view'lar� kullanabilmek i�in gerekli.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Default routing yap�s�n� kullanarak, gelen istekleri do�ru controller ve aksiyon metodlar�na y�nlendiriyoruz.
app.MapDefaultControllerRoute();    // /home/index'e y�nlendiriyo

// Uygulama �al��maya ba�l�yor.
app.Run();
