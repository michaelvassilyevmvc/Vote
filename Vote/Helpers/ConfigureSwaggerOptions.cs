using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Vote.WebApi.Helpers
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Vote",
                Version = description.ApiVersion.ToString(),
                Description = "Web Service for Vote",
                Contact = new OpenApiContact
                {
                    Name = "Michael Vassilyev",
                    Email = "rebusmv511@gmail.com",
                    Url = new System.Uri("https://vote.xyz/support")
                }
            };

            if(description.IsDeprecated)
            {
                info.Description += "<strong> This API version of Vote has been deprecated. </strong>";
            }

            return info;
        }
    }
}
