using Microsoft.Extensions.DependencyInjection;
using SMSystem.Desktop.Forms;
using SMSystem.Desktop.Services;

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

            // Configure services
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Start with login form
            Application.Run(ServiceProvider.GetRequiredService<LoginForm>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Register API services
            services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IInventoryService, InventoryService>();

            // Register forms
            services.AddTransient<LoginForm>();
            services.AddTransient<MainForm>();
            services.AddTransient<ProductsForm>();
            services.AddTransient<CategoriesForm>();
            services.AddTransient<InventoryForm>();
        }
    }
}