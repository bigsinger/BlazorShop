namespace BlazorShop.Models.Mapping {
    using AutoMapper;
    using BlazorShop.Common.Mapping;
    using System;
    using System.Linq;
    using System.Reflection;

    /*
     放在需要配置自动mapping的类所在的程序集下面，构造函数不能省。然后调用者：
     builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly)
     */
    public class MappingProfile : Profile {
        public MappingProfile()
            => this.ApplyMappingsFromAssembly(typeof(MappingProfile).Assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly) {
            var types = assembly
                .GetExportedTypes()
                .Where(t => t
                    .GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach(var type in types) {
                var instance = Activator.CreateInstance(type);

                const string mappingMethodName = "Mapping";

                var methodInfo = type.GetMethod(mappingMethodName)
                                 ?? type.GetInterface("IMapFrom`1")?.GetMethod(mappingMethodName);

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
