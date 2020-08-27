using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using TFProjectAPI.MiddleWare;
using TFProjectAPI.ToolBox.Security.JWT;

namespace TFProjectAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTokenAuthentication(Configuration); // DCO Token iD Token ID

            //services.AddTransient((x) => new TokenService(
            //    Configuration.GetSection("Security").GetValue<string>("Signature"),
            //    null,
            //    null,
            //    Configuration.GetSection("Security").GetValue<int>("Delay")
            //));

            //services.AddSwaggerDocument(config =>
            //{
            //    config.PostProcess = document =>
            //    {
            //        document.Info.Version = "v1";
            //        document.Info.Title = "DCO PROJECT";
            //        document.Info.Description = "C'est vraiment trop cool";
            //        document.Info.Contact = new NSwag.OpenApiContact
            //        {
            //            Name = "Coppens Dominique",
            //            Email = "dominique.coppens77@gmail.com"
            //        };
            //    };

            //    // Dont forget to go in the XML project and add in  <PropertyGroup> (to allow using the comment in the rest of the program)
            //    //  < GenerateDocumentationFile > true </ GenerateDocumentationFile >
            //    //  < NoWarn >$(NoWarn); 1591 </ NoWarn >


            //       // Handle Bearer TOKEN + JWT
            //       config.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
            //        new OpenApiSecurityScheme
            //        {
            //            Type = OpenApiSecuritySchemeType.ApiKey,
            //            Name = "Authorization",
            //            Description = "Copy 'Bearer ' + valid JWT token into field",
            //            In = OpenApiSecurityApiKeyLocation.Header
            //        }));

            //    config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            //});

            
            services.AddOpenApiDocument(d =>
            {
                // d.DocumentName = "V 0.1";
                d.Title = "The 'Personal Hell' of my Wallet";
                d.Description = "U must first login into /api/user/login in order to get the Bearer Token and use the Rest of the API options";
                d.PostProcess = pp => {
                    pp.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Coppens Dominique",
                        Email = "dominique.coppens77@gmail.com"
                    };
                    pp.Info.Version = "0.1";
                    pp.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Visit my Linkdn Page",
                        Url = "http://www.linkedin.com/in/dominique-coppens77"
                    };

                    //pp.Info.Title = "iThe personal Hell of my wallet";
                    //pp.Info.Description = "iList of what i've own";
                };

                d.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                // Dont forget to go in the XML project and add in  <PropertyGroup> (to allow using the comment in the rest of the program)
                d.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
            {
                if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                {
                    return request.PathBase + internalUiRoute;
                }
                else
                {
                    return internalUiRoute;
                }
            });

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseRouting();
            app.UseAuthentication(); // DCO Token iD
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
