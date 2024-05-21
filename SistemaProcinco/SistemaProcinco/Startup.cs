using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SistemaProcinco.API;
using SistemaProcinco.API.Extencions;
using SistemaProcinco.API.Servicios;
using SistemaProcinco.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco
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
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddTransient<IMailService, MailService>();

            services.DataAccess(Configuration.GetConnectionString("SistemaProcincoCon"));
            services.BusinessLogic();
            services.AddAutoMapper(x => x.AddProfile<MappingProfileExtensions>(), AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();



            services.AddControllers();

            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();

            services.AddSingleton<IAmazonS3>(sp =>
            {
                var awsOptions = sp.GetRequiredService<IOptions<AWSOptions>>().Value;
                return new AmazonS3Client(awsOptions.Credentials, new AmazonS3Config
                {
                    RegionEndpoint = Amazon.RegionEndpoint.USEast2
                });
            });

            services.AddScoped<CargarImagenService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaProcinco", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                  builder =>
                  {
                      builder.WithOrigins("https://localhost:44374")
                             .AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin();
                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
           
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaProcinco v1"));
            app.UseCors("AllowSpecificOrigin");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
