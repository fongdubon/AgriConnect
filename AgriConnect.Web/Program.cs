using AgriConnect.Shared;
using AgriConnect.Web.Data;
using AgriConnect.Web.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgriConnect.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=con"));
            builder.Services.AddScoped<IUserHelper, UserHelper>();
            builder.Services.AddTransient<Seeder>();
            builder.Services.AddIdentity<User, IdentityRole>(
                x=>
                {
                    x.User.RequireUniqueEmail = true;
                    x.Password.RequireDigit = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequireUppercase = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequiredUniqueChars = 0;
                    x.Password.RequiredLength = 6;
                }).AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwtKey"]!)),
                    ClockSkew = TimeSpan.Zero
                });


            var app = builder.Build();
            SeedApp(app);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void SeedApp(WebApplication app)
        {
            IServiceScopeFactory? serviceScopeFactory = app.Services.GetService<IServiceScopeFactory>();
            using (IServiceScope? serviceScope = serviceScopeFactory!.CreateScope())
            {
                Seeder? seeder = serviceScope.ServiceProvider.GetService<Seeder>();
                seeder!.SeedAsync().Wait();
            }
        }
    }
}
