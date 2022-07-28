using Catcher.Web.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddControllersWithViews();

DataBase.Connection(builder);
DependencyInjection.Container(builder);
JwtConfig.Set(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStatusCodePages(async context =>
{
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;
    var path = request.Path.Value ?? "";

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized || path.StartsWith("/api", StringComparison.InvariantCultureIgnoreCase))
    {
        //var RedirectPath = $"{request.Scheme}://{request.Host}/Account/Login";
        //response.Redirect(RedirectPath);
        response.Redirect("/Account/Login");
    }
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
