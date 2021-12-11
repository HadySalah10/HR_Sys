using HR_Sys.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HrDBContext>(o => o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("HRsyscon")));
// add session

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMvc();
//builder.Services.AddMemoryCache();  
builder.Services.AddSession();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseCookiePolicy();
//configure session 
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HR}/{action=Index}/{id?}");
app.Run();


//app.UseSession(ConfigureHostBuilder: s => s.IdleTimeout = System.TimeSpan.FromMinutes(30));
//app.UseErrorPage();
//app.UseStaticFiles();
//app.UseMvc(routes =>
//{
//    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
//});

