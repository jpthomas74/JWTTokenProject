using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JWT.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime.Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(o =>
            //{
            //    o.RequireHttpsMetadata = false;
            //    o.SaveToken = true;
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //         //ClockSkew = TimeSpan.FromMinutes(Convert.ToInt32(Configuration["JWT:DurationInMinutes"])),
            //         ValidIssuer = "https://localhost:44318",
            //        ValidAudience = "SecureApiUser",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C1CF4B7DC4C4175B6618DE4F55CA4"))
            //    };
            //});


            //services.AddAuthentication("Bearer")
            // .AddJwtBearer("Bearer", options =>
            // {

            //     options.Audience = "SecureApiUser";
            //     options.Authority = "https://localhost:44318";
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateAudience = false
            //     };
            // });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:44318"; ;
                options.RequireHttpsMetadata = false;
                options.Audience = "SecureApiUser";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();

        //    JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = "Cookies";
        //        options.DefaultChallengeScheme = "oidc";
        //    })
        //    .AddCookie("Cookies")
        //    .AddOpenIdConnect("oidc", options =>
        //    {
        //        options.Authority = "https://localhost:44318";

        //        options.ClientId = "mvc";
        //        options.ClientSecret = "secret";
        //        options.ResponseType = "code";

        //        options.Scope.Add("profile");

        //        options.GetClaimsFromUserInfoEndpoint = true;

        //        options.SaveTokens = true;

        //        options.Scope.Add("api1");
        //        options.Scope.Add("offline_access");
        //    });
        //}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
