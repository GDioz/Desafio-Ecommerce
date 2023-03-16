using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;
using System;

namespace DF.Ecommerce.Api.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceApi", Description = "Api para Ecommerce", Version = "v1" });
                var apiPath = Path.Combine(AppContext.BaseDirectory, "DF.Ecommerce.Api.xml");

                c.IncludeXmlComments(apiPath);

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "basicAuthHeader"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[]{}
                    } 
                });
            });
            return services;
        }
    }
}
