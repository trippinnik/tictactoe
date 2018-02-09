using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace tictactoe
{
    /// <summary>
    /// defines the configuration of the Web API application
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// initialize startup of the <see cref="Startup"/> class
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="hostingEnvironment"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }
        /// <summary>
        /// Gets the hosting environment.
        /// </summary>
        /// <value>
        /// The hosting environment.
        /// </value>
        public IHostingEnvironment HostingEnvironment { get; }
        /// <summary>
        /// gets the configuration
        /// </summary>
        /// <value>
        /// the configuration
        /// </value>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// this method is called at runtime. used for adding services to container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //swagger
            services.AddSwaggerGen(ConfigureSwaggerUI);
        }

        private void ConfigureSwaggerUI(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc("v1", new Info { Title = "Tic Tac Toe", Version = "v1" });

            var filePath = Path.Combine(path1: HostingEnvironment.ContentRootPath, path2: "TicTacToe.config");
            swaggerGenOptions.IncludeXmlComments(filePath);
        }
        /// <summary>
        /// called at runtime. use to configure the HTTP pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // SWAGGER: Insert middleware to expose the generated Swagger as JSON endpoints
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    // Necessary for API management so it has the proper values for the Backend service URL otherwise 
                    // you will see an error in trace similar to "Backend service URL is not defined"
                    swaggerDoc.Host = httpReq.Host.Value;
                });
            });

            // SWAGGER: swagger-ui-middleware to expose interactive documentation
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tic Tac Toe Swagger");
            });

        }
    }
}
