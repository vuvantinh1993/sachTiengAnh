using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.BackgroundTasks;
using CTIN.Domain.Bases;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases.Services;
using CTIN.WebApi.Bases.Swagger;
using CTIN.WebApi.Modules.AES;
using CTIN.WebApi.Modules.JWT;
using CTIN.WebApi.Modules.System1.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;

namespace CTIN.WebApi
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
            services.AddDbContext<NATemplateContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection")));

            // Register the Swagger generator, defining one or more Swagger documents        
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", null);

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                //c.CustomSchemaIds(x => x.FullName);

                c.SchemaFilter<SwaggerFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "CTIN.WebApi.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // Register Module
            services.AddModule<DomainModule>();
            services.AddModule<DataAccessModule>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHostedService<ConsumeScopedServiceHostedService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddHttpContextAccessor();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    })
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressMapClientErrors = true;
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            var result = new ResultModel<dynamic>
                            {
                                error = new SerializableError(context.ModelState)
                            };

                            return new BadRequestObjectResult(result);
                        };

                        options.ClientErrorMapping[404].Link =
                            "https://httpstatuses.com/404";
                    });

            //apply all cors call api
            services.AddCors(options => options.AddPolicy("Cors",
            builder =>
            {
                builder.
                AllowAnyOrigin().
                WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString(),
                            Configuration["ApplicationSettings:Client_URL2"].ToString()).
                AllowAnyMethod().
                AllowAnyHeader().
                AllowCredentials();
            }));

            //gzip
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = new[]
                {
                    // Default
                    "text/plain",
                    "text/css",
                    "application/javascript",
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                    // Custom
                    "image/svg+xml",
                    "image/jpeg",
                    "image/png"
                };
                options.EnableForHttps = true;
            });
            services.AddDistributedMemoryCache();

            // Identity
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            services.AddDefaultIdentity<ApplicationUser>(
                config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                    typeof(DataProtectorTokenProvider<IdentityUser>)));
                    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<NATemplateContext>().AddDefaultTokenProviders();
            services.AddTransient<DataProtectorTokenProvider<IdentityUser>>();
            // setup identity
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            });

            //JWT
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            // Sendmail
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/api/error");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
                app.UseExceptionHandler("/api/error");
            }
            //enable gzip
            app.UseResponseCompression();

            // identity
            app.UseAuthentication();

            app.UseCors("Cors");

            // requests to a folder search for index.html
            app.UseDefaultFiles();

            // For the wwwroot folder
            app.UseStaticFiles();

            // fix folder main to default angular
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public, max-age=600");
                },
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "main")),
                RequestPath = new PathString("")
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WHM API");
            });

            // router angular
            app.MapWhen(context => !context.Request.Path.Value.StartsWith("/api"), builder =>
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute(
                       name: "angular",
                       defaults: new { controller = "Home", action = "Index" }
                   );
                });
            });

            // router default      
            //app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
