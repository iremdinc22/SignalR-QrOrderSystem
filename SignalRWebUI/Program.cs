using SignalR.EntityLayer.Entities;
using SignalR.DataAccessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();          // wwwroot'tan dosya sunar

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
// name: "default",
// pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
 name: "default",
pattern: "{controller=Category}/{action=Index}/{id?}");


app.Run();
