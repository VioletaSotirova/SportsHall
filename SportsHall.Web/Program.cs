using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsHall.Data;
using SportsHall.Data.Models;
using SportsHall.Services.Mapping;
using SportsHall.Web.ViewModels;
using SportsHall.Data.Repository.Interfaces;
using SportsHall.Data.Repository;
using SportsHall.Services.Data.Interfaces;
using SportsHall.Services.Data;

namespace SportsHall.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


            builder.Services.AddDbContext<SportsHallDbContext>(options =>
                options.UseSqlServer(connectionString));
 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(cfg =>
            {
                ConfigureIdentity(builder, cfg);
            })
                //.AddSignInManager<UserManager<ApplicationUser>>()
                //.AddUserManager<UserManager<ApplicationUser>>()
                // .AddUserStore<ApplicationUser>()
                .AddEntityFrameworkStores<SportsHallDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepository<Sport, int>, BaseRepository<Sport, int>>();
            builder.Services.AddScoped<IRepository<Coach, int>, BaseRepository<Coach, int>>();
            builder.Services.AddScoped<IRepository<Reservation, int>, BaseRepository<Reservation, int>>();
            builder.Services.AddScoped<IRepository<Training, int>, BaseRepository<Training, int>>();
            builder.Services.AddScoped<IRepository<TrainingStatus, int>, BaseRepository<TrainingStatus, int>>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

            builder.Services.AddScoped<ISportService, SportService>();
            builder.Services.AddScoped<ICoachService, CoachService>();
            builder.Services.AddScoped<ITrainingService, TrainingService>();
            builder.Services.AddScoped<ITrainingStatusService, TrainingStatusService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
        private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions cfg)
        {
            cfg.Password.RequireDigit =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
            cfg.Password.RequireLowercase =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            cfg.Password.RequireUppercase =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            cfg.Password.RequireNonAlphanumeric =
                builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumerical");
            cfg.Password.RequiredLength =
                builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            cfg.Password.RequiredUniqueChars =
                builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueCharacters");

            cfg.SignIn.RequireConfirmedAccount =
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
            cfg.SignIn.RequireConfirmedEmail =
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
            cfg.SignIn.RequireConfirmedPhoneNumber =
                builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");

            cfg.User.RequireUniqueEmail =
                builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
        }
    }
}
