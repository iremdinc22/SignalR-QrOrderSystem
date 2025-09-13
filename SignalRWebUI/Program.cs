using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;   // <-- eklendi


var builder = WebApplication.CreateBuilder(args);

// Doğru sınıf adı: AuthorizationPolicyBuilder
var requiredAuthorizePolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();

builder.Services.AddHttpClient();

// Tüm controller'lara yetkilendirme filtresi ekleniyor.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requiredAuthorizePolicy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index"; // Giriş sayfası yolu
});

var app = builder.Build();

// 404 Hataları için özel yönlendirme
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == 404)
    {
        response.Redirect("/Error/NotFound404Page");
    }
}); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();          // wwwroot'tan dosya sunar

app.UseRouting();
app.UseAuthentication();      // Kimlik doğrulamayı etkinleştirir
app.UseAuthorization();

//app.MapControllerRoute(
// name: "default",
// pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
 name: "default",
pattern: "{controller=Category}/{action=Index}/{id?}");


app.Run();
