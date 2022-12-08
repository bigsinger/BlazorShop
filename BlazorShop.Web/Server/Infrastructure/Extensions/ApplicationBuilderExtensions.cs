namespace BlazorShop.Web.Server.Infrastructure.Extensions {
    using Data.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class ApplicationBuilderExtensions {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            return app;
        }

        //public static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
        //    => app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapRazorPages();
        //        endpoints.MapControllers();
        //        endpoints.MapFallbackToFile("index.html");
        //    });

        public static IApplicationBuilder Initialize(this IApplicationBuilder app) {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IInitializer>();

            foreach (var initializer in initializers) {
                initializer.Initialize();
            }

            return app;
        }
    }
}
