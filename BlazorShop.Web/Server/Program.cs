using BlazorShop.Web.Server.Infrastructure.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDatabase(builder.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddApplicationServices()
                .AddApiControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
} else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseExceptionHandling(env)
//    .UseValidationExceptionHandler();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    //.UseEndpoints()
    .Initialize();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
