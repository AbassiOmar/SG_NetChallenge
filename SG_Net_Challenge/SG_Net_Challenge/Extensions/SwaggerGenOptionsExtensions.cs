namespace SG_Net_Challenge.Extensions
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Reflection;

    public static class SwaggerGenOptionsExtensions
    {
        public static void ConfigureSwaggerGen(this SwaggerGenOptions options)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName();
            var informationalVersion = Attribute.GetCustomAttribute(assembly, typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
            options.SwaggerDoc("v1", new OpenApiInfo { Title = assemblyName.Name, Version = informationalVersion?.InformationalVersion });
            options.CustomOperationIds(CustomOperationIdsSelector);
        }

        private static string CustomOperationIdsSelector(ApiDescription apiDesc)
        {
            return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
        }
    }
}
