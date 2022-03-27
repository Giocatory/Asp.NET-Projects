using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsefulArticles.Domain;
using UsefulArticles.Domain.Repositories.Abstract;
using UsefulArticles.Domain.Repositories.EntityFramework;
using UsefulArticles.Service;

namespace UsefulArticles
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Подключаем конфиг из appsettings.json
            Configuration.Bind("Projecet", new Config());

            // Нужный функционал в качестве сервисов
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            // подключаем контекст БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // Настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "GiocatoryAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            // Добавляем поддержку контроллеров и представлений (mvc)
            services.AddControllersWithViews().AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // порядок регистрации middleware очень важен!!!!!!!

            // для отображения ошибок в процессе разработки
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();



            // подключение поддержки статичных файлов в приложении (css, js ...) папка wwwroot
            app.UseStaticFiles();

            // подключение системы маршрутизации
            app.UseRouting();

            // подключение аутентификации и авторизации
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // регистрация маршрутов (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}