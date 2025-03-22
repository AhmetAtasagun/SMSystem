using Microsoft.Extensions.DependencyInjection;
using SMSystem.Desktop.Forms;
using SMSystem.Desktop.Services;
using SMSystem.Desktop.Services.Interfaces;
using App = System.Windows.Forms.Application;

namespace SMSystem.Desktop
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var authService = ServiceProvider.GetRequiredService<IAuthService>();
            Form form = default!;
            if (!authService.IsAuthenticated())
                form = ServiceProvider.GetRequiredService<LoginForm>();
            else
                form = ServiceProvider.GetRequiredService<MainForm>();

            App.Run(form);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddSingleton<ISaleService, SaleService>();

            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<CategoriesForm>();
            services.AddTransient<ProductsForm>();
            services.AddTransient<InventoryForm>();
            services.AddTransient<SaleForm>();
        }
    }
}