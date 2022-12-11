using BlazorShop.Models.Mapping;
using BlazorShop.Web.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDatabase(builder.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
                //.AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddAutoMapper(typeof(MappingProfile).Assembly)
                .AddApplicationServices()
                .AddApiControllers();

var app = builder.Build();

app.UseExceptionHandling(app.Environment);

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
