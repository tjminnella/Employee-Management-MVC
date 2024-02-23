using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   //add configuration services
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            /*services.AddDbContextPool<AppDBContext>
                (options => options.UseSqlite(_config.GetConnectionString("EmployeeManagementDBConnection")));*/


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<CustomEmailConfirmationTokenProvider
                <ApplicationUser>>("CustomEmailConfirmation");

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                        o.TokenLifespan = TimeSpan.FromHours(5));

            services.Configure<CustomEmailConfirmationTokenProviderOptions>(o =>
                        o.TokenLifespan = TimeSpan.FromDays(3));

            //add MVC Services fixed bug with this version, Calls all the MVC methods
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.EnableEndpointRouting = false; //bug fix
            })
            //.AddNewtonsoftJson()
            .AddXmlSerializerFormatters();
            
            

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "443892072779-3n0ljac2jnar4kmnnlkn74h4ic1tdq54.apps.googleusercontent.com";
                    options.ClientSecret = "7C6TvX2SWEodUuXd3EpsoO1R";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "2316662895109472";
                    options.AppSecret = "e25c1b8d4145034ed426d7a05efe1481";
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin"));
            });

            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddScoped<IActionRepository, MockActionRepository>();
            services.AddScoped<IActionRepository, SQLActionRepository>();
            //services.AddScoped<ILocationRepository, MockLocationRepository>();
            services.AddScoped<ILocationRepository, SQLLocationRepository>();
            //services.AddScoped<IMovementRepository, MockMovementRepository>();
            services.AddScoped<IMovementRepository, SQLMovementRepository>();


            services.AddSingleton<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            services.AddSingleton<IAuthorizationHandler, SuperAdminHandler>();
            services.AddSingleton<DataProtectionPurposeStrings>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPage = new DeveloperExceptionPageOptions { SourceCodeLineCount = 25 };
                app.UseDeveloperExceptionPage();
                //Microsoft.VisualStudio.Web.BrowserLink
                //creates a communication channel between the development environment and one or more web browsers
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //returns 200 success because it redirects to a good page
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //returns 404 not found failure, reissues the pipeline
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            //use default files must be registered befure use static files. It is terminal 

            /*DefaultFilesOptions defaultFiles = new DefaultFilesOptions();
            logger.LogInformation("Use Default Files");
            defaultFiles.DefaultFileNames.Clear();
            defaultFiles.DefaultFileNames.Add("Home.html");
            app.UseDefaultFiles(defaultFiles);*/

            app.UseStaticFiles();
            //Identity
            app.UseAuthentication();
            //routing templates
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });


            //combines use default and use static code above
            /*FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("RNHome.html");
            app.UseFileServer(fileServerOptions);*/

            //not sure what this is for.
            //app.UseRouting();

            //app.Use(async(context.Response.WriteAsync("")));

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(_config["MyKey"] 
                        + " : " + _config["MyKey1"] + 
                    " : " + _config["ASPNETCORE_ENVIRONMENT"] );


                //System.Diagnostics.Process.GetCurrentProcess().ProcessName
            });
            });*/
            //context object has Request and Response
            //middleware starts here
            /*app.Use(async (context, next) =>
            {logger.LogInformation("Top First");
                await context.Response.WriteAsync("First Middleware");
                await next(); });*/

            //Terminal Middleware
            //logger.LogInformation("Terminal Middleware");
            /*app.Run(async (context) =>
            {
                if (env.IsDevelopment())
                { await context.Response.WriteAsync("You are in the " + env.EnvironmentName);}
                else
                { throw new Exception("Environment: " + env.EnvironmentName); }
                
            });*/
        }
    }
}
