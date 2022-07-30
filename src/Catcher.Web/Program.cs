using Catcher.Web.Config;
using System;
using System.Net;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "127.0.0.1:6666,ssl=True,abortConnect=False";
//});

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
app.UseStatusCodePages(context =>
{
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;
    var path = request.Path.Value ?? "";

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized && !path.StartsWith("/api", StringComparison.InvariantCultureIgnoreCase))
    {
        //var RedirectPath = $"{request.Scheme}://{request.Host}/Account/Login";
        //response.Redirect(RedirectPath);
        response.Redirect("/Account/Login");
    }

    return System.Threading.Tasks.Task.CompletedTask;
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
