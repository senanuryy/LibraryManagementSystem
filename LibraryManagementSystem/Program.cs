var builder = WebApplication.CreateBuilder(args);

// MVC servislerini ekliyoruz. Bu, controller ve view'larý kullanabilmek için gerekli.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Default routing yapýsýný kullanarak, gelen istekleri doðru controller ve aksiyon metodlarýna yönlendiriyoruz.
app.MapDefaultControllerRoute();    // /home/index'e yönlendiriyo

// Uygulama çalýþmaya baþlýyor.
app.Run();
