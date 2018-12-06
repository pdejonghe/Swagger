using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace SwaggerWebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger sample",
                    Version = "v1",
                    Description = "A simple application to show the usage of Swagger",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Peter De Jonghe",
                        Email = "email@gmail.com",
                        Url = "https://twitter.com/pdejonghe"
                    },
                    License = new License
                    {
                        Name = "Some license",
                        Url = "https://example.com/license"
                    }
                });

                //Set the comments path for the Swagger JSON and UI ...
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Enable middleware to server generated Swagger as a JSON endpoint ...
            app.UseSwagger();

            //Enable middleware to server SwaggerUI (HTML, JS, CS, ...), specifying the Swagger JSON endpoint ...
            app.UseSwaggerUI(options =>
            {
                //f using directories with IIS or a reverse proxy, set the Swagger endpoint to a relative path using the ./ prefix, eg: "./swagger/v1/swagger.json". 
                //Using "/swagger/v1/swagger.json" instructs the app to look for the JSON file at the true root of the URL (plus the route prefix, if used). 
                //For example, use "http://localhost:<port>/<route_prefix>/swagger/v1/swagger.json" instead of "http://localhost:<port>/<virtual_directory>/<route_prefix>/swagger/v1/swagger.json".
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger sample v1");

                //To serve the Swagger UI at the app's root (https://localhost:port/), set the RoutePrefix
                //property to an empty string ...
                //options.RoutePrefix = string.Empty;
                //The default Swagger UI can be found at https://localhost:port/swagger ...
            });

            app.UseMvc();
        }
    }
}
