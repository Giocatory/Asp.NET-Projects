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

            // Добавляем поддержку контроллеров и представлений (mvc)
            services.AddControllersWithViews().AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // порядок регистрации middleware очень важен!!!!!!!

            // для отображения ошибок в процессе разработки
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            // подключение поддержки статичных файлов в приложении (css, js ...) папка wwwroot
            app.UseStaticFiles();

            // регистрация маршрутов (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}