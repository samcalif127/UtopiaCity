using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UtopiaCity.Common;
using UtopiaCity.Data;
using UtopiaCity.Services.CityAdministration;
using UtopiaCity.Services.Airport;
using UtopiaCity.Services.Business;
using UtopiaCity.Services.Emergency;
using UtopiaCity.Services.Life;
using UtopiaCity.Services.Sport;
using UtopiaCity.Services.Timeline;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;
using UtopiaCity.Services.Clinic;
using UtopiaCity.Services.HousingSystem;
using Microsoft.OpenApi.Models;

namespace UtopiaCity
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Services

            services.AddScoped<EmergencyReportService, EmergencyReportService>();
            services.AddScoped<ResidentAccountService, ResidentAccountService>();
            services.AddScoped<MarriageService, MarriageService>();
            services.AddScoped<SportComplexService, SportComplexService>();
            services.AddScoped<SportEventService, SportEventService>();
            services.AddScoped<SportTicketService, SportTicketService>();
            services.AddScoped<RequestToAdministrationService, RequestToAdministrationService>();
            services.AddScoped<FlightService, FlightService>();
            services.AddScoped<WeatherReportService, WeatherReportService>();
            services.AddScoped<TimelineService, TimelineService>();
            services.AddScoped<ScheduleService, ScheduleService>();
            services.AddScoped<PermitedConditonsService, PermitedConditonsService>();
            services.AddScoped<LifeService, LifeService>();
            services.AddScoped<IRouteApi, FlightRouteApiService>();
            services.AddScoped<BankService, BankService>();
            services.AddScoped<CompanyStatusService, CompanyStatusService>();
            services.AddScoped<CompanyAppService, CompanyAppService>();
            services.AddScoped<VacancyAppService, VacancyAppService>();
            services.AddScoped<ProfessionAppService, ProfessionAppService>();
            services.AddScoped<EmployeeAppService, EmployeeAppService>();
            services.AddScoped<CitizensAccountService, CitizensAccountService>();
            services.AddScoped<CitizenTaskService, CitizenTaskService>();
            services.AddScoped<ResumeAppService, ResumeAppService>();
            services.AddScoped<TicketService, TicketService>();
            services.AddScoped<PassengerService, PassengerService>();
            services.AddScoped<ClinicVisitService, ClinicVisitService>();
            services.AddScoped<CitizenFriendsService, CitizenFriendsService>();
            services.AddScoped<CheckedFlightService, CheckedFlightService>();
            services.AddScoped<FlightRouteApiService, FlightRouteApiService>();


            services.AddScoped<RealEstateService, RealEstateService>();
            services.AddTransient<IMailService, NullMailService>();
            services.AddScoped<ChatService, ChatService>();


            #endregion

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(25);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(25);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Utopia City Residents accounts API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                DbInitializer.RegisterSubInitializers();

                var appConfig = Configuration.GetSection("AppConfig").Get<AppConfig>();
                if (appConfig != null)
                {
                    if (appConfig.ClearDb)
                    {
                        DbInitializer.ClearDb(context);
                    }

                    if (appConfig.SeedDb)
                    {
                        DbInitializer.InitializeDb(context);
                    }
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ResidentAccountApi")
            );
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
