namespace BlazorShop.Web.Server.Infrastructure.Extensions {
    using BlazorShop.Services.Common;
    using Data;
    using Data.Contracts;
    using Data.Models;
    using Data.Seed;
    using Filters;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using Services;
    using System.Linq;
    using System.Text;

    public static class ServiceCollectionExtensions {
        public static ApplicationSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration) {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(ApplicationSettings));
            //services.Configure<ApplicationSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<ApplicationSettings>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                //.AddDbContext<BlazorShopDbContext>(options => options
                //    .UseSqlServer(configuration.GetDefaultConnectionString()))
                .AddDbContext<BlazorShopDbContext>(opt => opt.UseMySql(configuration.GetDefaultConnectionString(), ServerVersion.AutoDetect(configuration.GetDefaultConnectionString())))
                .AddTransient<IInitialData, CategoriesData>()
                .AddTransient<IInitialData, ProductsData>()
                .AddTransient<IInitializer, BlazorShopDbInitializer>();

        public static IServiceCollection AddIdentity(this IServiceCollection services) {
            services.AddIdentity<BlazorShopUser, BlazorShopRole>(opt => {
                opt.Password.RequiredLength = ModelConstants.Identity.MinPasswordLength;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BlazorShopDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            ApplicationSettings applicationSettings) {
            var key = Encoding.ASCII.GetBytes(applicationSettings.Secret);

            services
                .AddAuthentication(authentication => {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer => {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            var transientServiceInterfaceType = typeof(IService);
            var singletonServiceInterfaceType = typeof(ISingletonService);
            var scopedServiceInterfaceType = typeof(IScopedService);

            var types = transientServiceInterfaceType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    ServiceInterface = t.GetInterface($"I{t.Name}"),
                    ServiceImplementation = t
                })
                .Where(t => t.ServiceInterface != null);

            foreach (var type in types) {
                if (type.ServiceInterface!.IsAssignableTo(transientServiceInterfaceType)) {
                    services.AddTransient(type.ServiceInterface, type.ServiceImplementation);
                } else if (type.ServiceInterface!.IsAssignableTo(singletonServiceInterfaceType)) {
                    services.AddSingleton(type.ServiceInterface, type.ServiceImplementation);
                } else if (type.ServiceInterface!.IsAssignableTo(scopedServiceInterfaceType)) {
                    services.AddScoped(type.ServiceInterface, type.ServiceImplementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services) {
            services.AddControllers(options => options.Filters.Add<ModelOrNotFoundActionFilter>());
            services.AddRazorPages();
            return services;
        }
    }
}
